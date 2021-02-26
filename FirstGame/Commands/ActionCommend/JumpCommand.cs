using Sprint0.Game_Enities.Avatar;
using System;

namespace Sprint0.Commands
{
    class JumpCommand : ICommand
    {
        private AvatarMain avatar;

        public JumpCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentActionState.GoUp(0);
        }

        public void Undo()
        {
            //avatar.CurrentActionState.GoDown(1);
        }
    }
}
