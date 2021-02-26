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
    class ThwompUp : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        //private float Ground;
        private int delay;
        private int Time;
        private int Player;
        public ThwompUp(IEntity entity, int player, Game1 game)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            this.delay = 3000;
            Time = 0;
            Player = player;
            Game = game;
        }
        public void Update(GameTime time)
        {

            Entity.HitBox = new Rectangle((int)Entity.Position.X, (int)Entity.Position.Y, Entity.CurrentSprite.FrameSize.X, Entity.CurrentSprite.FrameSize.Y);
            Time += time.ElapsedGameTime.Milliseconds;
            if (Time > delay)
            {
                Entity.ActionState = new ThwompDown(Entity, Game);
            }
            else if (Player == 1)
            {
                if (Entity.Game.CurrentScene.PlayerAvatar2.Position.X > Entity.Position.X)
                {
                    Entity.Position = new Vector2(Entity.Position.X + 1, Entity.Position.Y);
                }
                else if(Entity.Game.CurrentScene.PlayerAvatar2.Position.X < Entity.Position.X)
                {
                    Entity.Position = new Vector2(Entity.Position.X - 1, Entity.Position.Y);
                }
            }
            else
            {
                if (Entity.Game.CurrentScene.PlayerAvatar.Position.X > Entity.Position.X)
                {
                    Entity.Position = new Vector2(Entity.Position.X + 1, Entity.Position.Y);
                }
                else if(Entity.Game.CurrentScene.PlayerAvatar.Position.X < Entity.Position.X)
                {
                    Entity.Position = new Vector2(Entity.Position.X - 1, Entity.Position.Y);
                }
                
            }
            

        }

    }
}
