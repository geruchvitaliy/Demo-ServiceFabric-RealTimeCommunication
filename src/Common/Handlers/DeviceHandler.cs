using Common.Commands.Device;
using Common.Errors;
using Common.Events.Device;
using Common.IRepositories;
using Common.IServices;
using Common.Models;
using Common.Models.Device;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Handlers
{
    public sealed class DeviceHandler : BaseHandler,
        IAsyncRequestHandler<CreateDevice, DeviceId>,
        IAsyncRequestHandler<UpdateProfile>,
        IAsyncRequestHandler<UpdateLocation>,
        IAsyncRequestHandler<SyncDevicesStatuses>,
        IAsyncRequestHandler<GetLocations, IEnumerable<Location>>,
        IAsyncRequestHandler<GetLastLocation, Location>,
        IAsyncRequestHandler<GetProfile, Profile>,
        IAsyncRequestHandler<GetDevicesCount, int>,
        IAsyncRequestHandler<GetDevicesIds, IEnumerable<DeviceId>>,
        IAsyncRequestHandler<GetDevicesStatuses, IEnumerable<StatusDto>>,
        IAsyncNotificationHandler<DeviceCreated>,
        IAsyncNotificationHandler<LocationUpdated>,
        IAsyncNotificationHandler<ProfileUpdated>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IDeviceTypeRepository _deviceTypeRepository;
        private readonly ISignalRService _signalRService;

        public DeviceHandler(IMediator mediator,
            IDeviceRepository deviceRepository,
            IDeviceTypeRepository deviceTypeRepository,
            ISignalRService signalRService)
            : base(mediator)
        {
            _deviceRepository = deviceRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _signalRService = signalRService;
        }

        public async Task<DeviceId> Handle(CreateDevice message)
        {
            ValidateAndThrow(message);

            var id = DeviceId.New();
            var profile = Profile.New(message.Name);

            await _deviceRepository.UpdateProfileAsync(id, profile);

            PublishEvent(new DeviceCreated(id));

            return id;
        }

        public async Task Handle(UpdateProfile message)
        {
            ValidateAndThrow(message);

            if (!await _deviceTypeRepository.IsDeviceRegisteredAsync(message.DeviceId))
                throw new DeviceIdNotRegisteredException();

            await _deviceRepository.UpdateProfileAsync(message.DeviceId, message.Profile);

            PublishEvent(new ProfileUpdated(message.DeviceId, message.Profile));
        }

        public async Task Handle(UpdateLocation message)
        {
            ValidateAndThrow(message);

            if (!await _deviceTypeRepository.IsDeviceRegisteredAsync(message.DeviceId))
                throw new DeviceIdNotRegisteredException();

            await _deviceRepository.AddLocationAsync(message.DeviceId, message.Location);

            PublishEvent(new LocationUpdated(message.DeviceId, message.Location));
        }

        public async Task Handle(SyncDevicesStatuses message)
        {
            int sentCount = 0;
            int totalCount = await _deviceTypeRepository.GetDevicesCountAsync();
            var page = DataPage.Default();

            while (sentCount < totalCount)
            {
                var statuses = await _deviceTypeRepository.GetDevicesStatusesAsync(page);
                var group = statuses.Select(x => x.ToStatusDto()).ToList();

                //Testing Data: generating random last communication date between now and last 36 hours
                var random = new Random();
                foreach (var item in group)
                {
                    item.LastCommunicationDate = DateTime.UtcNow.AddMinutes(random.Next(-2160, 0));
                    item.LastCommunicationElapsedTime = Math.Round((DateTime.UtcNow - item.LastCommunicationDate).TotalMinutes, 2);
                    item.Status = item.LastCommunicationDate.ToStatus();
                }
                //End of Testing Data

                sentCount += group.Count();
                page = page.Next();
                await _signalRService.PublishDevicesAndStatusesAsync(group, sentCount, totalCount);
            }
        }

        public async Task<IEnumerable<Location>> Handle(GetLocations message) =>
            await _deviceRepository.GetLocationsAsync(message.DeviceId);

        public async Task<Location> Handle(GetLastLocation message) =>
            await _deviceRepository.GetLastLocationAsync(message.DeviceId);

        public async Task<Profile> Handle(GetProfile message) =>
            await _deviceRepository.GetProfileAsync(message.DeviceId);

        public async Task<int> Handle(GetDevicesCount message) =>
            await _deviceTypeRepository.GetDevicesCountAsync();

        public async Task<IEnumerable<DeviceId>> Handle(GetDevicesIds message)
        {
            if (message.Page == DataPage.Empty)
                return new List<DeviceId>();

            return await _deviceTypeRepository.GetDevicesIdsAsync(message.Page);
        }

        public async Task<IEnumerable<StatusDto>> Handle(GetDevicesStatuses message)
        {
            if (message.Page == DataPage.Empty)
                return new List<StatusDto>();

            var statuses = await _deviceTypeRepository.GetDevicesStatusesAsync(message.Page);
            return statuses.ToStatusDto();
        }



        public async Task Handle(DeviceCreated notification)
        {
            await _deviceTypeRepository.RegisterDeviceAsync(notification.DeviceId);
        }

        public async Task Handle(LocationUpdated notification)
        {
            await _deviceTypeRepository.UpdateLocationAsync(notification.DeviceId, notification.Location);
        }

        public async Task Handle(ProfileUpdated notification)
        {
            await _deviceTypeRepository.UpdateCommunicationDateAsync(notification.DeviceId, DateTime.UtcNow);
        }
    }
}