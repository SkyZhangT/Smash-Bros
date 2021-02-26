using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators.Instants
{
    public class FloatingScore
    {
        private static readonly float TOTAL_TIME_MILLIS = 1500;
        private static readonly float TIME_INTERVAL = 20;
        private float TimeElapsed;
        private float TotalTimeElapsed;
        private bool Visible;
       public Vector2 Position { get; set; }
        public String Text { get; set; }

        public FloatingScore(Vector2 pos, String text)
        {
            TotalTimeElapsed = 0;
            this.Text = text;
            this.Visible = true;
            this.Position=pos;
            TimeElapsed = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (Visible)
            {
                TimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                TotalTimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeElapsed >= TIME_INTERVAL)
                {
                    TimeElapsed = 0;
                    this.Position=(new Vector2(this.Position.X, this.Position.Y - 1));
                }

                if (TotalTimeElapsed >= TOTAL_TIME_MILLIS)
                {
                    this.Visible = false;
                }
            }
        }


        public bool IsVisible => Visible;

       
    }
}
