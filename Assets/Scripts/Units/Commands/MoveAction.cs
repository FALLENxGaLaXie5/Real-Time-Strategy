using Units.Interfaces;
using UnityEngine;

namespace Units.Commands
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "AI/Actions/Move", order = 100)]
    public class MoveAction : ActionBase
    {
        public override bool CanExecute(AbstractCommandable commandable, RaycastHit hit)
        {
            return commandable is IMoveable;
        }

        public override void Execute(AbstractCommandable commandable, RaycastHit hit)
        {
            IMoveable moveable = (IMoveable)commandable;
            moveable.MoveTo(hit.point);
        }
    }
}