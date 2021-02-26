using FirstGame;
using Sprint0.Scenes;
using System;

namespace Sprint0.Commands.SystemCommand
{
    public class StartGameCommand:ICommand
    {
        private Game1 game;
        public StartGameCommand(Game1 game)
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
