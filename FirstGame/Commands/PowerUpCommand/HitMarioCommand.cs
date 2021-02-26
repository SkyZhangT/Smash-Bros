using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class HitMarioCommand: ICommand
    {
        private AvatarMain avatar;
        public HitMarioCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentPowerState = avatar.CurrentPowerState.Hit();
        }

        public void Undo()
        {
            //throw new NotImplementedException();
        }
    }
}
