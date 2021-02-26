using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
    {
        class ClimbingMario : AnimatedSprite
        {
            public ClimbingMario()
            {
                AnimationFrame = 2;
                this.TimeSinceLastFrame = 0;
            }
            public override void UpdateSprite(GameTime gameTime)
            {
                TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

                if (TimeSinceLastFrame > MillisecondsPerFrame)
                {
                    TimeSinceLastFrame -= MillisecondsPerFrame;
                if (AnimationFrame == 1)
                {
                    AnimationFrame = 2;
                }
                else
                {
                    AnimationFrame = 1;
                }
                    CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
                }
                
            }
        }
    }

