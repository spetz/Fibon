using System.Threading.Tasks;
using Fibon.Messages;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        public Task HandleAsync(ValueCalculatedEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
