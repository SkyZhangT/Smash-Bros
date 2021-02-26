using Sprint0.Game_Enities.Blocks;
using FirstGame;
using System;
using Sprint0.Game_Enities;
using Microsoft.Xna.Framework;

namespace Sprint0.State.BlockStates
{
    public interface IBlockState
    {
        IBlockEntity Block { get; set; }
        Game1 Game { get; set; }
        void StandardTransition();
        void BumpTransition(IEntity entity, GameTime time);
        void UsedTransition();
    }
}
