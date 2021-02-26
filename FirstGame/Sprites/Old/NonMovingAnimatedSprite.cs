using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame
{
    class NonMovingAnimatedSprite : ISprite
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
        public int MillisecondsPerMove { get; set ; }
        public int TimeSinceLastMove { get; set ; }
        public Vector2 Ground { get; set; }
        public Vector2 Top { get; set; }
        public int LeftDirection { get; set; }
        public int JumpDirection { get; set; }
        public int Frame_direction { get; set; }
        public int FrameDirection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool NeedFlip { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NonMovingAnimatedSprite()
        {
            AnimationFrame = 0;
            this.Visible = false;
            this.TimeSinceLastFrame = 0;
            Frame_direction = 1;
        }
        public void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                
                if (AnimationFrame == SheetSize.X * SheetSize.Y - 1)     // Upper Limit Check
                {
                    Frame_direction = -1;
                }else if (AnimationFrame == 0)
                {
                    Frame_direction = 1;
                }

                AnimationFrame += Frame_direction * 1;

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }  
    }
}
