using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.InputControllers;
using Sprint0.Indicators;
using Sprint0.Scripts;
using FirstGame;
using Sprint0.Cameraa;
using Sprint0.Commands.Mapping;
using Sprint0.Sprites;

namespace Sprint0.Scenes
{
    public class StaffScene : IScene
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
        private ISprite Super;
        private ISprite Smash;
        private ISprite Bros;
        private ISprite Plate;
        private ISprite Circle;
        private ISprite Bang;

        public StaffScene(Game1 game)
        {
            Game = game;
        }

        public void Initialize()
        {
            Controller = new Controller(new EndGameCommandMap(Game));
            Font = Game.Content.Load<SpriteFont>("HUD/Arial");
            Super = TextureFactory.Factory(Game, "Super");
            Smash = TextureFactory.Factory(Game, "Smash");
            Bros = TextureFactory.Factory(Game, "Bros");
            Circle = TextureFactory.Factory(Game, "Circle");
            Bang = TextureFactory.Factory(Game, "Bang");
            Plate = TextureFactory.Factory(Game, "Plate");
            Game.GraphicsDevice.Clear(Color.Black);
        }

        public void Update(GameTime gameTime)
        {
            Controller.UpdateInput();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(Font, "Brought to you by: Team Wario", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Chris Clarke", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 20), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Michael Morrill", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 40), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Jingyu Gu", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 60), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Tianyang Zhang", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 80), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Yunhao Zhang", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 100), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Press any key to continue...", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 100, Game.GraphicsDevice.Viewport.Height * 8 / 14 + 160), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);



            spriteBatch.Draw(Circle.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Circle.Texture.Width * 1.5f) * 4 / 5, (Game.GraphicsDevice.Viewport.Height) / 14), null, Color.MonoGameOrange, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Bang.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Bang.Texture.Width * 1.5f) / 2, (Game.GraphicsDevice.Viewport.Height - Bang.Texture.Height / 2) / 4), null, Color.Orange, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Plate.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Plate.Texture.Width * 1.5f) / 2, (Game.GraphicsDevice.Viewport.Height - Plate.Texture.Height / 2) / 2), null, Color.White, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Super.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Super.Texture.Width * 1.5f) / 4, Game.GraphicsDevice.Viewport.Height / 4), null, Color.White, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Smash.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Smash.Texture.Width * 1.5f) / 2, Game.GraphicsDevice.Viewport.Height / 4), null, Color.White, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Bros.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - Bros.Texture.Width * 1.5f) * 3 / 4, Game.GraphicsDevice.Viewport.Height / 4), null, Color.White, 0f,
                    Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Font, "Press anykey to Start", new Vector2((Game.GraphicsDevice.Viewport.Width - 145) / 2, Game.GraphicsDevice.Viewport.Height * 2 / 3), Color.Black, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
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

