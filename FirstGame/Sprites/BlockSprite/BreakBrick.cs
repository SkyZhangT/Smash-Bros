using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities;
using Sprint0.Sprites;

namespace FirstGame
{
    class BreakBrick : AnimatedSprite
    {
        bool exist;
        public BreakBrick()
        {
            JumpDirection = 1;
            exist = true;
            TimeSinceLastFrame = 0;
        }

        public override void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (exist)
            {
                if (TimeSinceLastFrame > MillisecondsPerFrame)
                {
                    TimeSinceLastFrame -= MillisecondsPerFrame;
                    if (CurrentFrame.X == 1)
                    {
                        CurrentFrame = new Point(CurrentFrame.X + 1, CurrentFrame.Y);
                    }
                    else
                    {
                        exist = false;
                    }
                }
            }
            else
            {
                IEntity Frag1 = new BrickFragEntity(this.Entity.Game, "Frag", this.Entity.Position, new Vector2(0.8f, -1.4f), new Vector2(0, 0));
                IEntity Frag2 = new BrickFragEntity(this.Entity.Game, "Frag", this.Entity.Position, new Vector2(-0.8f, -1.4f), new Vector2(0, 0));
                IEntity Frag3 = new BrickFragEntity(this.Entity.Game, "Frag", this.Entity.Position, new Vector2(1.5f, -0.7f), new Vector2(0, 0));
                IEntity Frag4 = new BrickFragEntity(this.Entity.Game, "Frag", this.Entity.Position, new Vector2(-1.5f, -0.7f), new Vector2(0, 0));
                this.Entity.Game.EntityManager.AddEntity(Frag1);
                this.Entity.Game.EntityManager.AddEntity(Frag2);
                this.Entity.Game.EntityManager.AddEntity(Frag3);
                this.Entity.Game.EntityManager.AddEntity(Frag4);

                this.Entity.Visible = false;
            }
        }
    }
}
