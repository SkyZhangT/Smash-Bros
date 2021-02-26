using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.ItemSprite
{
    class StarSprite : AnimatedSprite
    {
        public StarSprite()
        {
            this.AnimationFrame = 27;
            this.NeedFlip = false;
            this.TimeSinceLastFrame = 0;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                if (this.AnimationFrame == 30)
                {
                    this.AnimationFrame = 27;
                }
                else this.AnimationFrame++;


            }
        }

    }
}
