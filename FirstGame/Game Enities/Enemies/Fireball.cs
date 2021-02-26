using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;

namespace Sprint0.Game_Enities.Enemies
{
    class Fireball : EnemyEntity
    {
        public int timeLimit = 10000;
        public int BounceCount = 1;

        public override void Initialize()
        {
            base.Initialize();
        }

        public Fireball(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position, Velocity)
        {
            this.Visible = true;
            this.Velocity = Velocity;
            this.ActionState = new FireBallState(this);
            Initialize();
            this.HitBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 8, 8);
        }

        public override void UpdateEntity(GameTime time)
        {
            //base.UpdateEntity(time);


            PositionOrigin = this.Position;
            if (!((ActionState is InjuredGoomba) && !(ActionState is DeadEnemy)))
            {
                this.CurrentSprite.UpdateSprite(time);
                this.MillisSinceLastUpdate += time.ElapsedGameTime.Milliseconds;

                if (this.MillisSinceLastUpdate > MILLIS_PER_UPDATE)
                {
                    timeLimit -= MILLIS_PER_UPDATE;
                    if (timeLimit <= 0)
                    {
                        this.Visible = false;
                    }
                    this.MillisSinceLastUpdate -= MILLIS_PER_UPDATE;

                    // gravity acceleration  
                    // vertical speed has a limit
                    Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity);
                    if (Velocity.Y > 4)
                    {
                        Velocity = new Vector2(Velocity.X, 4);
                    }

                    //update position
                    Vector2 futurePos = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);

                   
                    this.Position = futurePos;


                    CollisionHandling.Update(this, PositionOrigin);
                    CollisionHandling.DidCollide(this, time);
                    if (BounceCount < 1)
                    {
                        this.Visible = false;
                    }
                    this.HitBox = new Rectangle((int)this.Position.X, (int)this.Position.Y-1, 8, 8);

                }
            }
        }
    }
}
