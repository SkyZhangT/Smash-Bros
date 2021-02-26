using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class PromoteSuperMarioCommand: ICommand
    {
        private AvatarMain avatar;
        public PromoteSuperMarioCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }
        public void Execute()
        {
            avatar.CurrentPowerState = avatar.CurrentPowerState.PromoteSuperMario();
            avatar.CurrentActionState.Update(null);
        }

        public void Undo()
        {
          //  throw new NotImplementedException();
        }
    }
}
