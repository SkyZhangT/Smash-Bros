using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame
{
    class MovingAnimatedSprite : ISprite
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
        public int FrameDirection { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool NeedFlip { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public MovingAnimatedSprite(GraphicsDevice graphicsDevice)
        {
            this.GraphicsDevice = graphicsDevice;
            Direction = 1;
            AnimationFrame = 0;
            Frame_direction = 1;

            this.Visible = false;
            this.TimeSinceLastMove = 0;
        }

        public void UpdateSprite(GameTime gameTime)
        {
            TimeSinceLastMove += gameTime.ElapsedGameTime.Milliseconds;

            if (TimeSinceLastMove > MillisecondsPerMove)
            {
                TimeSinceLastMove -= MillisecondsPerMove;

                if (this.Position.X >= (this.GraphicsDevice.Viewport.Width-this.FrameSize.X))     // Check if sprite is at right of screen
                {
                    Direction = -1;
                }

                else if (this.Position.X <= 0)
                {
                    Direction = 1;
                }

                this.Position = new Vector2(this.Position.X + (Direction * 10), this.Position.Y);
            }

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

                AnimationFrame = AnimationFrame + Frame_direction * 1;

                CurrentFrame = new Point(AnimationFrame % SheetSize.X, AnimationFrame / SheetSize.X);
            }
        }
    }
}
