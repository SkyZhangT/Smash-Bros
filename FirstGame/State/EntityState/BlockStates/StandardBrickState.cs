using Sprint0.Game_Enities.Blocks;
using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Enemies;
using Sprint0.Sounds;

namespace Sprint0.State.BlockStates
{
    public class StandardBrickState:IBlockState, IState
    {
        public IBlockEntity Block { get; set; }
        public Game1 Game { get; set; }
        public IEntity Entity { get; set; }

        public StandardBrickState(Game1 g, IBlockEntity b)
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
            if(cause is Koopa||cause is Thwomp)
            {
                Block.Name = "Rising";
                SoundManager.PlaySound("break");
            }
            else
            {
                if (cause.CurrentPowerState is FireMarioPowerUpState || cause.CurrentPowerState is SuperMarioPowerUpState)
                {
                    Block.Name = "Rising";
                    SoundManager.PlaySound("break");
                }
                else if (cause.CurrentPowerState is SmallMarioPowerUpState)
                {
                    Block.CurrentState = new BumpState(Game, Block, time);
                }
            }
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
