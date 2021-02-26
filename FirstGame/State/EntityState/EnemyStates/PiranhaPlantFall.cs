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
    class PiranhaPlantFall : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private float Ground;
        public PiranhaPlantFall(IEntity entity)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Ground = Entity.Position.Y+23;
        }
        public void Update(GameTime time)
        {

            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            if (Ground - Entity.Position.Y >= 1)
            {
                Entity.Position = new Vector2(Entity.Position.X, Entity.Position.Y + 1);
            }
            else
            {
                Entity.Position = new Vector2(Entity.Position.X, Ground);
                Entity.ActionState = new PiranhaPlantHidden(Entity);
            }

        }

    }
}
