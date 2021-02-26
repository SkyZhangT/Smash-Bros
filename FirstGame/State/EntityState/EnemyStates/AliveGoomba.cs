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
    class AliveGoomba : IState
    {
       // private bool LeftFacing {get;set;}
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }


        public AliveGoomba(IEntity entity)
        {
            this.Entity = entity;
         //   LeftFacing = true;
        }
        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle((int)Entity.Position.X + 2, (int)Entity.Position.Y + 11, Entity.CurrentSprite.FrameSize.X - 4, Entity.CurrentSprite.FrameSize.Y -12);
            
        }

    }
}
