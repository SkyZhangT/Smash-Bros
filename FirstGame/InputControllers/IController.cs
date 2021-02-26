using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    public interface IController
    {
        List<Input> GetInput();
        void UpdateInput(Game1 game);
    }
}
