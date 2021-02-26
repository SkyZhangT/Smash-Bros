using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;

namespace Sprint0.Game_Enities.Enemies
{
    class PiranhaPlantEntity : EnemyEntity
    {

        int Height { get; set; }
        
        public override void Initialize()
        {
            base.Initialize();
            this.ActionState = new PiranhaPlantHidden(this);
        }

        public PiranhaPlantEntity(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity) : base(game, initialSprite, Position, Velocity)
        {
            this.Game = game;
            this.Visible = true;
            this.Height = this.CurrentSprite.FrameSize.Y;
            //this.Direction = -1;
            //this.original_position = Position;
            Console.WriteLine("Height: " + this.Height);
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            if(ActionState is DeadEnemy)
            {
                base.UpdateEntity(gameTime);
            }
            else
            {
                TimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeElapsed >= TimeDelay - 150)
                {
                    PositionOrigin = this.Position;
                    ActionState.Update(gameTime);
                    TimeElapsed = 0;
                    if (Indicator == Color.Red)
                    {
                        Indicator = Color.White;
                        TimeElapsed = 0;
                    }
                    CollisionHandling.Update(this, PositionOrigin);
                }
                CurrentSprite.UpdateSprite(gameTime);
            }
           
        }
    }
}
