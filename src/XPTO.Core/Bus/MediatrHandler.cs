using MediatR;
using System;
using System.Threading.Tasks;
using XPTO.Core.Domain;
using XPTO.Core.Messages;

namespace XPTO.Core.Bus
{
    public class MediatrHandler : IMediatrHandler
    {
        public readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task PublishNotification<T>(T notification) where T : DomainNotifier
        {
            return Task.Run(() => Console.WriteLine(notification.ToString()));
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task SendEvent<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }
    }
}
