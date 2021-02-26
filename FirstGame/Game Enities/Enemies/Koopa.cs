using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Game_Enities.Enemies
{
    class Koopa : EnemyEntity
    {

        private int timesincelast = 0;
        public override void Initialize()
        {
            base.Initialize();
        }

        public Koopa(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position, Velocity)
        {
            this.Visible = true;
            this.ActionState = new AliveKoopa(this);
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            timesincelast += gameTime.ElapsedGameTime.Milliseconds;
            if (this.Position.Y > Game.CurrentScene.FirstBottomRightBoundary.Y + 400)
            {
                this.Visible = false;
            }

        }
    }
}
