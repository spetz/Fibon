using System.Threading.Tasks;

namespace Fibon.Messages
{
    public interface IEvent
    {   
    }

    public class ValueCalculatedEvent : IEvent
    {
        public int Number { get; set; }
        public int Result { get; set; }
    }

    public interface IEventHandler<in T>
        where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
