using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    public interface IState
    {
        Game1 Game { get; set; }
        IEntity Entity { get; set; }
        void Update(GameTime gameTime);
    }
}
