using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    class PiranhaPlantHidden : IState
    {
        public IEntity Entity { get; set; }
        // private int Iter { get; set; }
        public Game1 Game { get; set; }
        private int timeElapsed;
        public PiranhaPlantHidden(IEntity entity)
        {
            this.Entity = entity;
            Entity.HitBox = new Rectangle(-1,-1,-1,-1);
            timeElapsed = 0;
        }
        public void Update(GameTime time)
        {
            timeElapsed += time.ElapsedGameTime.Milliseconds;
            if (!(Math.Abs(Entity.Position.X - Entity.Game.CurrentScene.PlayerAvatar.Position.X) < 30)&&timeElapsed>300)
            {
                Entity.ActionState = new PiranhaPlantRise(Entity);
            }
        }

    }
}
