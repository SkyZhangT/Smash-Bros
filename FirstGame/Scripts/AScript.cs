using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Scripts
{
    public abstract class AScript
    {
        private bool doneFlag = false;

        public bool DoneFlag { get => doneFlag; set => doneFlag = value; }

        public abstract void Update(GameTime time);
    }
}
