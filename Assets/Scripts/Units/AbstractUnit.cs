using System;
using Event_Bus;
using NUnit.Framework.Constraints;
using Pathfinding;
using Units.Events;
using Units.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Units
{
    [RequireComponent(typeof(FollowerEntity))]

    public abstract class AbstractUnit : AbstractCommandable, IMoveable
    {
        public float AgentRadius => agent.radius;
        private IAstarAI agent;
        private FollowerEntity follower;

        protected override void Start()
        {
            base.Start();
            Bus<UnitSpawnEvent>.Raise(new UnitSpawnEvent(this));
        }

        private void Awake()
        {
            agent = GetComponent<IAstarAI>();
            follower = GetComponent<FollowerEntity>();
        }

        public void MoveTo(Vector3 position)
        {
            agent.destination = position;
        }
    }
}