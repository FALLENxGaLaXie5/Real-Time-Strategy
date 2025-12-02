using UnityEngine;

namespace Units.Commands
{
    public abstract class ActionBase : ScriptableObject, ICommand
    {
        public abstract bool CanExecute(AbstractCommandable commandable, RaycastHit hit);

        public abstract void Execute(AbstractCommandable commandable, RaycastHit hit);

    }
}