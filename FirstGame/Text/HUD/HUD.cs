using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sounds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Sprint0.Indicators;

namespace Sprint0.HUDD
{
    public class HUD
    {
        private Game1 Game { get; set; }
        //private int Width { get; set; }

        private readonly SpriteFont Font;
        //private string World;
        private ISprite Avatar { get; set; }
        private ISprite Coin { get; set; }
    
        
        public HUD(Game1 game)
        {
           // Width = 560;
            Game = game;
            //World = "1-1";
            Font = game.Content.Load<SpriteFont>("HUD/Arial");
            
            Avatar = MarioFactory.SmallMarioFacingRightFactory(game);
            Coin = ItemFactory.CreateSprite(game, "Coin");
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //display charge bar
            Rectangle charger1 = new Rectangle(51, 302, Game.CurrentScene.IndicatorManager.Value("charger"), 6);
            Rectangle charger2 = new Rectangle(451, 302, Game.CurrentScene.IndicatorManager2.Value("charger"), 6);
            int width1 = Game.CurrentScene.IndicatorManager.Value("charger");
            int width2 = Game.CurrentScene.IndicatorManager2.Value("charger");
            if (width1 > 4)
            {
                width1 = 4;
            }
            if (width2 > 4)
            {
                width2 = 4;
            }
            Game.EntityManager.DrawHitBox(charger1, width1, Color.Yellow);
            Game.EntityManager.DrawHitBox(charger2, width2, Color.Yellow);
            Rectangle chargerBoundary1 = new Rectangle(50, 300, 52, 10);
            Rectangle chargerBoundary2 = new Rectangle(450, 300, 52, 10);
            Game.EntityManager.DrawHitBox(chargerBoundary1, 2, Color.Black);
            Game.EntityManager.DrawHitBox(chargerBoundary2, 2, Color.Black);

            int r1 = 255;
            int r2 = 255;
            int g1 = 255;
            int g2 = 255;
            int b1 = 255;
            int b2 = 255;

            if (this.Game.CurrentScene.IndicatorManager.Damage.Value() > 2)
            {
                r1 = (int)(255 -((uint)(this.Game.CurrentScene.IndicatorManager.Damage.Value()/2)));
                g1 = (int)(255 -((uint)this.Game.CurrentScene.IndicatorManager.Damage.Value()*1.5));
                b1 = (int)(255 - ((uint)this.Game.CurrentScene.IndicatorManager.Damage.Value()*1.5));
            }

            if (this.Game.CurrentScene.IndicatorManager2.Damage.Value() >2)
            {
                r2 = (int)(255 - ((uint)(this.Game.CurrentScene.IndicatorManager2.Damage.Value()/2)));
                g2 = (int)(255 - ((uint)this.Game.CurrentScene.IndicatorManager2.Damage.Value()*1.5));
                b2 = (int)(255 - ((uint)this.Game.CurrentScene.IndicatorManager2.Damage.Value()*1.5));
            }

            if(r1 < 100)
            {
                r1 = 100;
            }
            if (r2 < 100)
            {
                r2 = 100;
            }
            if (g1 < 50)
            {
                g1 = 50;
            }
            if (g2 < 50)
            {
                g2 = 50;
            }
            if (b1 < 50)
            {
                b1 = 50;
            }
            if (b2 < 50)
            {
                b2 = 50;
            }


            spritebatch.DrawString(Font, "Damage: ", this.Game.CurrentScene.IndicatorManager.Damage.GetBasePos(), Color.White,0,Vector2.Zero,.5f,SpriteEffects.None,0);
            spritebatch.DrawString(Font, "Damage: ", this.Game.CurrentScene.IndicatorManager2.Damage.GetBasePos(), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

            spritebatch.DrawString(Font, Game.CurrentScene.IndicatorManager.Damage.Value() + "%",new Vector2( this.Game.CurrentScene.IndicatorManager.Damage.Position.X+75, this.Game.CurrentScene.IndicatorManager.Damage.Position.Y), new Color(r1,g1,b1),0,Vector2.Zero,.5f,SpriteEffects.None,0);
            spritebatch.DrawString(Font, Game.CurrentScene.IndicatorManager2.Damage.Value() + "%", new Vector2(this.Game.CurrentScene.IndicatorManager2.Damage.Position.X + 75, this.Game.CurrentScene.IndicatorManager2.Damage.Position.Y), new Color(r2,g2,b2),0,Vector2.Zero,.5f,SpriteEffects.None,0);

            spritebatch.DrawString(Font, "Player 1 Lives: " + Game.CurrentScene.IndicatorManager.Value("lives").ToString(),new Vector2(50,275),Color.White,0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spritebatch.DrawString(Font, "Player 2 Lives: " + Game.CurrentScene.IndicatorManager2.Value("lives").ToString(), new Vector2(450, 275), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

        }

        public void DisplayFinalScore(SpriteBatch spritebatch,Vector2 pos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("         GAME OVER");
            sb.AppendLine("");
            string str = "000000" + Game.CurrentScene.IndicatorManager.Value("score").ToString();
            int length = str.Length;
            sb.AppendLine("Total Score "+ str.Substring(length - 6));
            sb.AppendLine("Press Y to restart, N to quit");
            spritebatch.DrawString(Font, sb, pos, Color.White);
        }

        public void DisplayVictory(SpriteBatch spritebatch, Vector2 pos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("               YOU WIN!");
            sb.AppendLine("");
            string str = "000000" + Game.CurrentScene.IndicatorManager.Value("score").ToString();
            int length = str.Length;
            sb.AppendLine("Total Score " + str.Substring(length - 6));
            sb.AppendLine("Press R to restart, Q to quit");
            spritebatch.DrawString(Font, sb, pos, Color.White);
        }

        //public void StartGameDisplay()
       // {

       // }

        public void Update(GameTime gametime)
        {
            Avatar.UpdateSprite(gametime);
            Coin.UpdateSprite(gametime);
            //Width = Game.GraphicsDevice.Viewport.Width;
        }
    }
}
