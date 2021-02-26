using FirstGame;
using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class DashFireballCommand : ICommand
    {
       private AvatarMain avatar;

        public DashFireballCommand(AvatarMain avatar)
        {
            this.avatar = avatar;
        }

        public void Execute()
        {
            
            if(avatar.CurrentPowerState is FireMarioPowerUpState&&avatar is MarioAvatar)
            {
                avatar.ThrowFireBall();
                avatar.CurrentActionState = new FireBallThrow(avatar.Game,avatar);
            }
            else if(avatar.CurrentPowerState is FireMarioPowerUpState && avatar is TurtleAvatar)
            {
                avatar.ThrowFireBall();
                avatar.CurrentActionState = new TurtleFireBallThrow(avatar.Game, avatar);
            }
            
        }

        public void Undo()
        {
            //throw new NotImplementedException();
        }
    }
}
