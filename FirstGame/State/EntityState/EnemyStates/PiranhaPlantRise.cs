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
    class PiranhaPlantRise : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private float Ground;
        private int delay;
        private int Time;
        public PiranhaPlantRise(IEntity entity)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Ground = Entity.Position.Y;
            this.delay = 200;
            Time = 0;
        }
        public void Update(GameTime time)
        {
            
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            if (Ground - Entity.Position.Y <=22)
            {
                Entity.Position = new Vector2(Entity.Position.X, Entity.Position.Y - 1);
            }
            else
            {
                Time += time.ElapsedGameTime.Milliseconds;
                if (Time > delay)
                {
                    Entity.ActionState = new PiranhaPlantFall(Entity);
                }
            }

        }

    }
}
