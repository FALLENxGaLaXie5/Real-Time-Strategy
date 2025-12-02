using Event_Bus;
using Units.Commands;
using Units.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using ISelectable = Units.Interfaces.ISelectable;

namespace Units
{
    public abstract class AbstractCommandable : MonoBehaviour, ISelectable
    {
        [field: SerializeField] public int CurrentHealth {get; private set;}
        [field: SerializeField] public int MaxHealth {get; private set;}
        [field: SerializeField] public ActionBase[] AvailableCommands {get; private set;}
        [SerializeField] private DecalProjector selectionDecal;
        [SerializeField] private UnitSO unitScriptableObject;

        protected virtual void Start()
        {
            CurrentHealth = unitScriptableObject.Health;
            MaxHealth = unitScriptableObject.Health;
        }

        public void Select()
        {
            selectionDecal.gameObject.SetActive(true);
            Bus<UnitSelectedEvent>.Raise(new UnitSelectedEvent(this));
        }

        public void Deselect()
        {
            selectionDecal.gameObject.SetActive(false);
            Bus<UnitDeselectedEvent>.Raise(new UnitDeselectedEvent(this));
        }
    }
}