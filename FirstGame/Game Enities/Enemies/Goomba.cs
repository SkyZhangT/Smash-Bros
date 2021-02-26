using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;

namespace Sprint0.Game_Enities.Enemies
{
    class Goomba : EnemyEntity
    {
        
        
        public override void Initialize()
        {
            base.Initialize();
            this.ActionState = new AliveGoomba(this);
        }

        public Goomba(Game1 game, ISprite initialSprite, Vector2 Position,Vector2 Velocity):base(game,initialSprite,Position,Velocity)
        {

            this.Visible = true;
            this.ActionState = new AliveGoomba(this);
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            base.UpdateEntity(gameTime);
            
        }

        
    }
}
