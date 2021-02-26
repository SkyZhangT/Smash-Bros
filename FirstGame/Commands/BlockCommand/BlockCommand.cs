using FirstGame;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Blocks;
using System;

namespace Sprint0.Commands
{
    //BlockCommand does not have any use anymore
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    class BlockCommand : ICommand
    {
        //private IBlockEntity Block;
        //Suppressed because this is now obsolete
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "block")]
        public BlockCommand(IBlockEntity block)
        {
          //  Block=block;
        }
        public void Execute()
        {
           // Block.CurrentState.BumpTransition((IEntity)Game1.PlayerAvatar);
        }

        public void Undo()
        {
            //throw new NotImplementedException();
        }
    }
}
