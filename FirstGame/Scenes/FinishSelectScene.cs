﻿using Microsoft.Xna.Framework;
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
    public class FinishSelectScene : IScene
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
        private ISprite Floor;
        private ISprite Chaos;


        public FinishSelectScene(Game1 game)
        {
            Game = game;
        }

        public void Initialize()
        {
            Controller = new Controller(new FinishSelectCommandMap(Game));
            Font = Game.Content.Load<SpriteFont>("HUD/Arial");
            WhiteMario = TextureFactory.Factory(Game, "WhiteMario");
            BlackMario = TextureFactory.Factory(Game, "BlackMario");
            WhiteLuigi = TextureFactory.Factory(Game, "WhiteLuigi");
            BlackLuigi = TextureFactory.Factory(Game, "BlackLuigi");
            Chaos = TextureFactory.Factory(Game, "Chaos");
            Floor = BlockFactory.AllBlockFactory(Game, "Floor");
            Game.GraphicsDevice.Clear(Color.Black);
        }

        public void Update(GameTime gameTime)
        {
            Controller.UpdateInput();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(Font, "Player1 Character:", new Vector2(0, 0), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Player2 Character:", new Vector2(Game.GraphicsDevice.Viewport.Width - 200, 0), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, "Press enter to start fight, r to reselect character", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 200, 80), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

            if (Game.Player1 == 1)
            {
                spriteBatch.Draw(WhiteMario.Texture, new Vector2(140, 0), null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Game.Player2 == 1)
                {
                    spriteBatch.Draw(BlackMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - WhiteMario.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else if (Game.Player2 == 2)
                {
                    spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - WhiteLuigi.Texture.Width - 10, 0), null, Color.White, 0f,
                         Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - Chaos.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }
            else if (Game.Player1 == 2)
            {
                spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(140, 0), null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Game.Player2 == 1)
                {
                    spriteBatch.Draw(WhiteMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - WhiteMario.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else if (Game.Player2 == 2)
                {
                    spriteBatch.Draw(BlackLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - BlackLuigi.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - Chaos.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }
            else
            {
                spriteBatch.Draw(Chaos.Texture, new Vector2(140, 0), null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Game.Player2 == 1)
                {
                    spriteBatch.Draw(WhiteMario.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - WhiteMario.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else if (Game.Player2 == 2)
                {
                    spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - WhiteLuigi.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Chaos.Texture, new Vector2(Game.GraphicsDevice.Viewport.Width - Chaos.Texture.Width - 10, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.DrawString(Font, "Map:", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 60, Game.GraphicsDevice.Viewport.Height * 2 / 3), Color.White);
            spriteBatch.Draw(Floor.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width) / 2 + 30, Game.GraphicsDevice.Viewport.Height * 2 / 3), null, Color.White, 0f,
                    Vector2.Zero, 2f, SpriteEffects.None, 0f);

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