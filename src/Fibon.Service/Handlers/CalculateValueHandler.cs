using System.Threading.Tasks;
using Fibon.Messages;
using Fibon.Messages.Commands;
using Fibon.Messages.Events;
using RawRabbit;

namespace Fibon.Service.Handlers
{
    public class CalculateValueHandler : ICommandHandler<CalculateValue>
    {
        private readonly IBusClient _client;
        private readonly ICalculator _calculator;

        public CalculateValueHandler(IBusClient client, ICalculator calculator)
        {
            _client = client;
            _calculator = calculator;
        }

        public async Task HandleAsync(CalculateValue command)
        {
            int result = _calculator.Fib(command.Number);

            await _client.PublishAsync(new ValueCalculated
            {
                Number = command.Number,
                Result = result
            });
        }
    }
}
