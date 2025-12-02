using UnityEngine;

namespace Units.Commands
{
    public interface ICommand
    {
        bool CanExecute(AbstractCommandable commandable, RaycastHit hit);
        void Execute(AbstractCommandable commandable, RaycastHit hit);
    }
}