namespace Fibon.Messages.Events
{
    public class ValueCalculated : IEvent
    {
        public int Number { get; set; }
        public int Result { get; set; }
    }
}