using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.ItemSprite
{
    class BlueFireFlowerSprite : AnimatedSprite
    {
        public BlueFireFlowerSprite()
        {
            this.NeedFlip = false;
            this.TimeSinceLastFrame = 0;
            this.AnimationFrame = 22;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                if (this.AnimationFrame == 25)
                {
                    this.AnimationFrame = 22;
                }
                else this.AnimationFrame++;
            }
        }
    }
}
