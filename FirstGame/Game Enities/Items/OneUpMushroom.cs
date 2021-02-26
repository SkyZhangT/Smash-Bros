using FirstGame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Game_Enities.Items
{
    public class OneUpMushroom : ItemEntity
    {
        public OneUpMushroom(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position, Velocity)
        {
            this.Visible = true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Gravity);
            this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);
            this.HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 2);
            base.UpdateEntity(gameTime);
            this.CurrentSprite.UpdateSprite(gameTime);
            
            CollisionHandling.Update(this, this.Position);
            CollisionHandling.DidCollide(this, gameTime);
        }
    }
}
