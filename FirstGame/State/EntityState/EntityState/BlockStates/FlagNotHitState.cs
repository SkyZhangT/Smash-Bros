using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.EntityState.BlockStates
{
    class FlagNotHitState : IState
    {
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }
        public FlagPole Pole { get; set; }

        public FlagNotHitState(FlagPole entity, Game1 game)
        {
            Pole = entity;
            Game = game;
            Pole.HitBox = new Rectangle((int)Pole.Position.X, 0, Pole.CurrentSprite.FrameSize.X, Game.GraphicsDevice.Viewport.Height);
        }

        public void Update(GameTime gameTime)
        {
            Pole.ActionState =new FlagHitState(Pole, Game);
        }
    }
}
