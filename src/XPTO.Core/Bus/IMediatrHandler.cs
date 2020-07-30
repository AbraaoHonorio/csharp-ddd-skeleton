using System.Threading.Tasks;
using XPTO.Core.Domain;
using XPTO.Core.Messages;

namespace XPTO.Core.Bus
{
    public interface IMediatrHandler
    {
        Task SendEvent<T>(T @event) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotifier;
    }
}