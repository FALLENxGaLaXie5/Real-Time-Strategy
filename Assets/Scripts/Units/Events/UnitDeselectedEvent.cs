using Event_Bus;
using Units.Interfaces;

namespace Units.Events
{
    public struct UnitDeselectedEvent : IEvent
    {
        public ISelectable Unit { get; private set; }

        public UnitDeselectedEvent(ISelectable unit) => Unit = unit;
    }
}