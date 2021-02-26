using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Commands.Mapping;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Blocks;
using Sprint0.InputControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.EntityState.BlockStates
{
    class FlagHitState: IState
    {
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }
        public FlagPole Pole { get; set; }

        public FlagHitState(FlagPole entity, Game1 game)
        {
            Pole = entity;
            Game = game;
            Pole.HitBox = new Rectangle(-1,-1,-1,-1);
            Game.CurrentScene.Controller = new Controller(new EndingCommandMap(Game));
        }

        public void Update(GameTime gameTime)
        {
            if (Pole.Flag.Position.Y <= Pole.Position.Y + 136)
            {
                Pole.Flag.Position = new Vector2(Pole.Flag.Position.X, Pole.Flag.Position.Y + 1);
            }
        }

    }
}
