using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;

namespace Sprint0.Game_Enities.Items
{
    public abstract class ItemEntity: IEntity
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
        protected const int TimeDelay = 200;
        private int timeElapsed = 0;
        public IState ActionState { get; set; }
       // public IState PowerState { get; set; }
        public Vector2 Velocity { get; set; }
        public float Gravity { get; set; }
        public IActionState CurrentActionState { get; set; }
        public IPowerUpState CurrentPowerState { get; set; }
        public IBlockState CurrentState { get; set; }
        protected int TimeElapsed { get => timeElapsed; set => timeElapsed = value; }
        public int LifeLeft { get; set; }

        public string Name { get; set; }
        public Vector2 TPosition { get; set; }
        public bool PhysicsEnabled { get; set; }


        protected ItemEntity(Game1 game, ISprite initialSprite, Vector2 position,Vector2 velocity)
        {
            this.Velocity = velocity;
            this.Position = position;
            Visible = true;
            Game = game;
            CurrentSprite = initialSprite;
            Indicator = Color.White;
            HitBox = new Rectangle((int)Position.X, (int)position.Y, CurrentSprite.FrameSize.X, CurrentSprite.FrameSize.Y);
            HitBoxColor = Color.Green;
            Gravity = .4f;
        }

        public virtual void Initialize()
        {
            Collision = new ItemCollision(Game,this);
        }

        //move to collision class
        public virtual void Hit(String direction, IEntity entityHit, GameTime gametime)
        {

        }

        public virtual void UpdateEntity(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, CurrentSprite.FrameSize.X, CurrentSprite.FrameSize.Y);
            Vector2 OriginalPosition = Position;
            this.Position = new Vector2(this.Position.X, this.Position.Y + Gravity);
            CollisionHandling.Update(this, OriginalPosition);
            CollisionHandling.DidCollide(this, gameTime);
        }
    }
}
