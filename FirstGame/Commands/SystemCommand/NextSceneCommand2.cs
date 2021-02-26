using FirstGame;
using Sprint0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SystemCommand
{
    public class NextSceneCommand2 : ICommand
    {
        private Game1 game;
        public NextSceneCommand2(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            Console.Write("new scene");
            game.Winner = 1;
            game.CurrentScene = new EndGameScene(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {

        }
    }
}