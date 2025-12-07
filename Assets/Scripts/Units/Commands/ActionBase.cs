using UnityEditor;
using UnityEngine;

namespace Units.Commands
{
    public abstract class ActionBase : ScriptableObject, ICommand
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: Range(0, 8)] [field: SerializeField] public int Slot { get; private set; }
        [field: SerializeField] public bool RequiresClickToActivate { get; private set; } = true;

        public abstract bool CanExecute(CommandContext context);
        public abstract void Execute(CommandContext context);

    }
}