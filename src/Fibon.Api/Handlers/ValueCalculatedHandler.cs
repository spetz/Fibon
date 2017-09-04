using System.Threading.Tasks;
using Fibon.Messages;
using Fibon.Messages.Events;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedHandler : IEventHandler<ValueCalculated>
    {
        private readonly IRepository _repository;

        public ValueCalculatedHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(ValueCalculated @event)
        {
            _repository.Insert(number: @event.Number, result: @event.Result);
            await Task.CompletedTask;
        }
    }
}
