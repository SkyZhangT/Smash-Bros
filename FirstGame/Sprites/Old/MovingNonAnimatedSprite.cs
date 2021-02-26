using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class MovingNonAnimatedSprite : ISprite
    {

        public bool Visible { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Point SheetSize { get; set; }
        public Point FrameOrigin { get; set; }
        public Point FrameSize { get; set; }
        public Point CurrentFrame { get; set; }
        public int AnimationFrame { get; set; }
        public int TimeSinceLastFrame { get; set; }
        public int MillisecondsPerFrame { get; set; }
        public int MillisecondsPerMove { get; set; }
        public int TimeSinceLastMove { get; set; }
        public int Frame_direction { get; set; }

        private GraphicsDevice GraphicsDevice;
        private int Direction;

        public Vector2 Ground { get; set; }
        public Vector2 Top { get; set; }

        public int LeftDirection { get; set; }
        public int JumpDirection { get; set; }
        public int FrameDirection { get; set; }
        public bool NeedFlip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MovingNonAnimatedSprite(GraphicsDevice graphicsDevice)
        {
            this.GraphicsDevice = graphicsDevice;
            Direction = -1;
            AnimationFrame = 0;
            this.Visible = false;
            this.TimeSinceLastMove = 0;
        }

        public void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastMove += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastMove > MillisecondsPerMove)
            {
                TimeSinceLastMove -= MillisecondsPerMove;
                
                if (this.Position.Y >= (this.GraphicsDevice.Viewport.Height-this.FrameSize.Y))     // Check if sprite is a bottom of screen
                {
                    Direction = -1;
                } else if(this.Position.Y <= 0)
                {
                    Direction = 1;
                }
                this.Position = new Vector2(this.Position.X, this.Position.Y + (Direction * 10));

            }
        }
    }
}
