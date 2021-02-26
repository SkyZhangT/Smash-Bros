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
    class RedWalkingKoopa : AnimatedSprite
    {

        public RedWalkingKoopa()
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
                    this.NeedFlip = false;
                    AnimationFrame += 1;
                    Iterator = 2;
                }
                else if (Iterator == 2)
                {
                    AnimationFrame -= 1;
                    Iterator = 3;
                }
                else if (Iterator == 3)
                {
                    AnimationFrame += 1;
                    Iterator =4;
                    this.NeedFlip =true;
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
