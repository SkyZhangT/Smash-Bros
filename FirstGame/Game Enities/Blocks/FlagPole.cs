using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.EntityState.BlockStates;
using Sprint0.State.BlockStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Game_Enities.Blocks
{
    class FlagPole: IEntity
    {
        public IEntity Master { get; set; }
        public Vector2 Position { get; set; }
        public bool FacingRight { get; set; }
        public bool Visible { get; set; }
        public Vector2 Velocity { get; set; }
        public float Gravity { get; set; }
        public int LifeLeft { get; set; }
        public ISprite CurrentSprite { get; set; }
        public Rectangle HitBox { get; set; }
        public Color HitBoxColor { get; set; }
        public Game1 Game { get; set; }
        public Color Indicator { get; set; }
        public ICollision Collision { get; set; }
        public IState ActionState { get; set; }
        public IActionState CurrentActionState { get; set; }
        public IPowerUpState CurrentPowerState { get; set; }
        public IBlockState CurrentState { get; set; }
        public FlagEntity Flag { get; set; }
        public Vector2 TPosition { get; set; }

        public string Name { get; set; }
        public bool PhysicsEnabled { get; set; }


        public void Initialize()
        {
            Collision = new BlockCollision(this);
        }
        public FlagPole(Vector2 position, FlagEntity flag, ISprite initialSprite,Game1 game)
        {
            Gravity = 0.8f;
            Game = game;
            Position = position;
            Visible = true;
            Indicator = Color.White;
            HitBoxColor = Color.Blue;
            this.Flag = flag;
            this.CurrentSprite = initialSprite;
            ActionState = new FlagNotHitState(this, Game);
        }

        public void UpdateEntity(GameTime gameTime)
        {
            if (ActionState is FlagHitState)
            {
                ActionState.Update(gameTime);
            }
        }
    }
}
