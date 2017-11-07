using Common.Errors;
using Common.Models.Device;
using FluentValidation;
using MediatR;
using System;

namespace Common.Commands.Device
{
    public class UpdateProfile : IRequest
    {
        public UpdateProfile(Guid deviceId, string name)
        {
            DeviceId = new DeviceId(deviceId);
            Profile = new Profile(name);
        }

        public DeviceId DeviceId { get; private set; }
        public Profile Profile { get; private set; }
    }

    public class UpdateProfileValidator : AbstractValidator<UpdateProfile>
    {
        public UpdateProfileValidator()
        {
            RuleFor(x => x.DeviceId)
                .NotNull()
                .NotEqual(DeviceId.Empty)
                .WithMessage(MessagesContainer.DeviceIdRequired);

            RuleFor(x => x.DeviceId.Id)
                .NotEmpty()
                .WithMessage(MessagesContainer.DeviceIdRequired);

            RuleFor(x => x.Profile)
                .NotNull()
                .NotEqual(Profile.Empty);

            RuleFor(x => x.Profile.Name)
                .NotEmpty()
                .WithMessage(MessagesContainer.NameRequired);
        }
    }
}