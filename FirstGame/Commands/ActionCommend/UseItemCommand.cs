using FirstGame;
using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class UseItemCommand : ICommand
    {
        private AvatarMain avatar;

        public UseItemCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }

        public void Execute()
        {
            avatar.UseItem();
        }

        public void Undo()
        {
            //throw new NotImplementedException();
        }
    }
}
