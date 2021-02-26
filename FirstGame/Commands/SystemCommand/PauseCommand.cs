using FirstGame;
using Sprint0.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    class PauseCommand : ICommand
    {
        private Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentScene.GameState = new PauseState(game);
        }

        public void Undo()
        {
        }
    }
}
