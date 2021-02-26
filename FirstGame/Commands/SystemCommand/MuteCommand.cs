using Sprint0.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    //This command is not used yet, so warnings about it are supressed
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    class MuteCommand : ICommand
    {
        public void Execute()
        {
            SoundManager.Mute();
        }

        public void Undo()
        {
           // SoundManager.Mute();
        }
    }
}
