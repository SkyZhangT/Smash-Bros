using FirstGame;
using Sprint0.Scenes;
using Sprint0.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SystemCommand
{
    public class NextSceneCommand : ICommand
    {
        private Game1 game;
        public NextSceneCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            Console.Write("new scene");
            SoundManager.EndAllSound();
            SoundManager.EndBackground();
            game.CurrentScene = new Map(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {

        }
    }
}