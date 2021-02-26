using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Enemies;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class FireBallState : IState
        {
        public Game1 Game { get; set; }
        public Fireball realEntity { get; set; }
        public IEntity Entity { get; set; }
        public int timeSinceLast = 0;

        public FireBallState(IEntity entity)
        {
            this.Entity = entity;
            this.realEntity = (Fireball)entity;
        }
        public void Update(GameTime time)
        {
            timeSinceLast += time.ElapsedGameTime.Milliseconds;
            if (timeSinceLast > 100)
            {
                realEntity.BounceCount -= 1;
            }
        }

    }
}
