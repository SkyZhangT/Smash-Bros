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
using Sprint0.Scenes;

namespace FirstGame
{
    //Test
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Variabless

        /// </summary>
        //Suppressed because this is the correct way to use the graphicdevice
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private GraphicsDeviceManager graphics;
        //private bool ending = false;
        private bool once = true;
        private int lastTime = 0;
        // Random rand = new Random();
        //private Vector2 Fireworkplace { get; set; }
        //This is not a constant, we should probably make Game1 static
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        SpriteBatch spriteBatch;

        //This needs to be externally visible
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ScoreList { private string score; private Vector2 position; private int gameTime; public Vector2 Position { get => position; set => position = value; } public int GameTime { get => gameTime; set => gameTime = value; } public string Score { get => score; set => score = value; } public ScoreList(string score, Vector2 Position, int gameTime) { Score = score; this.Position = Position; GameTime = gameTime; } };

        public bool VisibleHitBox { get; set; }
        public EntityManager EntityManager { get; set; }
        public static readonly float Scale = 1f;
        public bool Once { get => once; set => once = value; }
        public int LastTime { get => lastTime; set => lastTime = value; }

        public Collection<ScoreList> DisplayedScoreList { get; } = new Collection<ScoreList>();
        public FloatingScoreManager FloatingScoreManager { get => floatingScoreManager; set => floatingScoreManager = value; }
        private FloatingScoreManager floatingScoreManager;
        public IScene CurrentScene { get; set; }

        //Player Avatar Type int:
        //0: not set
        //1: Mario
        //2: Luigi
        public int Player1 { get; set; }
        public int Player2 { get; set; }

        //Map type int(level file)
        //0: not set
        //1: Map1
        //2: Map2
        //3: Map3
        public int Level { get; set; }

        //Winner int
        //1: player1
        //2: player2
        public int Winner { get; set; }
        public GraphicsDeviceManager Graphics { get => graphics; set => graphics = value; }
        #endregion

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.ApplyChanges();
            VisibleHitBox = false;
            Content.RootDirectory = "Content";
            Player1 = 0;
            Player2 = 0;
            Level = 1;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

   
        #region Load

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Sound
            Dictionary<String, SoundEffect> soundList = new Dictionary<string, SoundEffect>
            {
                { "jump", Content.Load<SoundEffect>("Sounds/jump-small") },
                { "jump-super", Content.Load<SoundEffect>("Sounds/jump-super") },
                { "1up", Content.Load<SoundEffect>("Sounds/1up") },
                { "bump", Content.Load<SoundEffect>("Sounds/bump") },
                { "coin", Content.Load<SoundEffect>("Sounds/coin") },
                { "fireball", Content.Load<SoundEffect>("Sounds/fireball") },
                { "fireworks", Content.Load<SoundEffect>("Sounds/fireworks") },
                { "grow", Content.Load<SoundEffect>("Sounds/powerup") },
                { "kick", Content.Load<SoundEffect>("Sounds/kick") },
                { "pipe", Content.Load<SoundEffect>("Sounds/pipe") },
                { "powerup", Content.Load<SoundEffect>("Sounds/powerup") },
                { "stomp", Content.Load<SoundEffect>("Sounds/stomp") },
                { "shrink", Content.Load<SoundEffect>("Sounds/pipe") },
                { "dead", Content.Load<SoundEffect>("Sounds/smb_mariodie") },
                { "gameover", Content.Load<SoundEffect>("Sounds/smb_gameover") },
                { "powerupup", Content.Load<SoundEffect>("Sounds/powerupup") },
                { "mariotheme", Content.Load<SoundEffect>("Sounds/mariotheme") },
                { "dktheme", Content.Load<SoundEffect>("Sounds/dktheme") },
                { "bowsertheme", Content.Load<SoundEffect>("Sounds/bowsertheme") },
                { "break", Content.Load<SoundEffect>("Sounds/breakblock") },
                { "theme", Content.Load<SoundEffect>("Sounds/SuperMarioBrosTheme") },
                { "brawltheme", Content.Load<SoundEffect>("Sounds/brawltheme") },
                { "warning", Content.Load<SoundEffect>("Sounds/warning") },
                { "theme1.5", Content.Load<SoundEffect>("Sounds/SuperMarioBrosThemeFaster1.5") },
                //{ "theme1.5", Content.Load<SoundEffect>("Sounds/RX-0") },
                { "ending", Content.Load<SoundEffect>("Sounds/ending") },
                { "star", Content.Load<SoundEffect>("Sounds/starman") },
                { "starfast", Content.Load<SoundEffect>("Sounds/HurryStarman") },

            };
            SoundManager.Load(soundList);
            #endregion

            EntityManager = new EntityManager(spriteBatch, this);
            FloatingScoreManager = new FloatingScoreManager(spriteBatch, this);

            CurrentScene = new StartScene(this);
            CurrentScene.Initialize();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }
        #endregion

        #region Update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime);
            base.Update(gameTime);
        }
        #endregion
        #region Draw
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            CurrentScene.Draw(spriteBatch, gameTime);
            base.Draw(gameTime);
        }







        #endregion

        public void Quit()
        {
            this.Exit();
        }

        #region CameraZoomAndChange





        #endregion


    }
}
