using System;
using Event_Bus;
using Pathfinding;
using Pathfinding.ECS.RVO;
using Units.Events;
using Units.Interfaces;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Units
{
    [RequireComponent(typeof(FollowerEntity))]
    public class Worker : MonoBehaviour, ISelectable, IMoveable
    {
        [Header("Selection")]
        [SerializeField] private DecalProjector selectionDecal;

        [Header("Local Avoidance Priority (0..1)")]
        [Tooltip("Priority when this unit is moving. Lower means it will yield more to others.")]
        [Range(0f, 1f)] [SerializeField] private float movingPriority = 0.4f;
        [Tooltip("Priority when this unit is stationary. Higher means others will go around it.")]
        [Range(0f, 1f)] [SerializeField] private float stationaryPriority = 0.9f;

        [Header("Movement Detection (hysteresis)")]
        [Tooltip("Speed (m/s) above which the unit is considered moving.")]
        [SerializeField] private float startMovingSpeed = 0.05f;
        [Tooltip("Speed (m/s) below which the unit is considered stationary.")]
        [SerializeField] private float stopMovingSpeed = 0.01f;

        private IAstarAI agent;
        private FollowerEntity follower;
        private bool isMoving;

        private void OnEnable()
        {
            agent = GetComponent<IAstarAI>();
            follower = GetComponent<FollowerEntity>();
            // Initialize priority based on current state
            ApplyPriority(isMoving);
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

        private void Update()
        {
            // Determine if the agent is moving using hysteresis to avoid rapid toggling
            var speed = agent.velocity.magnitude;
            bool targetMoving = isMoving
                ? speed > stopMovingSpeed // once moving, require dropping below stop threshold to stop
                : speed >= startMovingSpeed; // once stationary, require exceeding start threshold to move

            if (targetMoving != isMoving)
            {
                isMoving = targetMoving;
                ApplyPriority(isMoving);
            }
        }

        private void ApplyPriority(bool moving)
        {
            // rvoSettings is a struct in A* Pathfinding Project; modify a copy and assign back
            RVOAgent rvo = follower.rvoSettings;
            rvo.priority = moving ? movingPriority : stationaryPriority;
            follower.rvoSettings = rvo;
        }
    }
}