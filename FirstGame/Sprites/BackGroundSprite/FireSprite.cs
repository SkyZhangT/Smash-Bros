using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.BackGroundSprite
{
    public class FireSprite : AnimatedSprite
    {
        public FireSprite()
        {
            AnimationFrame = 1;
            this.TimeSinceLastFrame = 0;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                if (AnimationFrame == 30)
                {
                    AnimationFrame = 1;
                }
                else
                {
                    AnimationFrame += 1;
                }


                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }
    }
}
