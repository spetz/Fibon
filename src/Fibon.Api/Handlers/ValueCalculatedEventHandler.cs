using System.Threading.Tasks;
using Fibon.Messages;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        private readonly IRepository _repo;

        public ValueCalculatedEventHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task HandleAsync(ValueCalculatedEvent @event)
        {
            _repo.Insert(number: @event.Number, result: @event.Result);
            await Task.CompletedTask;
        }
    }
}
