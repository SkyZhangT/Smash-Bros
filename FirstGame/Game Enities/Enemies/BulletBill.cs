using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Avatar;

namespace Sprint0.Game_Enities.Enemies
{
    class BulletBill : EnemyEntity
    {

        //int Height { get; set; }
        public override void Initialize()
        {
            base.Initialize();
        }

        public BulletBill(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity, IEntity PlayerNumber) : base(game, initialSprite, Position, Velocity)
        {
            this.Game = game;
            this.Visible = true;
            //this.Height = 300;
            base.Initialize();
            this.Master = PlayerNumber;
            this.FacingRight = false;
            if (this.Master is MarioAvatar)
            {
                if (this.Master.Name is "Mario")
                    Indicator = Color.Lerp(Color.White, Color.Red, .4f);
                else
                    Indicator = Color.Lerp(Color.White, Color.Green, .4f);
            }
            else
            {
                Indicator = Color.Lerp(Color.White, Color.Blue, .4f);
            }
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            this.HitBox = new Rectangle((int)Position.X+10, (int)Position.Y+15, CurrentSprite.FrameSize.X-10, CurrentSprite.FrameSize.Y-30);
            PositionOrigin = this.Position;
            Position = new Vector2(Position.X-.5f, Position.Y);
            CollisionHandling.Update(this, PositionOrigin);
            if (Position.X+320 < 0)
            {
                this.Visible = false;
                if (this == this.Game.CurrentScene.ThwompItem)
                {
                    this.Game.CurrentScene.ThwompItem = null;
                }
            }
        }
    }
}
