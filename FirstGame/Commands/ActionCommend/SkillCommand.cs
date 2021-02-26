using FirstGame;
using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class SkillCommand : ICommand
    {
        private Game1 game;
        private AvatarMain avatar;
        public SkillCommand(Game1 game, AvatarMain avatar)
        {
            this.game = game;
            this.avatar = avatar;
        }
        public void Execute()
        {
            if (avatar==game.CurrentScene.PlayerAvatar)
            {
                int energy1 = game.CurrentScene.IndicatorManager.Value("charger");
                if (energy1 == 50)
                {
                    game.CurrentScene.GameState = new SkillState(game, avatar);
                    game.CurrentScene.IndicatorManager.Charger.ResetCharger();
                }
            }
            else if (avatar == game.CurrentScene.PlayerAvatar2)
            {
                int energy2= game.CurrentScene.IndicatorManager2.Value("charger");
                if (energy2 == 50)
                {
                    game.CurrentScene.GameState = new SkillState(game, avatar);
                    game.CurrentScene.IndicatorManager2.Charger.ResetCharger();
                }
            }
        }

        public void Undo()
        {

        }
    }
}
