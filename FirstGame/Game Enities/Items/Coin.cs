using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;

namespace Sprint0.Game_Enities.Items
{
    public class Coin : ItemEntity
    {
        public Coin(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position,Velocity)
        {
            this.Visible = true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            float previeusV = this.Velocity.Y;
            this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Gravity);
            if (this.Velocity.Y * previeusV < 0)
            {
                this.Visible = false;
            }
            this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);
            this.HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 2);
            base.UpdateEntity(gameTime);
            this.CurrentSprite.UpdateSprite(gameTime);

            CollisionHandling.Update(this, this.Position);
            CollisionHandling.DidCollide(this, gameTime);
        }

        //Bump is not used yet
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "gameTime")]
       // public void Bump(GameTime gameTime)
       // {

      //  }
    }
}
