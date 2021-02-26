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
    class InjuredGoomba:IState
    {
        public IEntity Entity { get; set; }
       // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private int ElapsedTime = 0;
        public InjuredGoomba(IEntity entity)
        {
            this.Entity = entity;
            int oldFrame = Entity.CurrentSprite.CurrentFrame.X + 2;
            if (oldFrame >= 8)
            {
                oldFrame = 8;
            }
            else if (oldFrame >= 5)
            {
                oldFrame = 5;
            }
            else
            {
                oldFrame = 2;
            }
            StaticSprite flattenedGoomba = new StaticSprite
            {
                Texture = Entity.CurrentSprite.Texture,
                CurrentFrame = new Point(oldFrame, 1),
                SheetSize = new Point(11, 2),
                FrameSize = new Point(18, 26)
            };
            Entity.CurrentSprite = flattenedGoomba;
        }
        
        public void Update(GameTime time)
        {
            ElapsedTime += time.ElapsedGameTime.Milliseconds;
            Entity.HitBox = new Rectangle(-1, -1, -1, -1);
            if (ElapsedTime>2000)
            {
                Entity.Visible = false;
            }

        }

    }
}
