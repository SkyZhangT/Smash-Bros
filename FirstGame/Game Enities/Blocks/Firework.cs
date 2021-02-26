﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sounds;
using Sprint0.State.BlockStates;

namespace Sprint0.Game_Enities.Blocks
{
    class Firework : IEntity
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
        public Vector2 TPosition { get; set; }

        public string Name { get; set; }
        public bool PhysicsEnabled { get; set; }


        public void Initialize()
        {
        }
        public Firework(Vector2 position, ISprite initialSprite, Game1 game)
        {
            Position = position;
            Visible = true;
            Game = game;
            this.CurrentSprite = initialSprite;
            SoundManager.PlaySound("fireworks");
            Indicator = Color.White;
        }

        public void UpdateEntity(GameTime gameTime)
        {
            if (this.CurrentSprite.CurrentFrame.X == 3)
            {
                this.Visible = false;
            }
            this.CurrentSprite.UpdateSprite(gameTime);
        }
    }
}