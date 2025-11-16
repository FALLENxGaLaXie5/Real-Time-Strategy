using Event_Bus;
using Units.Interfaces;

namespace Units.Events
{
    public struct UnitSelectedEvent : IEvent
    {
        public ISelectable Unit { get; private set; }
        public UnitSelectedEvent(ISelectable unit) => Unit = unit;
    }
}