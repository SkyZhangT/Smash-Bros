using FirstGame;
using Sprint0.Scenes;
using System;

namespace Sprint0.Commands.SystemCommand
{
    public class EndGameCommand : ICommand
    {
        private Game1 game;
        public EndGameCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            Console.Write("new scene");
            game.CurrentScene = new StartScene(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {
        }
    }
}
