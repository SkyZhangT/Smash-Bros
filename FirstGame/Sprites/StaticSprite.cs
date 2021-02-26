using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
   public class StaticSprite : ISprite
    {
       public Texture2D Texture { get; set; }
        public IEntity Entity { get; set; }
        public Point SheetSize { get; set; }
        public Point FrameSize { get; set; }
        public  Vector2 Ground { get; set; }
        public  Vector2 Top { get; set; }
        public   int JumpDirection { get; set; }
        public   bool NeedFlip { get; set; }
        public Point CurrentFrame { get; set; }

        public void UpdateSprite(GameTime gameTime) { }
    }
}
