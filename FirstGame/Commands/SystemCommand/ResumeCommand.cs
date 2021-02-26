using FirstGame;
using Sprint0.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sprint0.Commands.SystemCommand
{
    class ResumeCommand : ICommand
    {
        private Game1 game;
        public ResumeCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentScene.GameState = new PlayState(game);
        }

        public void Undo()
        {
        }
    }
}
