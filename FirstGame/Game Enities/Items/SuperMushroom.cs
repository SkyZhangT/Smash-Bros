using FirstGame;
using Microsoft.Xna.Framework;
using System;

namespace Sprint0.Game_Enities.Items
{
    public  class SuperMushroom : ItemEntity
    {
        private int dir;
        public SuperMushroom(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position,Velocity)
        {
            Random rand = new Random();
            dir = rand.Next(-1, 1);
            this.Visible = true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            if (Velocity.X != 0)
            {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Gravity);
                this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y/5f);
            }
            else
                this.Position = new Vector2(this.Position.X +dir, this.Position.Y);
            this.HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 2);
            base.UpdateEntity(gameTime);
            this.CurrentSprite.UpdateSprite(gameTime);
        }
    }
}
