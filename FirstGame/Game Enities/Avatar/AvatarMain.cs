using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;
using System.Diagnostics;
using Sprint0.Game_Enities.Enemies;
using Sprint0.Scripts;
using Sprint0.Sounds;
using System.Collections.Generic;

namespace Sprint0.Game_Enities.Avatar
{
    public class AvatarMain : IEntity
    {
        public static readonly float JUMP_ACCEL_FACING = .1f;
        public static readonly float JUMP_ACCEL_NOT_FACING = .1f;

        public IEntity Master { get; set; }
        public static readonly float JUMP_VEL = -4f;
        public bool PhysicsEnabled { get; set; }

        private static readonly int MILLIS_PER_UPDATE = 10;

        public Color Indicator { get; set; }//Collision indicator
        public bool FacingRight { get; set; }//facing left is false right is true

        public IActionState CurrentActionState { get; set; }
        public IPowerUpState CurrentPowerState { get; set; }

        public ISprite CurrentSprite { get; set; }

        public bool Visible { get; set; }

        public Game1 Game { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle HitBox { get; set; }

        public Color HitBoxColor { get; set; }
        public ICollision Collision { get; set; }
        protected const int TimeDelay = 200;


        public Vector2 Velocity { get; set; }
        public float Gravity { get; set; }
        public IState ActionState { get; set; }
        public float AccelX { get; set; }

        private int millisSinceLastUpdate;
        public IBlockState CurrentState { get; set; }

        public int LifeLeft { get; set; }
        private int starTime = 0;

        public string Name { get; set; }
        public Vector2 TPosition { get; set; }
        public int StarTime { get => starTime; set => starTime = value; }
        private int playerNumber;
        private String itemHeld = "None";
        private int fireBallLeft = 0;

        public int Damage { get; set; }
        public int FireBallLeft { get => fireBallLeft; set => fireBallLeft = value; }
        public string ItemHeld { get => itemHeld; set => itemHeld = value; }
        protected int MillisSinceLastUpdate { get => millisSinceLastUpdate; set => millisSinceLastUpdate = value; }
        public int PlayerNumber { get => playerNumber; set => playerNumber = value; }

        public AvatarMain(Game1 game, ISprite initialSprite, Vector2 position, int playerNumber)
        {
            PlayerNumber = playerNumber;
            this.Damage = 0;
            this.AccelX = 0;
            this.Gravity = 0.08f;
            this.Velocity = new Vector2(0, 0);
            this.PhysicsEnabled = true;
            this.MillisSinceLastUpdate = 0;
            Position = position;
            Visible = true;
            Game = game;
            CurrentSprite = initialSprite;
            FacingRight = CurrentSprite.NeedFlip;
            Indicator = Color.White;
            HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 3);
            HitBoxColor = Color.Yellow;
        }

        public virtual void UpdateEntity(GameTime time)
        {
            /*if (Damage < 0)
            {
                Damage = 0;
            }*/

            if (!(Game.CurrentScene.CurrentScript is EndScript))
            {
                this.CurrentActionState.Update(time);
            }

            this.CurrentSprite.UpdateSprite(time);
            if (!Game.CurrentScene.GrowPause)
            {
                this.MillisSinceLastUpdate += time.ElapsedGameTime.Milliseconds;

                if (this.MillisSinceLastUpdate > MILLIS_PER_UPDATE)
                {
                    this.MillisSinceLastUpdate -= MILLIS_PER_UPDATE;

                    UpdateVel();

                    SetFuturePos();

                    // *******Check for collisions*********
                    CheckCollision(time);

                    //The avatar shouldnt change its own state, but it fixes the bug
                    if (this is MarioAvatar)
                    {
                        if (this.Velocity.Y > 0 && !(this.CurrentActionState is JumpState) && !(this.CurrentActionState is FireBallThrow) && !(this.CurrentActionState is PunchState) && !(this.CurrentActionState is DeadState) && !(this.CurrentActionState is StunState))
                        {
                            this.CurrentActionState = new JumpState(this.Game, this,true);
                        }
                    }
                    else
                    {
                        if (this.Velocity.Y > 0 && !(this.CurrentActionState is TurtleJumpState) && !(this.CurrentActionState is TurtleFireBallThrow) && !(this.CurrentActionState is TurtleDeadState) && !(this.CurrentActionState is TurtleStunState) && !(this.CurrentActionState is TurtlePunchState))
                        {
                            this.CurrentActionState = new TurtleJumpState(this.Game, this);
                        }
                    }

                    if (ActionState != null)
                    {
                        if (StarTime == 0)
                        {
                            SoundManager.PlaySound("star");
                            SoundManager.backGroundMusic.Pause();
                        }
                        starTime += time.ElapsedGameTime.Milliseconds;
                        if (starTime > 14000 && starTime < 15000)
                        {
                            if (Indicator == Color.Red)
                            {
                                Indicator = Color.Black;
                            }
                            else
                            {
                                Indicator = Color.Red;
                            }
                        }
                        else if (starTime < 15000)
                        {
                            if (ActionState is StarMarioPowerUpState)
                            {
                                UpdateStar();
                            }
                        }
                        else
                        {
                            Indicator = Color.White;
                            ActionState = null;
                            StarTime = 0;
                            SoundManager.backGroundMusic.Resume();
                        }
                    }
                }
            }
        }

