using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class DeadEnemy : IState
    {
        // private bool LeftFacing {get;set;}
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }
        private int TimeSinceHit = 0;
        public DeadEnemy(IEntity entity)
        {
            this.Entity = entity;
            int oldFrame;
            if (Entity.CurrentSprite.CurrentFrame.Y == 1)
            {
                if (Entity.CurrentSprite.CurrentFrame.X < 3)
                {
                    oldFrame = 6;
                }
                else if (Entity.CurrentSprite.CurrentFrame.X < 6)
                {
                    oldFrame = 7;
                }
                else if(Entity.CurrentSprite.CurrentFrame.X < 9)
                {
                    oldFrame = 8;
                }
                else
                {
                    oldFrame = 11;
                }
            }
            else
            {
                if (Entity.CurrentSprite.CurrentFrame.X < 3)
                {
                    oldFrame = 9;
                }
                else
                {
                    oldFrame = 10;
                }
            }
            StaticSprite flippedGoomba = new StaticSprite
            {
                Texture = Entity.CurrentSprite.Texture,
                CurrentFrame = new Point(oldFrame, 0),
                SheetSize = new Point(12, 2),
                FrameSize = new Point(18, 26)
            };
            Entity.CurrentSprite = flippedGoomba;
        }
        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle(-1, -1, -1, -1);
            TimeSinceHit += time.ElapsedGameTime.Milliseconds;
            if (TimeSinceHit > 3000)
            {
                Entity.Visible = false;
            }
            Entity.Gravity = 0.4f;

        }

    }
}
