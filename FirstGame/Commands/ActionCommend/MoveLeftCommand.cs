using Sprint0.Game_Enities.Avatar;
using System;

namespace Sprint0.Commands
{
    class MoveLeftCommand : ICommand
    {
        private AvatarMain avatar;
        public MoveLeftCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentActionState.GoLeft(0);
        }

        public void Undo()
        {
            avatar.CurrentActionState.GoRight(1);
        }
    }
}
