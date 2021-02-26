using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.BlockStates;
using Sprint0.Collision;

namespace Sprint0.Game_Enities.Blocks
{
    public class HiddenBlockEntity : BlockEntity
    {
        private bool rise;
        private float ground;

        protected bool Rise { get => rise; set => rise = value; }
        protected float Ground { get => ground; set => ground = value; }

        public override void Initialize()
        {
            Collision = new BlockCollision(this);
            CurrentState = new HiddenBoxState(Game, this);
        }

        public HiddenBlockEntity(Game1 game, string name, Vector2 Position, int c, Vector2 tPosition) : base(game, name, Position, tPosition)
        {
            CoinLeft = c;
            Visible = false;
            Rise = true;
            Ground = Position.Y;
        }
        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            CurrentState.StandardTransition();
            if(CoinLeft == -1)
            {
                if (Name == "Rising" && Rise == true)
                {
                    Position = new Vector2(Position.X, Position.Y - 2);
                    if (Position.Y <= Ground - 5)
                        Rise = false;
                }
                else if (Name == "Rising" && Rise == false)
                {
                    CurrentState = new StaticBlockState(Game, this);
                }
            }
        }
    }
}