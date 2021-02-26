using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.InputControllers;
using Sprint0.Sprites.BlockSprite;
using System;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Sprint0.Sounds;
using Sprint0.Indicators;
using Microsoft.Xna.Framework.Media;
using Sprint0.Text;
using System.Collections.ObjectModel;
using Sprint0.Scripts;
using Sprint0.Cameraa;
using FirstGame;
using Sprint0.Commands.Mapping;

namespace Sprint0.Scenes
{
    public class CharacterSelectScene2 : IScene
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
        private ISprite MarioIntro;
        private ISprite LuigiIntro;
        //private ISprite Background;
        private ISprite Chaos;


        public CharacterSelectScene2(Game1 game)
        {
            Game = game;
        }

        public void Initialize()
        {
            Controller = new Controller(new CharacterSelectCommandMap(Game));
            Font = Game.Content.Load<SpriteFont>("HUD/Arial");
            WhiteMario = TextureFactory.Factory(Game, "WhiteMario");
            BlackMario = TextureFactory.Factory(Game, "BlackMario");
            WhiteLuigi = TextureFactory.Factory(Game, "WhiteLuigi");
            BlackLuigi = TextureFactory.Factory(Game, "BlackLuigi");
            MarioIntro = TextureFactory.Factory(Game, "MarioIntro");
            LuigiIntro = TextureFactory.Factory(Game, "LuigiIntro");
            Chaos = TextureFactory.Factory(Game, "Chaos");
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
            spriteBatch.DrawString(Font, "Press 1 to select Mario, 2 to select Luigi for player2", new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - 200, 80), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);

            if(Game.Player1 == 1)
            {
                spriteBatch.Draw(WhiteMario.Texture, new Vector2(140, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(BlackMario.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - BlackMario.Texture.Width) / 3 - 140, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(WhiteLuigi.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - WhiteLuigi.Texture.Width) * 2 / 3 - 40, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else if(Game.Player1 == 2)
            {
                spriteBatch.Draw(WhiteLuigi.Texture, new Vector2(140, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(WhiteMario.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - WhiteMario.Texture.Width) / 3 - 140, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(BlackLuigi.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - BlackLuigi.Texture.Width) * 2 / 3 - 40, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(Chaos.Texture, new Vector2(140, 0), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(WhiteMario.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - WhiteMario.Texture.Width) / 3 - 140, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(WhiteLuigi.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - WhiteLuigi.Texture.Width) * 2 / 3 - 40, Game.GraphicsDevice.Viewport.Height * 4 / 12 + 15), null, Color.White, 0f,
                        Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(MarioIntro.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - MarioIntro.Texture.Width) / 3 - 80, Game.GraphicsDevice.Viewport.Height * 3 / 12), null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(LuigiIntro.Texture, new Vector2((Game.GraphicsDevice.Viewport.Width - LuigiIntro.Texture.Width) * 2 / 3 + 80, Game.GraphicsDevice.Viewport.Height * 3 / 12), null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.None, 0f);

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
