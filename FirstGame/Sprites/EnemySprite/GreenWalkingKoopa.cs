using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class GreenWalkingKoopa:  AnimatedSprite
    {
        public GreenWalkingKoopa()
        {
            NeedFlip = true;
            this.TimeSinceLastFrame = 0;
            this.Iterator = 1;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                if (Iterator == 1)
                {
                    AnimationFrame += 1;
                    Iterator = 0;
                }
                else
                {
                    AnimationFrame -= 1;
                    Iterator = 1;
                }

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }

    }
}
