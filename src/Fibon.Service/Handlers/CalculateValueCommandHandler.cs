using System.Threading.Tasks;
using Fibon.Messages;
using RawRabbit;

namespace Fibon.Service.Handlers
{
    public class CalculateValueCommandHandler :
        ICommandHandler<CalculateValueCommand>
    {
        private readonly IBusClient _client;

        public CalculateValueCommandHandler(IBusClient client)
        {
            _client = client;
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            int result = Fib(command.Number);

            await _client.PublishAsync(
                new ValueCalculatedEvent
                {
                    Number = command.Number,
                    Result = result
                });
        }

        private int Fib(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Fib(n - 2) + Fib(n - 1);
            }
        }
    }
}
