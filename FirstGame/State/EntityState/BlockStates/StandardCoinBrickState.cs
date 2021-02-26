using Sprint0.Game_Enities.Blocks;
using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities;

namespace Sprint0.State.BlockStates
{
    class StandardCoinBrickState : IBlockState, IState
    {
        public IBlockEntity Block { get; set; }
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }



        public StandardCoinBrickState(Game1 g, IBlockEntity b)
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

        public void UsedTransition()
        {

        }
        public void Update(GameTime time)
        {
            //NOT IMPLEMENTED
        }
        

    }
}