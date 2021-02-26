using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
   class CrouchCommand : ICommand
    {
        private AvatarMain avatar;
        public CrouchCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentActionState.GoDown(0);
        }

        public  void Undo()
        {
            avatar.CurrentActionState.GoUp(1);
        }
    }
}
