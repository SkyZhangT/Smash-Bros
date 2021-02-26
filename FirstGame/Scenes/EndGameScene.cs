using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.InputControllers;
using Sprint0.Indicators;
using Sprint0.Scripts;
using Sprint0.Cameraa;
using FirstGame;
using Sprint0.Commands.Mapping;

namespace Sprint0.Scenes
{
    public class EndGameScene : IScene
    {
        public Game1 Game { get; set; }
        public AvatarMain PlayerAvatar { get; set; }
        public IEntity ThwompItem { get; set; }
        public Vector2 FirstBottomRightBoundary { get; set; }

        public AvatarMain PlayerAvatar2 { get; set; }
        public IndicatorManager IndicatorManager { get; set; }
        public IndicatorManager IndicatorManager2 { get; set; }
        public Camera Camera { get; set; }
        public Camera Camera1 { get; set; }
        public Camera Camera2 { get; set; }
        public Controller Controller { get; set; }
        public ALevel MainLevel { get; set; }
        public IGameState GameState { get; set; }
        public AScript CurrentScript { get; set; }
        public bool PauseBackground { get; set; }
        public bool GrowPause { get; set; }
        public int TimeSinceLast { get; set; }
        public float Iter { get; set; }

        private SpriteFont Font;
        private ISprite WhiteMario;
        private ISprite BlackMario;
        private ISprite WhiteLuigi;
        private ISprite BlackLuigi;
        private ISprite Chaos;

        public EndGameScene(Game1 game)
        {
            Game = game;
        }

        public void Initialize()
        {
            TimeSinceLast = 0;
            Font = Game.Content.Load<SpriteFont>("HUD/Arial");
            WhiteMario = TextureFactory.Factory(Game, "WhiteMario");
            BlackMario = TextureFactory.Factory(Game, "BlackMario");
            WhiteLuigi = TextureFactory.Factory(Game, "WhiteLuigi");
            BlackLuigi = TextureFactory.Factory(Game, "BlackLuigi");
            Chaos = TextureFactory.Factory(Game, "Chaos");
            Game.GraphicsDevice.Clear(Color.Black);
            Game.Graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            Game.Graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            Game.Graphics.ApplyChanges();
        }

        public void Update(GameTime gameTime)
        {
            TimeSinceLast += gameTime.ElapsedGameTime.Milliseconds;
            if(TimeSinceLast > 5000)
            {
                Game.CurrentScene = new StaffScene(Game);
                Game.CurrentScene.Initialize();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, "Winner: ", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height / 2), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            if (Game.Winner == 1)
            {
                spriteBatch.DrawString(Font, "Player1", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 40, Game.GraphicsDevice.Viewport.Height / 2), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

                if (Game.Player1 == 1)
                {
                    spriteBatch.Draw(WhiteMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else if (Game.Player1 == 2)
                {
                    spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }
            else
            {
                spriteBatch.DrawString(Font, "Player2", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 40, Game.GraphicsDevice.Viewport.Height / 2), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

                if (Game.Player1 == 1)
                {
                    if (Game.Player2 == 1)
                    {
                        spriteBatch.Draw(BlackMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else if (Game.Player2 == 2)
                    {
                        spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                             Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
                else if (Game.Player1 == 2)
                {
                    if (Game.Player2 == 1)
                    {
                        spriteBatch.Draw(WhiteMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else if (Game.Player2 == 2)
                    {
                        spriteBatch.Draw(BlackLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
                else
                {
                    if (Game.Player2 == 1)
                    {
                        spriteBatch.Draw(WhiteMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else if (Game.Player2 == 2)
                    {
                        spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width / 2 + 15, Game.GraphicsDevice.Viewport.Height / 2), null, Color.White, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
            }



            spriteBatch.End();
        }

        public void StartScript(AScript script)
        {

        }

        public void ToggleFullScreen()
        {

        }
    }
}
