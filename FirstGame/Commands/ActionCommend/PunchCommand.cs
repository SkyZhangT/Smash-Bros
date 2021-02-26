using Sprint0.Game_Enities.Avatar;
using System;

namespace Sprint0.Commands
{
    class PunchCommand : ICommand
    {
        private AvatarMain avatar;

        public PunchCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentActionState.Punch(0);
        }

        public void Undo()
        {
           
        }
    }
}
