using UnityEngine;

namespace Units.Commands
{
    public interface ICommand
    {
        bool CanExecute(CommandContext context);
        void Execute(CommandContext context);
    }
}