using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Behavior
{
    class DownBehavior : ABehavior
    {
        public DownBehavior(IEntity entity) : base(entity) { }
       // public DownBehavior(IEntity entity, int moveAmount) : base(entity, moveAmount) { }

        public override void Update(GameTime time)
        {
            this.MillisSinceLastUpdate += time.ElapsedGameTime.Milliseconds;

            if (this.MillisSinceLastUpdate > MILLIS_PER_UPDATE)
            {
                this.MillisSinceLastUpdate -= MILLIS_PER_UPDATE;
                float currentY = this.Entity.Position.Y;

                if (currentY + this.MoveAmount + this.Entity.CurrentSprite.FrameSize.Y > this.Entity.Game.GraphicsDevice.Viewport.Height)
                {

                    this.Entity.Position = new Vector2(this.Entity.Position.X, this.Entity.Game.GraphicsDevice.Viewport.Height - this.Entity.CurrentSprite.FrameSize.Y);
                }
                else this.Entity.Position = new Vector2(this.Entity.Position.X,this.Entity.Position.Y + this.MoveAmount);
            }
        }
    }
}
