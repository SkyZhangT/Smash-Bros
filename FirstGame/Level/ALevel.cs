using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    public abstract class ALevel
    {
        public Vector2 BottomRightBoundary { get; set; }
        public Vector2 BottomRightBoundary2 { get; set; }
        internal Game1 Game { get; set; }
        internal EntityManager EntityManager { get; set; }
        internal List<IEntity> ItemEnemyBlockList { get; set; }
        internal List<float> CheckPoints { get; set; }
        public abstract void LoadFile();
        public abstract void LoadEntity();
        public abstract void ResetLevel();
        public abstract void ResetAvator(float positionX);

        internal List<IBlockEntity> FloorList { get; set; }
    }
}
