using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Cameraa;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.InputControllers;
using Sprint0.Sprites.BlockSprite;
using Sprint0.HUDD;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Sprint0.Sounds;
using Sprint0.Indicators;
using Microsoft.Xna.Framework.Media;
using Sprint0.Text;
using System.Collections.ObjectModel;
using Sprint0.Scripts;
using FirstGame;
using System;
using Sprint0.Game_Enities.Enemies;
using Sprint0.Game_Enities.Items;

namespace Sprint0.Scenes
{
    public class Map:IScene
    {
        public AvatarMain PlayerAvatar { get; set; }
        public AvatarMain PlayerAvatar2 { get; set; }
        Game1 Game { get; set; }
        public ALevel MainLevel { get; set; }
        public Camera Camera { get; set; }
        public Camera Camera1 { get; set; }
        private int ItemTimer = 0;
        public Camera Camera2 { get; set; }
        public HUD HUD { get; set; }
        public IEntity ThwompItem { get; set; }
        public IndicatorManager IndicatorManager { get; set; }
        public IndicatorManager IndicatorManager2 { get; set; }
        public IGameState GameState { get; set; }
        public GameStateTransition GameStateTransition { get; set; }
        public Controller Controller { get; set; }
        BackGround StarTile;
        public RasterizerState AntiAlias { get => antiAlias; set => antiAlias = value; }
        private RasterizerState antiAlias = new RasterizerState { MultiSampleAntiAlias = true };
        private static float Scale;
        public float Iter { get; set; }
        Vector2 parallax;
        private int increment = 0;
        public Vector2 FirstBottomRightBoundary { get; set; }
        public AScript CurrentScript { get => currentScript; set => currentScript = value; }
        private AScript currentScript;
        private float StartingZoomWidth = 560;
        private float StartingZoomHeight;
        public bool GrowPause { get; set; }
        public bool PauseBackground { get; set; }
        public int TimeSinceLast { get; set; }
        public int Increment { get => increment; set => increment = value; }

        private Random Rand = new Random();

        public Map(Game1 game)
        {
            Game = game;
            Scale = 1f;

            PauseBackground = false;
            GrowPause = false;
            TimeSinceLast = 0;
            Iter = 0;
        }

        public void Initialize()
        {

            Game.Graphics.PreferredBackBufferWidth = (int)StartingZoomWidth;
            StartingZoomHeight = StartingZoomWidth / 1.777777f;
            Game.Graphics.PreferredBackBufferHeight = (int)(StartingZoomHeight);
            Game.Window.AllowUserResizing = true;
            Game.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            Game.Graphics.ApplyChanges();
            StarTile = new BackGround(Game.Content.Load<Texture2D>("BackGround/StarTile"), Game.Content.Load<Texture2D>("BackGround/StarTile2"));



            MainLevel = new Level(Game, Game.EntityManager);
            MainLevel.LoadFile();
            MainLevel.LoadEntity();
            FirstBottomRightBoundary = MainLevel.BottomRightBoundary;

            GameState = new PlayState(Game);
            GameStateTransition = new GameStateTransition(Game, GameState);


            this.Camera1 = new Camera(Game.GraphicsDevice.Viewport);
            parallax = new Vector2(1.0f);
            Camera1.Limits = new Rectangle(-1000, -200, (int)MainLevel.BottomRightBoundary.X + 1000, Game.GraphicsDevice.Viewport.Height + 1000);
            Camera1.Position = new Vector2(0, 0);


            this.Camera2 = new Camera(Game.GraphicsDevice.Viewport);
            parallax = new Vector2(1.0f);
            Camera2.Limits = new Rectangle(0, 0, 800, Game.GraphicsDevice.Viewport.Height);
            Camera2.PositionWithLimit = new Vector2(0, 0);


            this.Camera = this.Camera1;

            HUD = new HUD(Game);
            IndicatorManager = new IndicatorManager(Game, PlayerAvatar, new Vector2(50, (float)Game.GraphicsDevice.Viewport.Height /*/ 3.2f - 20*/));
            IndicatorManager2 = new IndicatorManager(Game, PlayerAvatar2, new Vector2(450, (float)Game.GraphicsDevice.Viewport.Height /*/ 3.2f - 20*/));

            ToggleFullScreen();

            CollisionHandling.Create(ref Game.EntityManager.entities);
        }

