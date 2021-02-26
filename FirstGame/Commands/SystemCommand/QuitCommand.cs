using FirstGame;
using System;

namespace Sprint0.Commands
{
    class QuitCommand : ICommand
    {
        private readonly Game1 game;

        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
           this.game.Quit();
        }

        public void Undo() {}
    }
}
