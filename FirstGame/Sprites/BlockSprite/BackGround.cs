using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.BlockSprite
{
    class BackGround
    {
        public Texture2D Texture { get; set; }
        public Texture2D Texture2 { get; set; }
        public Texture2D CurrentTexture { get; set; }

        public int CurrentFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }
        public BackGround(Texture2D texture, Texture2D texture2)
        {
            this.Texture = texture;
            CurrentTexture = texture;
            this.CurrentFrame = 1;
            this.Texture2 = texture2;
        }

        public void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > 300)
            {
                if (CurrentFrame == 1)
                {
                    CurrentFrame = 0;
                    CurrentTexture = Texture;

                }
                else
                {
                    CurrentFrame = 1;
                    CurrentTexture = Texture2;
                }
                TimeSinceLastFrame = 0;
            }
        }
         
    }
}
