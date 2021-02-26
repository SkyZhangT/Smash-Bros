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
    class ThwompDown : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private float Ground;
        public ThwompDown(IEntity entity, Game1 game)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Ground = Entity.Position.Y + 400;
            Entity.CurrentSprite.CurrentFrame = new Point(1, 0);
            Game = game;
        }
        public void Update(GameTime time)
        {
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Entity.Position = new Vector2(Entity.Position.X, Entity.Position.Y + 3);
            if (Entity.Position.Y >Ground /*Game.CurrentScene.FirstBottomRightBoundary.Y+300*/)
            {
                Entity.Visible = false;
                if(Entity == Entity.Game.CurrentScene.ThwompItem)
                {
                    Entity.Game.CurrentScene.ThwompItem = null;
                }
            }

        }

    }
}
