using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Collision;

namespace Sprint0.Game_Enities.Enemies
{
    class Thwomp : EnemyEntity
    {

        //int Height { get;set;}
        //public int Player { get; set; }
        public override void Initialize()
        {
            base.Initialize();
        }

        public Thwomp(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity, int player) : base(game, initialSprite, Position, Velocity)
        {
            this.Game = game;
            this.Visible = true;
            //this.Height = this.CurrentSprite.FrameSize.Y;
            this.ActionState = new ThwompUp(this, player, Game);
            //Player = player;
            this.Collision = new EnemyCollision(this);
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            PositionOrigin = this.Position;
            ActionState.Update(gameTime);
            CollisionHandling.Update(this, PositionOrigin);
            CollisionHandling.DidCollide(this, gameTime);
            CurrentSprite.UpdateSprite(gameTime);
        }
    }
}
