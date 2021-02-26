using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.State.EnemyStates
{
    class AliveKoopa : IState
    {
        //private bool LeftFacing { get; set; }
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }

        public AliveKoopa(IEntity entity)
        {
            this.Entity = entity;
        }

        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle((int)Entity.Position.X+3, (int)Entity.Position.Y+9, Entity.CurrentSprite.FrameSize.X-6, Entity.CurrentSprite.FrameSize.Y-10);
        }
    }
}
