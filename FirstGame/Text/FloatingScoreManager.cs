using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Indicators.Instants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Text
{
    public sealed class FloatingScoreManager : IDisposable
    {
        private SpriteBatch SpriteBatch { get; set; }
        private Texture2D RecTex;
        private Game1 Game { get; set; }
        public Collection<FloatingScore> FloatingScores { get; }
        public int Multiplier { get => multiplier; set => multiplier = value; }

        private int MultiplierTimer = 0;
        private int multiplier = 1;
        SpriteFont Font;
       
        public FloatingScoreManager(SpriteBatch batch, Game1 game)
        {
            this.SpriteBatch = batch;
            FloatingScores = new Collection<FloatingScore>();
            RecTex = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            RecTex.SetData(new[] { Color.White });
            Game = game;
            Font = game.Content.Load<SpriteFont>("HUD/Arial");
        }

        public void Addfloatingscore(FloatingScore floatingscore)
        {
            FloatingScores.Add(floatingscore);
        }

        public void Removefloatingscore(FloatingScore floatingscore)
        {
            FloatingScores.Remove(floatingscore);
        }

        

        public void DrawfloatingScores()
        {
            for (int i = 0; i < this.FloatingScores.Count; i++)
            {
                FloatingScore floatingscore = this.FloatingScores[i];
                if (floatingscore.IsVisible)
                {
                    SpriteBatch.DrawString(Font, floatingscore.Text.ToString(),floatingscore.Position - Game.CurrentScene.Camera.Position, Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
                }

            }

        }

        public void UpdatefloatingScores(GameTime gameTime)
        {

            List<FloatingScore> deadfloatingscore = new List<FloatingScore>();
            for (int i = 0; i < this.FloatingScores.Count; i++)
            {
                FloatingScore floatingscore = this.FloatingScores[i];
                floatingscore.Update(gameTime);
                if (!floatingscore.IsVisible)
                {
                    
                        deadfloatingscore.Add(floatingscore);
                    
                }
            }
            foreach (FloatingScore floatingscore in deadfloatingscore)
            {
                Removefloatingscore(floatingscore);
            }
            if (MultiplierTimer < gameTime.TotalGameTime.Minutes * 60 + gameTime.TotalGameTime.Seconds)
            {
                Multiplier = 1;
            }
        }

        public void UpdateMultiplier(GameTime time)
        {
            Multiplier += 1;
            MultiplierTimer = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 1;
        }
       

        //Here to fix warning
        public void Dispose()
        {

            RecTex.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
