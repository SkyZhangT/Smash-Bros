using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.BlockStates;
using Sprint0.Collision;

namespace Sprint0.Game_Enities.Blocks
{
    class BrickFragEntity : BlockEntity
    {

        public BrickFragEntity(Game1 game, string name, Vector2 position, Vector2 velocity, Vector2 tPosition) :base(game, name, position, tPosition)
        {
            CurrentSprite = BlockFactory.AllBlockFactory(game, name);
            Gravity = 0.06f;
            Velocity = velocity;
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Gravity);
            this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);
        }
    }
}
