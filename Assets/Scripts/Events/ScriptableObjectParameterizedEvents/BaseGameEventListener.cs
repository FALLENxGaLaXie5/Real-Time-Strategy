using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Events.ParameterizedEvents
{
    [ExecuteInEditMode]
    public abstract class BaseGameEventListener<T, Ge, Uer> : MonoBehaviour
        where Ge : BaseGameEvent<T>
        where Uer : UltEvents.UltEvent<T>
    {
        [FormerlySerializedAs("_GameEvent")] [SerializeField]
        protected Ge gameEvent;

        [FormerlySerializedAs("_UnityEventResponse")] [SerializeField]
        protected Uer unityEventResponse;

        protected void OnEnable()
        {
            if (gameEvent is null) return;
            gameEvent.EventListeners += TriggerResponses; // Subscribe
        }

        protected void OnDisable()
        {
            if (gameEvent is null) return;
            gameEvent.EventListeners -= TriggerResponses; // Unsubscribe
        }

        [ContextMenu("Trigger Responses")]
        public void TriggerResponses(T val)
        {
            //No need to nullcheck here, UnityEvents do that for us (lets avoid the double nullcheck)
            unityEventResponse.Invoke(val);
        }
    }
}