using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class MovingShell : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        public MovingShell(IEntity entity)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y + 14, Entity.CurrentSprite.FrameSize.X, 10);
        }
        
        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle((int)Entity.Position.X+1, (int)Entity.Position.Y + 16, Entity.CurrentSprite.FrameSize.X-2, 11);
            Entity.Gravity = 0.04f;
        }

    }
}
