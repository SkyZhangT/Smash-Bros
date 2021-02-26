using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.State.BlockStates;
using Sprint0.Collision;
using System;

namespace Sprint0.Game_Enities.Blocks
{
    public class BlockEntity:IBlockEntity
    {
        public IEntity Master { get; set; }
        public Color Indicator { get; set; }//Collision indicator
        public bool FacingRight { get; set; }
        public bool Visible { get; set; }
        public ISprite CurrentSprite { get; set; }
        public Game1 Game { get; set; }
        public Vector2 Position { get; set; }
        public int CoinLeft { get; set; }
        public IBlockState CurrentState { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
        public Rectangle HitBox { get; set; }
        public Color HitBoxColor { get; set; }
        public ICollision Collision { get; set; }
        public IState ActionState { get;set; }
       // public IState PowerState { get; set; }
        public IActionState CurrentActionState { get; set; }
        public IPowerUpState CurrentPowerState { get; set; }
        //Property to get rid of warning
        public Vector2 Velocity { get; set; }
        public float Gravity { get; set; }
        protected int TimeElapsed { get => timeElapsed; set => timeElapsed = value; }
        protected int TimeElapsed2 { get => timeElapsed; set => timeElapsed = value; }
        protected const int TimeDelay = 200;
        private int timeElapsed = 0;
        public int LifeLeft { get; set; }
        public Vector2 TPosition { get; set; }
        public bool PhysicsEnabled { get; set; }

        public virtual void Initialize()
        {
            Collision = new BlockCollision(this);
            CurrentState = new StaticBlockState(Game,this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "time")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "direction")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "entityHit")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Hit(String direction, IEntity entityHit, GameTime time)
        {
            //to be implemented later
        }
        public BlockEntity(Game1 game, string name, Vector2 position, Vector2 tPosition)
        {
            Gravity = 0.8f;
            Position = position;
            Game = game;
            Name = name;
            TPosition = tPosition;
            CoinLeft = -1;
            Visible = true;
            Indicator = Color.White;
            HitBoxColor = Color.Blue;
        }

        public virtual void UpdateEntity(GameTime gameTime)
        {
            /* This statement will be here until a better way to update entity positions is used */
            if ((HitBox.X != Position.X || HitBox.Y != Position.Y) && Name != "BreakBrick")
            {
                HitBox = new Rectangle((int)Position.X, (int)Position.Y, CurrentSprite.FrameSize.X, CurrentSprite.FrameSize.Y);
            }
            else if(Name == "BreakBrick")
            {
                HitBox = new Rectangle(1, 1, 0, 0);
            }
            CurrentSprite.UpdateSprite(gameTime);

            if (Indicator == Color.Brown)
            {
                TimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeElapsed >= TimeDelay)
                {
                    Indicator = Color.White;
                    TimeElapsed = 0;
                }
            }
        }
    }
}
