using FirstGame;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Game_Enities.Items
{
    public class FireFlower:ItemEntity
    {
        public FireFlower(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position, Velocity)
        {
            this.Visible = true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            this.CurrentSprite.UpdateSprite(gameTime);
        }
    }
}