        public void Update(GameTime gameTime)
        {
            if (!PauseBackground)
            {
                StarTile.Update(gameTime);
            }
            GameState.Update(gameTime);
            Game.FloatingScoreManager.UpdatefloatingScores(gameTime);
            GameStateTransition.Update(gameTime);

            if (GameState is PlayState)
            {
                HUD.Update(gameTime);
                IndicatorManager.Update(gameTime);
                IndicatorManager2.Update(gameTime);
            }

            if (this.CurrentScript != null)
            {
                this.CurrentScript.Update(gameTime);

                if (this.CurrentScript.DoneFlag)
                {
                    this.CurrentScript = null;
                }
            }
            if (!(GameState is SkillState))
            {
                UpdateZoom();
            }
            ItemSpawn(gameTime);

        }
        #region Drawing
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            //spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            if (Game.Level == 1)
                BackgroundDrawing(gameTime, spriteBatch);
            else if (Game.Level == 3)
                BackgroundDrawing3(gameTime, spriteBatch);
            else if (Game.Level == 2)
            {
                BackgroundDrawing2(gameTime, spriteBatch);
            }

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(Game.Content.Load<Texture2D>("black"), new Rectangle(3280, 0, (int)StartingZoomWidth, Game.GraphicsDevice.Viewport.Height), Color.White);

            Game.EntityManager.DrawEntities();
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            SpriteFont Font = Game.Content.Load<SpriteFont>("HUD/Arial");
            Color color;
            if (PlayerAvatar is MarioAvatar)
            {
                if (PlayerAvatar.Name is "Mario")
                {
                    color = Color.Red;
                }
                else
                {
                    color = Color.Green;
                }
            }
            else
            {
                color = Color.Blue;
            }
            spriteBatch.DrawString(Font, "Player 1", new Vector2(PlayerAvatar.Position.X, PlayerAvatar.Position.Y - 6), color,0f,Vector2.Zero,.15f,SpriteEffects.None,1f);

