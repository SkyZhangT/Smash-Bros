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
    class Fish : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private float Ground;
        private float mvmnt { get; set; }
        private Vector2 Velocity { get; set; }
        public Fish(IEntity entity,float move)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Ground = Entity.Position.Y;
            mvmnt = move;
            Velocity = new Vector2(1, mvmnt);
        }
        public void Update(GameTime time)
        {
            Velocity = new Vector2(mvmnt, Velocity.Y -.04f);
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            if (Entity.Position.Y >= Ground+32)
            {
                Velocity=new Vector2(1,mvmnt);
            }
            Entity.Position = new Vector2(Entity.Position.X+Velocity.X,Entity.Position.Y-Velocity.Y);
            if (Entity.Position.X > 1000)
            {
                Entity.Visible = false;
            }
        }

    }
}
