using Event_Bus;

namespace Units.Events
{
    public struct UnitSpawnEvent : IEvent
    {
        public AbstractUnit Unit { get; private set; }
        public UnitSpawnEvent(AbstractUnit unit) => Unit = unit;
    }
}