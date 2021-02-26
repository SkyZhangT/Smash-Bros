using FirstGame;
using Sprint0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SystemCommand
{
    public class SelectLuigiCommand : ICommand
    {
        private Game1 game;
        public SelectLuigiCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.CurrentScene is CharacterSelectScene1)
            {
                game.Player1 = 2;
                Console.Write("new scene");
                game.CurrentScene = new CharacterSelectScene2(game);
                game.CurrentScene.Initialize();
            }
            else
            {
                game.Player2 = 2;
                Console.Write("new scene");
                game.CurrentScene = new MapSelectScene(game);
                game.CurrentScene.Initialize();
            }
        }

        public void Undo()
        {
        }
    }
}