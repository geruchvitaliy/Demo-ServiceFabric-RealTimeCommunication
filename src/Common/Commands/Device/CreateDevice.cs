using Common.Errors;
using Common.Models.Device;
using FluentValidation;
using MediatR;

namespace Common.Commands.Device
{
    public class CreateDevice : IRequest<DeviceId>
    {
        public CreateDevice(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    public class CreateDeviceValidator : AbstractValidator<CreateDevice>
    {
        public CreateDeviceValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(MessagesContainer.NameRequired);
        }
    }
}