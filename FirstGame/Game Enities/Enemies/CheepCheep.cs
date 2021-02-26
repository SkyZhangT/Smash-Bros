using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Avatar;

namespace Sprint0.Game_Enities.Enemies
{
    class CheepCheep : EnemyEntity
    {

        //int Height { get; set; }
        public override void Initialize()
        {
            base.Initialize();
        }

        public CheepCheep(Game1 game, ISprite initialSprite, Vector2 Position, Vector2 Velocity, float mvmnt, IEntity PlayerNumber) : base(game, initialSprite, Position, Velocity)
        {
            this.Game = game;
            this.Visible = true;
            //this.Height = 300;
            this.ActionState = new Fish(this,mvmnt);
            base.Initialize();
            this.Master = PlayerNumber;
            this.FacingRight = true;
            if(this.Master is MarioAvatar)
            {
                if (this.Master.Name is "Mario")
                    Indicator = Color.Lerp(Color.White, Color.Red, .5f);
                else
                    Indicator = Color.Lerp(Color.White, Color.Green, .5f);
            }
            else
            {
                Indicator = Color.Lerp(Color.White, Color.Blue, .5f);
            }
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            PositionOrigin = this.Position;
            ActionState.Update(gameTime);
            CurrentSprite.UpdateSprite(gameTime);
            CollisionHandling.Update(this, PositionOrigin);
        }
    }
}
