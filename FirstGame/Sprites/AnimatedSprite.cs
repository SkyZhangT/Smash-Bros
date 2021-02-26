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
    public abstract class AnimatedSprite : ISprite
    {
        /*Temporary var until a better way to update entity positions can be found */
        public IEntity Entity { get; set; }

        public Texture2D Texture { get; set; }
        public Point SheetSize { get; set; }
        public Point FrameOrigin { get; set; }
        public Point FrameSize { get; set; }
        public Point CurrentFrame { get; set; }
        public int AnimationFrame { get; set; }
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }

        /*Temporary until collision detection */
        public Vector2 Ground { get; set; }
        public Vector2 Top { get; set; }
        public int JumpDirection { get; set; }

        public bool NeedFlip { get; set; }
        public int Iterator { get; set; }

        public abstract void UpdateSprite(GameTime gameTime);
    }
}
