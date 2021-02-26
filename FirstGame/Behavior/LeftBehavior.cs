using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Behavior
{
    class LeftBehavior : ABehavior
    {
        public LeftBehavior(IEntity entity) : base(entity) { }
        public LeftBehavior(IEntity entity, int moveAmount) : base(entity, moveAmount) { }

        public override void Update(GameTime time)
        {
            this.MillisSinceLastUpdate += time.ElapsedGameTime.Milliseconds;

            if (this.MillisSinceLastUpdate > MILLIS_PER_UPDATE)
            {
                this.MillisSinceLastUpdate -= MILLIS_PER_UPDATE;
                float currentX = this.Entity.Position.X;

                if (currentX - this.MoveAmount /*- this.entity.CurrentSprite.FrameSize.X*/ < this.Entity.Game.GraphicsDevice.Viewport.Bounds.Left)
                {

                    this.Entity.Position = new Vector2(this.Entity.Game.GraphicsDevice.Viewport.Bounds.Left /*+ this.entity.CurrentSprite.FrameSize.X*/, this.Entity.Position.Y);
                }
                else this.Entity.Position = new Vector2(this.Entity.Position.X - this.MoveAmount, this.Entity.Position.Y);
            }
        }
    }
}