        public virtual void Initialize()
        {
            Collision = new AvatarCollision(Game, this);       
        }

        public virtual void ThrowFireBall()
        {
            if (FireBallLeft > 0)
            {
                ISprite Fireball;
                if (this is MarioAvatar)
                {
                    if(this.Name is "Mario")
                    {
                        Fireball = BlockFactory.AllBlockFactory(Game, "fireball");
                    }
                    else
                    {
                        Fireball = BlockFactory.AllBlockFactory(Game, "greenfireball");
                    }
                }
                else
                {
                    Fireball = BlockFactory.AllBlockFactory(Game, "bluefireball");
                }
                if (FacingRight)
                {
                    Fireball f = new Fireball(Game, Fireball, this.Position, new Vector2(2, 0));
                    f.Master = this;
                    Game.EntityManager.AddEntity(f);
                }
                else
                {
                    Fireball f = new Fireball(Game, Fireball, this.Position, new Vector2(-2, 0));
                    f.Master = this;
                    Game.EntityManager.AddEntity(f);
                }
                FireBallLeft--;
            }
        }

        public virtual void Meteorite()
        {

            //fireball direction detection
            SoundManager.PlaySound("warning");
            IEntity targetAvatar;
            if (Game.CurrentScene.PlayerAvatar == this)
            {
                targetAvatar = Game.CurrentScene.PlayerAvatar2;
            }
            else
            {
                targetAvatar = Game.CurrentScene.PlayerAvatar;
            }

            Vector2 direction = targetAvatar.Position - new Vector2(Position.X, Position.Y - 30);

            Vector2 target = new Vector2(5 * direction.X / direction.Length(), 5 * direction.Y / direction.Length());


            //create fireball

            List<Vector2> positions = new List<Vector2>();
            positions.Add(new Vector2(Position.X, Position.Y - 30));
            positions.Add(new Vector2(Position.X, Position.Y - 40));
            positions.Add(new Vector2(Position.X, Position.Y - 50));
            positions.Add(new Vector2(Position.X - 10, Position.Y - 45));
            positions.Add(new Vector2(Position.X - 10, Position.Y - 35));
            positions.Add(new Vector2(Position.X + 10, Position.Y - 45));
            positions.Add(new Vector2(Position.X + 10, Position.Y - 35));

            ISprite fireball;
           
            if(this.Name is "Mario")
            {
                fireball = BlockFactory.AllBlockFactory(Game, "fireball");
            }
            else
            {
                fireball = BlockFactory.AllBlockFactory(Game, "greenfireball");
            }
            
            foreach (Vector2 pos in positions)
            {
                Fireball f = new Fireball(Game, fireball, pos, target);
                f.Master = this;
                Game.EntityManager.AddEntity(f);
            }
        }

        public virtual void TURTLES()
        {
            SoundManager.PlaySound("warning");
            Random rand = new Random();
            for(int i=0;i<11;i++)
            {
                Koopa f = new Koopa(Game, EnemyFactory.CreateSprite(Game,"GreenKoopa"), new Vector2(rand.Next(0,(int)Game.CurrentScene.FirstBottomRightBoundary.X),0), new Vector2(rand.Next(-2,2),0) );
                f.Master = this;
                Game.EntityManager.AddEntity(f);
                f.Initialize();
            }
        }
        

