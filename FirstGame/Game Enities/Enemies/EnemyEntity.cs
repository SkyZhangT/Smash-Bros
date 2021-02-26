using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;
using Sprint0.Game_Enities.Avatar;

namespace Sprint0.Game_Enities.Enemies
{
    public abstract class EnemyEntity : IEntity
    {

        public IEntity Master { get; set; }
        public Color Indicator { get; set; }//Collision indicator
        public bool FacingRight { get; set; }
        public Vector2 Position { get; set; }
        public bool Visible { get; set; }
        public ISprite CurrentSprite { get; set; }
        public Game1 Game { get; set; }
        public Rectangle HitBox { get; set; }
        public Color HitBoxColor { get; set; }
        public ICollision Collision { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 ExpectedVelocity { get; set; }
        public float Gravity { get; set; }
        public IActionState CurrentActionState { get; set; }
        public IPowerUpState CurrentPowerState { get; set; }
        public IBlockState CurrentState { get; set; }
        public Vector2 PositionOrigin { get; set; }
        public Vector2 TPosition { get; set; }
        public bool PhysicsEnabled { get; set; }

        //Property to get rid of warning
        protected int TimeElapsed { get => timeElapsed; set => timeElapsed = value; }

        protected const int TimeDelay = 200;
        private int timeElapsed = 0;
        public IState ActionState { get; set; }
        public int MillisSinceLastUpdate { get => millisSinceLastUpdate; set => millisSinceLastUpdate = value; }
        public int LifeLeft { get; set; }

        public string Name { get; set; }


        //public IState PowerState { get; set; }
        public static readonly int MILLIS_PER_UPDATE = 10;
        private int millisSinceLastUpdate;
        private bool EngageFlag;


        protected EnemyEntity(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity)
        {
            this.Position = Position;
            this.EngageFlag = false;
            this.ExpectedVelocity = Velocity;
            this.Velocity = new Vector2(0, 0);
            this.Gravity = .1f;
            this.Visible = true;
            this.Game = game;
            this.CurrentSprite = initialSprite;
            Indicator = Color.White;
            HitBox = new Rectangle((int)Position.X+1, (int)Position.Y+1, CurrentSprite.FrameSize.X-2, CurrentSprite.FrameSize.Y-2);
            HitBoxColor = Color.Red;
        }

        public virtual void Initialize()
        {
            Collision = new EnemyCollision(this);
        }

        public virtual void UpdateEntity(GameTime gameTime)
        {
            PositionOrigin = this.Position;
            ActionState.Update(gameTime);          
            // detect if the enemy enter the window
            if(Position.X < (Game.CurrentScene.Camera.Position.X + (Game.GraphicsDevice.Viewport.Width/Game1.Scale))&&Position.X>=((Game.CurrentScene.Camera.Position.X)-CurrentSprite.FrameSize.X))
            {
                if (!EngageFlag)
                {
                    // chase mario with assigned speed
                    if (Game.CurrentScene.PlayerAvatar.Position.X < this.Position.X)
                    {
                        Velocity = new Vector2(-Math.Abs(ExpectedVelocity.X * 0.5f), Velocity.Y);
                        EngageFlag = true;
                    }
                    else
                    {
                        Velocity = new Vector2(Math.Abs(ExpectedVelocity.X * 0.5f), Velocity.Y);
                        EngageFlag = true;
                        FacingRight = true;
                    }
                }
            }
            
            
            if (!((ActionState is InjuredGoomba)&&!(ActionState is DeadEnemy) && EngageFlag))
            {
                this.CurrentSprite.UpdateSprite(gameTime);
                this.MillisSinceLastUpdate += gameTime.ElapsedGameTime.Milliseconds;
                if (EngageFlag)
                {
                    if (this.MillisSinceLastUpdate > MILLIS_PER_UPDATE)
                    {
                        this.MillisSinceLastUpdate -= MILLIS_PER_UPDATE;

                        // gravity acceleration  
                        // vertical speed has a limit
                        Velocity =new Vector2(Velocity.X,Velocity.Y+ Gravity);
                        if (Velocity.Y > 4)
                        {
                            Velocity = new Vector2(Velocity.X, 4);
                        }

                        //update position
                        Vector2 futurePos = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);

                       

                        this.Position = futurePos;
                    }

                    CollisionHandling.Update(this, PositionOrigin);
                    CollisionHandling.DidCollide(this, gameTime);
                }
            }
        }
    }
}
