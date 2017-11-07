using Common.Errors;
using Common.Models.Device;
using FluentValidation;
using MediatR;
using System;

namespace Common.Commands.Device
{
    public class UpdateLocation : IRequest
    {
        public UpdateLocation(Guid deviceId, decimal latitude, decimal longitude, DateTime date)
        {
            DeviceId = new DeviceId(deviceId);
            Location = new Location(latitude, longitude, date);
        }

        public DeviceId DeviceId { get; private set; }
        public Location Location { get; private set; }
    }

    public class UpdateLocationValidator : AbstractValidator<UpdateLocation>
    {
        public UpdateLocationValidator()
        {
            RuleFor(x => x.DeviceId)
                .NotNull()
                .NotEqual(DeviceId.Empty)
                .WithMessage(MessagesContainer.DeviceIdRequired);

            RuleFor(x => x.DeviceId.Id)
                .NotEmpty()
                .WithMessage(MessagesContainer.DeviceIdRequired);

            RuleFor(x => x.Location)
                .NotNull()
                .NotEqual(Location.Empty)
                .WithMessage(MessagesContainer.DeviceLocationRequired);
        }
    }
}