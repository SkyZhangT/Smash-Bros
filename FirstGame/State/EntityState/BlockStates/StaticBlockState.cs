using Sprint0.Game_Enities.Blocks;
using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities;

namespace Sprint0.State.BlockStates
{
    public class StaticBlockState:IBlockState, IState
    {
        public IBlockEntity Block { get; set; }
        public IEntity Entity { get; set; }

        public Game1 Game { get; set; }


        public StaticBlockState(Game1 g, IBlockEntity b)
        {
            this.Entity = b;
            Game = g;
            if (b.CoinLeft == 0 || b.Name=="CoinBox")
            {
                b.CurrentSprite = BlockFactory.AllBlockFactory(g, "EmptyBox");
            }
            else if((b.Name == "Brick" && b.CoinLeft == -1)|| b.Name == "Rising")
            {
                b.CurrentSprite = BlockFactory.AllBlockFactory(g, "BreakBrick");
                b.Name = "BreakBrick";
            }
            else
            {
                b.CurrentSprite = BlockFactory.AllBlockFactory(g, b.Name);
            }
            b.CurrentSprite.Entity = b;
            Block = b;
            Block.HitBox = new Rectangle((int)Block.Position.X, (int)Block.Position.Y, Block.CurrentSprite.FrameSize.X, Block.CurrentSprite.FrameSize.Y);
        }

        public void StandardTransition()
        {

        }

        public void BumpTransition(IEntity cause, GameTime time)
        {

        }

        public void UsedTransition()
        {

        }
        public void Update(GameTime time)
        {
            //NOT IMPLEMENTED
        }
        

    }
}
