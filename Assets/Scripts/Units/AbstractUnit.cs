using System;
using Event_Bus;
using Pathfinding;
using Units.Events;
using Units.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Units
{
    [RequireComponent(typeof(FollowerEntity))]

    public abstract class AbstractUnit : MonoBehaviour, ISelectable, IMoveable
    {
        [Header("Selection")]
        [SerializeField] private DecalProjector selectionDecal;

        private IAstarAI agent;
        private FollowerEntity follower;

        private void Start()
        {
            Bus<UnitSpawnEvent>.Raise(new UnitSpawnEvent(this));
        }

        private void OnEnable()
        {
            agent = GetComponent<IAstarAI>();
            follower = GetComponent<FollowerEntity>();
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

        public void MoveTo(Vector3 position)
        {
            agent.destination = position;
        }
    }
}