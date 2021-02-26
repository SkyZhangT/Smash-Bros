using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.BlockStates;
using Sprint0.Collision;
using System;

namespace Sprint0.Game_Enities.Blocks
{
    public class FloorBlock : BlockEntity, IBlockEntity
    {
     
        public FloorBlock(Game1 game, string name, Vector2 position, Vector2 tPosition) : base(game, name, position, tPosition)
        {

        }
        public void ChangeSize(Point size)
        {
            this.CurrentSprite.FrameSize = size;
        }

        
    }
}
