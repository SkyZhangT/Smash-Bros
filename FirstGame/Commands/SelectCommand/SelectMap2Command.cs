using FirstGame;
using Sprint0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SelectCommand
{
    class SelectMap2Command : ICommand
    {
        private Game1 game;
        public SelectMap2Command(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Level = 2;
            game.CurrentScene = new FinishSelectScene(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {
        }
    }
}