        public virtual void Launch(double modifier)
        {
            if (ActionState is null)
            {
                Random r = new Random();
                int modDamage = (int)(modifier * (this.Damage + 1));
                float yvel = r.Next(0, modDamage) / 10;
                float xvel = Damage / 10 - yvel;
                int yneg = r.Next(0, 2);
                int xneg = r.Next(0, 2);

                if (yneg == 0)
                {
                    yvel = -yvel;
                }
                if (xneg == 0)
                {
                    xvel = -xvel;
                }
                if(CurrentActionState is JumpState)
                {
                    this.CurrentActionState = new JumpState(Game, this, true);
                }
                this.Velocity = new Vector2(xvel, yvel);
            }
        }
        public virtual void CheepCheepItem()
        {
            ItemHeld = "CheepCheep";
        }
        public virtual void ThwompItem()
        {
            ItemHeld = "Thwomp";
        }
        public virtual void BulletBillItem()
        {
            ItemHeld = "BulletBill";
        }
        public virtual void UseItem()
        {
            switch (ItemHeld)
            {
                case "CheepCheep":
                    CheepCheep();
                    break;
                case "Thwomp":
                    Thwomp();
                    break;
                case "BulletBill":
                    BulletBill();
                    break;
            }
            ItemHeld = "none";
        }
        public virtual void CheepCheep()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                float mvmnt = (float)random.Next(1, 4);
                Game.EntityManager.AddEntity(new CheepCheep(Game, BlockFactory.AllBlockFactory(Game, "fish"), new Vector2(0 - 100 * i, Position.Y - mvmnt * i * 3), Vector2.Zero, mvmnt, this));
            }
        }

        public virtual void Thwomp()
        {
            IEntity thwomp = new Thwomp(Game, BlockFactory.Thwomp(Game), new Vector2(this.Position.X, this.Position.Y - 200), Vector2.Zero, PlayerNumber);
            Game.EntityManager.AddEntity(thwomp);
            Game.CurrentScene.ThwompItem = thwomp;
        }
        public virtual void BulletBill()
        {
            BulletBill b = new BulletBill(Game, BlockFactory.BulletBill(Game), new Vector2(Game.CurrentScene.MainLevel.BottomRightBoundary.X + 160, Position.Y - 70), Vector2.Zero, this);
            Game.EntityManager.AddEntity(b);
            Game.CurrentScene.ThwompItem = b;

        }
        private void CheckCollision(GameTime time)
        {
            if (PhysicsEnabled)
            {
                if (this is MarioAvatar)
                {
                    if (CurrentPowerState is SmallMarioPowerUpState)
                    {
                        HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 3);
                    }
                    else
                    {
                        HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 3);

                    }
                }
                else
                {
                    HitBox = new Rectangle((int)Position.X + 2, (int)Position.Y + 1, CurrentSprite.FrameSize.X - 4, CurrentSprite.FrameSize.Y - 3);
                }

                CollisionHandling.Update(this, this.Position);
                CollisionHandling.DidCollide(this, time);
            }
        }

        private void SetFuturePos()
        {
            Vector2 futurePos = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);


            if (this.Position.Y + this.Velocity.Y + this.CurrentSprite.FrameSize.Y >= this.Game.CurrentScene.FirstBottomRightBoundary.Y + 200 && !(this.CurrentActionState is DeadState) && !(this.CurrentActionState is TurtleDeadState))
            {

                this.CurrentPowerState = new SmallMarioPowerUpState(Game, this);
                this.CurrentPowerState = this.CurrentPowerState.Hit();
            }
            else if (this.Position.X + this.Velocity.X + this.CurrentSprite.FrameSize.X >= this.Game.CurrentScene.FirstBottomRightBoundary.X + 400 && !(this.CurrentActionState is DeadState) && !(this.CurrentActionState is TurtleDeadState))
            {

                this.CurrentPowerState = new SmallMarioPowerUpState(Game, this);
                this.CurrentPowerState = this.CurrentPowerState.Hit();
            }
            else if (this.Position.X + this.Velocity.X + this.CurrentSprite.FrameSize.X <= -400 && !(this.CurrentActionState is DeadState) && !(this.CurrentActionState is TurtleDeadState))
            {

                this.CurrentPowerState = new SmallMarioPowerUpState(Game, this);
                this.CurrentPowerState = this.CurrentPowerState.Hit();
            }
            else if (this.Position.Y + this.Velocity.Y + this.CurrentSprite.FrameSize.Y <= -200 && !(this.CurrentActionState is DeadState) && !(this.CurrentActionState is TurtleDeadState))
            {

                this.CurrentPowerState = new SmallMarioPowerUpState(Game, this);
                this.CurrentPowerState = this.CurrentPowerState.Hit();
            }
            this.Position = futurePos;
        }

        private void UpdateVel()
        {
            if (Math.Abs(this.Velocity.Y) <= Math.Abs(JUMP_VEL))
            {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + Gravity);
            }

            if (AccelX.CompareTo(0) != 0 && ((this.Velocity.X >= 2 && this.AccelX < 0) || (this.Velocity.X <= -2 && this.AccelX > 0) || (Math.Abs(this.Velocity.X) < 2)))
            {
                this.Velocity = new Vector2(this.Velocity.X + AccelX, this.Velocity.Y);
            }

            else if (AccelX.CompareTo(0) == 0 && this.Velocity.X != 0)
            {

                if (Math.Abs(this.Velocity.X).CompareTo(.1f) < 0)
                {
                    this.Velocity = new Vector2(0, this.Velocity.Y);
                }
                else if (this.Velocity.X < 0)
                {
                    this.Velocity = new Vector2(this.Velocity.X + .1f, this.Velocity.Y);
                }
                else
                {
                    this.Velocity = new Vector2(this.Velocity.X - .1f, this.Velocity.Y);
                }
            }
        }

        private void UpdateStar()
        {
            if (Indicator == Color.White)
            {
                Indicator = Color.Red;
            }
            else if (Indicator == Color.Red)
            {
                Indicator = Color.Yellow;
            }
            else if (Indicator == Color.Yellow)
            {
                Indicator = Color.Blue;
            }
            else if (Indicator == Color.Blue)
            {
                Indicator = Color.White;
            }
        }
    }
}
