using Sprint0.Game_Enities.Blocks;
using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities;

namespace Sprint0.State.BlockStates
{
    class StandardCoinBoxState : IBlockState, IState
    {
        public IBlockEntity Block { get; set; }
        public IEntity Entity { get; set; }

        public Game1 Game { get; set; }


        public StandardCoinBoxState(Game1 g, IBlockEntity b)
        {
            this.Entity = b;
            Game = g;
            b.CurrentSprite = BlockFactory.AllBlockFactory(g, b.Name);
            b.CurrentSprite.Entity = b;
            Block = b;
            Block.HitBox = new Rectangle((int)Block.Position.X, (int)Block.Position.Y, Block.CurrentSprite.FrameSize.X, Block.CurrentSprite.FrameSize.Y);
        }

        public void StandardTransition()
        {

        }

        public void BumpTransition(IEntity cause, GameTime time)
        {
            
            Block.CurrentState = new BumpState(Game, Block,time);
            Block.CoinLeft--;

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void BreakTransition()
        {
            //Not implemented
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
