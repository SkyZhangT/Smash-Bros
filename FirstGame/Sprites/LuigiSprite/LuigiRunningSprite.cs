using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    
    class LuigiRunningSprite : AnimatedSprite
    {
        private bool FD;
        public LuigiRunningSprite()
        {
            AnimationFrame = 2;
            this.FD = true;
            this.TimeSinceLastFrame = 0;
        }
        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                if (FD)
                {
                    AnimationFrame+=1;
                }
                else
                {
                    AnimationFrame-=1;
                }

                if (AnimationFrame == 4|| AnimationFrame == 2)   
                {
                    FD = !FD;
                }

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }
    }
}