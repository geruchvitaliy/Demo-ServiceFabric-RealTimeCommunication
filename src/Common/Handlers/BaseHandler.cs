using FluentValidation;
using MediatR;
using System;
using System.Linq;

namespace Common.Handlers
{
    public abstract class BaseHandler
    {
        private readonly IMediator _mediator;

        public BaseHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async void PublishEvent<T>(T @event) where T : INotification =>
            await _mediator.Publish(@event);

        protected void ValidateAndThrow<T>(T obj)
        {
            var validator = GetValidator<T>();
            validator.ValidateAndThrow(obj);
        }

        private IValidator<T> GetValidator<T>()
        {
            var type = typeof(T);
            var validatorType = type.Assembly.GetTypes().Single(x => x.Name == ($"{type.Name}Validator"));
            return (IValidator<T>)Activator.CreateInstance(validatorType);
        }
    }
}