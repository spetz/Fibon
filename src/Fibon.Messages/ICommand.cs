using System.Threading.Tasks;

namespace Fibon.Messages
{
    public interface ICommand
    {
    }

    public class CalculateValueCommand : ICommand
    {
        public int Number { get; set; }
    }

    public interface ICommandHandler<in T>
        where T : ICommand
    {
        Task HandleAsync(T command);
    }

}
