using FirstGame;
using Sprint0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SystemCommand
{
    class ReselectCommand : ICommand
    {
        private Game1 game;
        public ReselectCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            Console.Write("new scene");
            game.CurrentScene = new CharacterSelectScene1(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {
        }
    }
}