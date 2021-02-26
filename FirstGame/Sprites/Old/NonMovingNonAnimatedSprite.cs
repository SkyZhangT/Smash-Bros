using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstGame
{
    class NonMovingNonAnimatedSprite : ISprite
    {
        public bool Visible { get; set; }
        public Vector2 Position { get ; set; }
        public Texture2D Texture { get ; set; }
        public Point SheetSize { get; set; }
        public Point FrameOrigin { get; set; }
        public Point FrameSize { get; set; }
        public Point CurrentFrame { get; set; }
        public int AnimationFrame { get; set; }
        public int TimeSinceLastFrame { get ; set; }
        public int MillisecondsPerFrame { get  ; set ; }
        public int MillisecondsPerMove { get; set ; }
        public int TimeSinceLastMove { get; set ; }
        public Vector2 Ground { get; set; }
        public Vector2 Top { get; set; }
        public int LeftDirection { get; set; }
        public int JumpDirection { get; set; }
        public int Frame_direction { get; set; }
        public int FrameDirection { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool NeedFlip { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public NonMovingNonAnimatedSprite()
        {
            AnimationFrame = 0;
            this.Visible = false; 
        }

        public void UpdateSprite(GameTime gameTime)
        {

        }
    }
}