            if (PlayerAvatar2 is MarioAvatar)
            {
                if (PlayerAvatar2.Name is "Mario")
                {
                    color = Color.Red;
                }
                else
                {
                    color = Color.Green;
                }
            }
            else
            {
                color = Color.Blue;
            }
            spriteBatch.DrawString(Font, "Player 2", new Vector2(PlayerAvatar2.Position.X, PlayerAvatar2.Position.Y - 6), color, 0f, Vector2.Zero, .15f, SpriteEffects.None, 1f);
            spriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(Vector2.Zero, 3));
            HUD.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(Vector2.Zero, Scale));
            Game.FloatingScoreManager.DrawfloatingScores();

            MarioSkillDrawing(spriteBatch);
            spriteBatch.End();



            spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            ScoreDisplayDrawing(spriteBatch);
            spriteBatch.End();
        }

        public void BackgroundDrawing(GameTime time, SpriteBatch spriteBatch)
        {
            //Transition
            float colorAmount = 0;
            if (Iter > 200 && Iter < 500)
            {
                colorAmount = (Iter - 200) / 500;
            }
            else if (Iter >= 500 && Iter < 700)
            {
                colorAmount = .6f;
            }
            else if (Iter >= 700 && Iter < 1000)
            {
                colorAmount = (.6f - (Iter - 700) / 500);
            }
            Color backColor = Color.Lerp(Color.White, Color.Black, colorAmount);
            Color furtherBackColor = Color.Lerp(Color.TransparentBlack, Color.White, colorAmount - .1f);
            Color sunColor = Color.Lerp(Color.White, Color.Red, colorAmount * 6);
            Color moonColor = Color.Lerp(Color.WhiteSmoke, Color.White, colorAmount * 3);
            SoundManager.backGroundMusic.Volume = .8f - colorAmount;

            //BackDrop
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(StarTile.CurrentTexture, new Vector2(-1000, -400), new Rectangle(0, 0, (int)MainLevel.BottomRightBoundary.X+2500, (int)MainLevel.BottomRightBoundary.Y+1000), furtherBackColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);

            //Sun
            if (Iter < 400)
            {
                
                spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/Sun"), new Vector2(300 - (Iter / 2), -100 + (Iter * 1.5f)), new Rectangle(1, 1, 100, 100), sunColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            }
            //Moon
            if (Iter > 500 && Iter < 900)
            {
                spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/Moon"), new Vector2(400 - (Iter * .7f), -100 + ((Iter - 500) * 1.5f)), new Rectangle(1, 1, 100, 100), moonColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            }
            spriteBatch.End();

            //BigHill
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigHill"), new Vector2(35, 256+64), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X, 35), backColor, 0, Vector2.Zero, 2.0f, SpriteEffects.None, 0.5f);

            //SmallHill
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallHill"), new Vector2(0, 248+64), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X, 19), backColor, 0, Vector2.Zero, new Vector2(2.0f, 3.0f), SpriteEffects.None, 0.5f);

            //AllBush
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigBush"), new Vector2(0, 289+64), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X, 16), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();

            //BigCloud
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigCloud"), new Vector2(0 - this.Iter * 3, 25), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X + 3000, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);

            //LittleCloud
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloud"), new Vector2(0 - this.Iter * 3.5f, 50), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X + 3500, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloudLayer2.xcf"), new Vector2(0 - this.Iter * 4, 75), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X + 4000, 49), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();

            //Adds Colored Block to background under floor blocks
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null, null, Camera.GetViewMatrix(parallax,Scale));
            Texture2D BackGrass = new Texture2D(Game.GraphicsDevice, 1, 1);
            BackGrass.SetData(new[] { Color.Green });
            spriteBatch.Draw(BackGrass, new Vector2(-800, 368), new Rectangle(-400, 0, (int)MainLevel.BottomRightBoundary.X+2000, (int)MainLevel.BottomRightBoundary.Y+500), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();
            
            if (!GrowPause && !PauseBackground)
            {
                TimeSinceLast += time.ElapsedGameTime.Milliseconds;
                if (TimeSinceLast >= 16)
                {
                    Iter += .1f;
                    TimeSinceLast = 0;
                }
                if (Iter > 1000)
                {
                    Iter = 0;
                }
            }

        }
        public void BackgroundDrawing2(GameTime time, SpriteBatch spriteBatch)
        {
            Color backColor = Color.Lerp(Color.White, Color.Black, .7f);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(StarTile.CurrentTexture, new Vector2(-1000, -400), new Rectangle(0, 0, (int)MainLevel.BottomRightBoundary.X + 2500, (int)MainLevel.BottomRightBoundary.Y + 1000), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigMoon"), new Rectangle(50, 50, 300, 300), Color.Lerp(Color.White,Color.Red,.5f));
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SnowField"), new Rectangle(-1280, 405, 2931, 46), backColor);
            //BigCloud
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigCloud"), new Vector2(0 - this.Iter * 3, 25), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X + 3000, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);

            //LittleCloud
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloud"), new Vector2(0 - this.Iter * 3.5f, 50), new Rectangle(-100, 1, (int)MainLevel.BottomRightBoundary.X + 3500, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloudLayer2.xcf"), new Vector2(0 - this.Iter * 4, 75), new Rectangle(-100, 1, (int)MainLevel.BottomRightBoundary.X + 4000, 49), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();
            //Grass
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null, null, Camera.GetViewMatrix(parallax, Scale));
            Texture2D BackGrass = new Texture2D(Game.GraphicsDevice, 1, 1);
            BackGrass.SetData(new[] { Color.White });
            spriteBatch.Draw(BackGrass, new Vector2(-800, 450), new Rectangle(-400, 0, (int)MainLevel.BottomRightBoundary.X + 2000, (int)MainLevel.BottomRightBoundary.Y + 500), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();
            if (!GrowPause && !PauseBackground)
            {
                TimeSinceLast += time.ElapsedGameTime.Milliseconds;
                if (TimeSinceLast >= 16)
                {
                    Iter += .1f;
                    TimeSinceLast = 0;
                }
                if (Iter > 1000)
                {
                    Iter = 0;
                }
            }

        }

            public void BackgroundDrawing3(GameTime time, SpriteBatch spriteBatch)
        {
            Color backColor = Color.Lerp(Color.White, Color.Red, .2f);


            //BigCloud
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, AntiAlias, null, Camera.GetViewMatrix(parallax, Scale));
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/BigCloud"), new Vector2(0 - this.Iter * 3, 25), new Rectangle(1, 1, (int)MainLevel.BottomRightBoundary.X + 3000, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/Castle"), new Rectangle(17, 52, (int)FirstBottomRightBoundary.X, 400), Color.Wheat);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/Field"), new Rectangle(-1280, 405, 2931, 46), backColor);
            //LittleCloud
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloud"), new Vector2(0 - this.Iter * 3.5f, 50), new Rectangle(-100, 1, (int)MainLevel.BottomRightBoundary.X + 3500, 48), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(Game.Content.Load<Texture2D>("BackGround/SmallCloudLayer2.xcf"), new Vector2(0 - this.Iter * 4, 75), new Rectangle(-100, 1, (int)MainLevel.BottomRightBoundary.X + 4000, 49), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();
            //Grass
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null, null, Camera.GetViewMatrix(parallax, Scale));
            Texture2D BackGrass = new Texture2D(Game.GraphicsDevice, 1, 1);
            BackGrass.SetData(new[] { Color.Green });
            spriteBatch.Draw(BackGrass, new Vector2(-800, 450), new Rectangle(-400, 0, (int)MainLevel.BottomRightBoundary.X + 2000, (int)MainLevel.BottomRightBoundary.Y + 500), backColor, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.End();
            if (!GrowPause && !PauseBackground)
            {
                TimeSinceLast += time.ElapsedGameTime.Milliseconds;
                if (TimeSinceLast >= 16)
                {
                    Iter += .1f;
                    TimeSinceLast = 0;
                }
                if (Iter > 1000)
                {
                    Iter = 0;
                }
            }
        }
        public void ScoreDisplayDrawing(SpriteBatch spriteBatch)
        {
            if (GameState is FaliureState)
            {
                Texture2D pannel = Game.Content.Load<Texture2D>("black");
                Rectangle pannelRec = new Rectangle(Convert.ToInt32(Math.Ceiling(Camera.Position.X)) + 130, 20, 300, 250);
                Texture2D noob = Game.Content.Load<Texture2D>("caiDarkRed");
                Rectangle noobRec = new Rectangle(Convert.ToInt32(Math.Ceiling(Camera.Position.X)) + 200, 10, 160, 160);

                spriteBatch.Draw(pannel, pannelRec, Color.White * 0.6f);
                spriteBatch.Draw(noob, noobRec, Color.White);
                Vector2 pos = new Vector2(pannelRec.X + 60, pannelRec.Y + 145);
                HUD.DisplayFinalScore(spriteBatch, pos);
            }
            else if (this.GameState is WinState)
            {
                Texture2D pannel = Game.Content.Load<Texture2D>("black");
                Rectangle pannelRec = new Rectangle(Convert.ToInt32(Math.Ceiling(Camera.Position.X)) + 130, 20, 300, 200);


                spriteBatch.Draw(pannel, pannelRec, Color.Black * 0.6f);


                Vector2 pos = new Vector2(pannelRec.X + 60, pannelRec.Y + 45);
                HUD.DisplayVictory(spriteBatch, pos);
            }
        }

        public void MarioSkillDrawing(SpriteBatch spriteBatch)
        {
            if (GameState is SkillState)
            {
                if (((SkillState)GameState).PlayerAvatar is MarioAvatar)
                {
                    Texture2D figure;
                    Rectangle figureRec;
                    if (((SkillState)GameState).PlayerAvatar.Name.Equals("Luigi"))
                    {
                        figure = Game.Content.Load<Texture2D>("luigiSkill");
                        figureRec = new Rectangle(110, -10, 216, 255);
                    }
                    else
                    {
                        figure = Game.Content.Load<Texture2D>("Figure");
                        figureRec = new Rectangle(120, -50, 184, 378);
                    }
                    Texture2D pannel = Game.Content.Load<Texture2D>("black");
                    Texture2D skillName = Game.Content.Load<Texture2D>("SkillName");
                    
                    Rectangle pannelRec = new Rectangle(0, 100, 600, 30);
                    Rectangle nameRec = new Rectangle(20, 80, 240, 60);
                    spriteBatch.Draw(figure, figureRec, Color.White * 1.0f);
                    spriteBatch.Draw(pannel, pannelRec, Color.White * 0.7f);
                    spriteBatch.Draw(skillName, nameRec, Color.White * 1.0f);
                }
                if (((SkillState)GameState).PlayerAvatar is TurtleAvatar)
                {
                    Texture2D figure = Game.Content.Load<Texture2D>("KoopaFigure");
                    SpriteFont Font = Game.Content.Load<SpriteFont>("HUD/Arial");
                    Rectangle figureRec = new Rectangle(120, -50, 160, 329);
                    spriteBatch.Draw(figure, figureRec, Color.White * 1.0f);
                    spriteBatch.DrawString(Font, "TURTLES",new Vector2(40,80), Color.Green * 1.0f);
                }


            }
        }
        #endregion


        private void SetScale()
        {
            float xDif = Math.Abs(PlayerAvatar.Position.X - PlayerAvatar2.Position.X) + 160;
            float yDif = Math.Abs(PlayerAvatar.Position.Y - PlayerAvatar2.Position.Y) + 160;
            if (ThwompItem != null)
            {
                if (PlayerAvatar.Position.Y < PlayerAvatar2.Position.Y)
                {
                    if (ThwompItem.Position.Y < PlayerAvatar.Position.Y)
                    {
                        yDif = Math.Abs(ThwompItem.Position.Y - PlayerAvatar2.Position.Y) + 220;
                    }
                }
                else
                {
                    if (ThwompItem.Position.Y < PlayerAvatar2.Position.Y)
                    {
                        yDif = Math.Abs(ThwompItem.Position.Y - PlayerAvatar.Position.Y) + 220;
                    }
                }
                if (PlayerAvatar.Position.X < PlayerAvatar2.Position.X)
                {
                    if (ThwompItem.Position.X > PlayerAvatar2.Position.X)
                    {
                        xDif = Math.Abs(ThwompItem.Position.X - PlayerAvatar.Position.X) + 160;
                    }
                }
                else
                {
                    if (ThwompItem.Position.X > PlayerAvatar.Position.X)
                    {
                        xDif = Math.Abs(ThwompItem.Position.X - PlayerAvatar2.Position.X) + 160;
                    }
                }
            }
            if ((StartingZoomWidth / xDif > 2) && StartingZoomHeight / yDif > 2)
            {
                Scale = (Game.Graphics.PreferredBackBufferWidth / StartingZoomWidth) * 2f;
            }
            else if ((StartingZoomWidth / xDif < .5f) || StartingZoomHeight / yDif < .5f)
            {
                Scale = (Game.Graphics.PreferredBackBufferWidth / StartingZoomWidth) * .5f;

            }
            else

            {
                float Scale1 = (Game.Graphics.PreferredBackBufferWidth / StartingZoomWidth) * StartingZoomWidth / xDif;
                float Scale2 = (Game.Graphics.PreferredBackBufferHeight / StartingZoomHeight) * StartingZoomHeight / yDif;
                if (Scale1 > Scale2)
                {
                    Scale = Scale2;
                }
                else
                {
                    Scale = Scale1;
                }


            }
        }

        void UpdateZoom()
        {
            SetScale();

            if ((PlayerAvatar.Position.X < FirstBottomRightBoundary.X + 200 && PlayerAvatar.Position.X > -200 && PlayerAvatar.Position.Y > 0 && PlayerAvatar.Position.Y < FirstBottomRightBoundary.Y + 100) || (PlayerAvatar2.Position.X < FirstBottomRightBoundary.X + 200 && PlayerAvatar2.Position.X > -200 && PlayerAvatar2.Position.Y > 0 && PlayerAvatar2.Position.Y < FirstBottomRightBoundary.Y + 100))
            {
                if (PlayerAvatar.Position.X > FirstBottomRightBoundary.X + 200)
                {
                    if (PlayerAvatar.Position.Y > FirstBottomRightBoundary.Y + 100)
                    {
                        Camera1.LookAt(new Vector2((FirstBottomRightBoundary.X + 200 + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar2.Position.Y + FirstBottomRightBoundary.Y + 100 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                    else
                    {
                        Camera1.LookAt(new Vector2((FirstBottomRightBoundary.X + 200 + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar.Position.Y + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                }
                else if (PlayerAvatar2.Position.X > FirstBottomRightBoundary.X + 200)
                {
                    if (PlayerAvatar2.Position.Y > FirstBottomRightBoundary.Y + 100)
                    {
                        Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + FirstBottomRightBoundary.X + 200 + 16) / 2, (PlayerAvatar.Position.Y + FirstBottomRightBoundary.Y + 100 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                    else
                    {
                        Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + FirstBottomRightBoundary.X + 200 + 16) / 2, (PlayerAvatar.Position.Y + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                }
                else if (PlayerAvatar.Position.X < -200)
                {
                    if (PlayerAvatar.Position.Y > FirstBottomRightBoundary.Y + 100)
                    {
                        Camera1.LookAt(new Vector2((-200 + PlayerAvatar2.Position.X + 16) / 2, (FirstBottomRightBoundary.Y + 100 + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                    else
                    {
                        Camera1.LookAt(new Vector2((-200 + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar.Position.Y + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                }
                else if (PlayerAvatar2.Position.X < -200)
                {
                    if (PlayerAvatar2.Position.Y > FirstBottomRightBoundary.Y + 100)
                    {
                        Camera1.LookAt(new Vector2((PlayerAvatar.Position.X - 200 + 16) / 2, (PlayerAvatar.Position.Y + FirstBottomRightBoundary.Y + 100 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                    else
                    {
                        Camera1.LookAt(new Vector2((PlayerAvatar.Position.X - 200 + 16) / 2, (PlayerAvatar.Position.Y + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                    }
                }
                else if (PlayerAvatar2.Position.Y < 0)
                {
                    Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar.Position.Y + 0 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                }
                else if (PlayerAvatar.Position.Y < 0)
                {
                    Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar2.Position.Y + 0 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                }
                else if (PlayerAvatar2.Position.Y > FirstBottomRightBoundary.Y + 100)
                {
                    Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar.Position.Y + FirstBottomRightBoundary.Y + 100 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                }
                else if (PlayerAvatar.Position.Y > FirstBottomRightBoundary.Y + 100)
                {
                    Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar2.Position.Y + FirstBottomRightBoundary.Y + 100 + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                }
                else
                {
                    Camera1.LookAt(new Vector2((PlayerAvatar.Position.X + PlayerAvatar2.Position.X + 16) / 2, (PlayerAvatar.Position.Y + PlayerAvatar2.Position.Y + 24) / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
                }
            }
            else
            {
                Scale = (Game.Graphics.PreferredBackBufferWidth / StartingZoomWidth) * .5f;
                Camera1.LookAt(new Vector2(FirstBottomRightBoundary.X / 2, FirstBottomRightBoundary.Y / 2), (Game.GraphicsDevice.Viewport.Width) / Scale, Game.GraphicsDevice.Viewport.Height / Scale);
            }

        }

        public void ItemSpawn(GameTime gameTime)
        {
            ItemTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (ItemTimer > 8000)
            {
                int xpos=Rand.Next(0, (int)FirstBottomRightBoundary.X);
                int itemType = Rand.Next(0, 10);
                ItemEntity item;
                if (itemType < 3)
                {
                    item = new SuperMushroom(Game, ItemFactory.CreateSprite(Game, "SuperMushroom"), new Vector2(xpos, 0),Vector2.Zero);
                }
                else if (itemType <= 4)
                {
                    item = new FireFlower(Game, ItemFactory.CreateSprite(Game, "BlueFlower"), new Vector2(xpos, 0), Vector2.Zero);
                }
                else if (itemType <= 5)
                {
                    item = new Star(Game, ItemFactory.CreateSprite(Game, "Star"), new Vector2(xpos, 0), Vector2.Zero);
                }
                else if (itemType <= 6)
                {
                    item = new CheepCheepItem(Game, BlockFactory.CheepCheepItem(Game), new Vector2(xpos, 0), Vector2.Zero);
                }
                else if(itemType <= 8)
                {
                    item = new ThwompItem(Game, BlockFactory.ThwompItem(Game), new Vector2(xpos, 0), Vector2.Zero);
                }
                else
                {
                    item = new BulletBillItem(Game, BlockFactory.BulletBillItem(Game), new Vector2(xpos, 0), Vector2.Zero);
                }
                Game.EntityManager.AddEntity(item);
                ItemTimer = 0;
                item.Initialize();
            }
        }

        public void ToggleFullScreen()
        {

            int fullScreenWidth = 1920;//number here
            if (Game.Window.ClientBounds.Width == fullScreenWidth)
            {
                Game.Graphics.PreferredBackBufferWidth = (int)StartingZoomWidth;
                Game.Graphics.PreferredBackBufferHeight = (int)((float)StartingZoomWidth * StartingZoomHeight / StartingZoomWidth);
                //Scale = (float)StartingZoomWidth / StartingZoomWidth;
                Game.Graphics.ApplyChanges();
            }
            else
            {
                Game.Graphics.PreferredBackBufferWidth = fullScreenWidth;
                Game.Graphics.PreferredBackBufferHeight = (int)((float)1920 * StartingZoomHeight / StartingZoomWidth);
                //Scale = (float)1920 / StartingZoomWidth;
                Game.Graphics.ApplyChanges();
            }

        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            Game.Graphics.PreferredBackBufferWidth = Game.Window.ClientBounds.Width;
            Game.Graphics.PreferredBackBufferHeight = (int)((float)Game.Window.ClientBounds.Width * StartingZoomHeight / StartingZoomWidth);
            //Scale = (float)Window.ClientBounds.Width / StartingZoomWidth;

            Game.Graphics.ApplyChanges();
        }

        public void StartScript(AScript script)
        {
            this.CurrentScript = script;
        }
       
    }
}
