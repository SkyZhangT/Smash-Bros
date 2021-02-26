using Microsoft.Xna.Framework;
using Sprint0.Sprites;

namespace FirstGame
{
    class JumpingBlock: AnimatedSprite
    {


        public JumpingBlock()
        {
            JumpDirection = -1;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                if (this.Entity.Position.Y < Top.Y)
                {
                    JumpDirection = 1;
                }
                else if (this.Entity.Position.Y == Ground.Y && JumpDirection == 1)
                {
                    JumpDirection = 0;
                }
                this.Entity.Position = new Vector2(this.Entity.Position.X, this.Entity.Position.Y + JumpDirection);
            }
        }
    }
}
