using System;
using FirstGame;

namespace Sprint0.Commands
{
    class HitBoxCommand : ICommand
    {
        Game1 Game { get; set; }
        public HitBoxCommand(Game1 game)
        {
            Game = game;
        }
        public void Execute()
        {
            Game.VisibleHitBox = !Game.VisibleHitBox;
        }

        public void Undo()
        {
          //  throw new NotImplementedException();
        }
    }
}
