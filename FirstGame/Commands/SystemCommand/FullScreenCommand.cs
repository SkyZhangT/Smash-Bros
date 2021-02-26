using System;
using FirstGame;


namespace Sprint0.Commands
{
    class FullScreenCommand : ICommand
    {
        private Game1 game;
        public FullScreenCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentScene.ToggleFullScreen();
        }

        public void Undo() { }
    }
}
