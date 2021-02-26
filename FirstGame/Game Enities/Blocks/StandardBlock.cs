using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.BlockStates;
using Sprint0.Collision;

namespace Sprint0.Game_Enities.Blocks
{
    class StandardBlock:BlockEntity
    {
        protected bool Rise;
        protected float Ground;

        public override void Initialize()
        {
            Collision = new BlockCollision(this);
            if (CoinLeft==1) {
                CurrentState = new StandardCoinBoxState(Game, this);
            }
            else if(CoinLeft > 1)
            {
                CurrentState = new StandardCoinBrickState(Game, this);
            }
            else if(CoinLeft == -1 && Name == "Brick")
            {
                CurrentState = new StandardBrickState(Game, this);
            }
        }

        public StandardBlock(Game1 game, string name, Vector2 Position, int coin, string itemtype, Vector2 tPosition) : base(game, name, Position, tPosition)
        {
            this.CoinLeft = coin;
            this.ItemType = itemtype;
            Rise = true;
            Ground = Position.Y;
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            CurrentState.StandardTransition();
            if (CoinLeft == -1)
            {
                if (Name == "Rising" && Rise == true)
                {
                    Position = new Vector2(Position.X, Position.Y - 4);
                    if (Position.Y <= Ground - 3)
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
