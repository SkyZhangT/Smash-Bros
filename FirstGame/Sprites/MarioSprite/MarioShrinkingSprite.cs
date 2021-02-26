using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    class MarioShrinkingSprite : AnimatedSprite
    {
        private int Iteration { get; set; }

        public MarioShrinkingSprite()
        {
            AnimationFrame = 2;
            NeedFlip = true;
            this.TimeSinceLastFrame = 0;
            Iteration = 2;
        }
        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;


                switch (Iteration)
                {
                    case 1:
                        AnimationFrame = 2;
                        break;
                    case 2:
                        AnimationFrame = 1;
                        break;
                    case 3:
                        AnimationFrame = 2;
                        break;
                    case 4:
                        AnimationFrame = 1;
                        break;
                    case 5:
                        AnimationFrame = 2;
                        break;
                    case 6:
                        AnimationFrame = 1;
                        break;
                    case 7:
                        AnimationFrame = 0;
                        break;
                }
                Iteration += 1;

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }




        }
    }
}