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
    class InjuredKoopa : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        public InjuredKoopa(IEntity entity)
        {
            this.Entity = entity;
            int oldFrame = Entity.CurrentSprite.CurrentFrame.X - 2;
            if (oldFrame <= 0)
            {
                oldFrame = 0;
            }
            else
            {
                oldFrame = 3;
            }
            StaticSprite koopaShell = new StaticSprite
            {
                Texture = Entity.CurrentSprite.Texture,
                CurrentFrame = new Point(oldFrame, 0),
                SheetSize = new Point(9, 2),
                FrameSize = new Point(18, 26)
            };
            Entity.CurrentSprite = koopaShell;
        }
        
        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle((int)Entity.Position.X+1, (int)Entity.Position.Y + 15, Entity.CurrentSprite.FrameSize.X-2, 10);
        }

    }
}
