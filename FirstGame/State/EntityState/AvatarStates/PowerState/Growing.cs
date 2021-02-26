﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.State;
using System;

namespace FirstGame
{
    class Growing : IPowerUpState, IState
    {
        public IEntity Entity { get; set; }
        private IEntity Avatar;

        public Game1 Game { get; set; }

        public Growing(Game1 game, IEntity avatar)
        {
            this.Avatar = avatar;
            if (avatar is MarioAvatar)
            {
                Avatar.CurrentSprite = AvatarFactory.GrowingAvatar(game, Avatar.Name);
                this.Avatar.FacingRight = !this.Avatar.FacingRight;
            }
            Avatar.Velocity = Vector2.Zero;
            game.CurrentScene.TimeSinceLast = 0;
            game.CurrentScene.GrowPause = true;
            // Avatar.CurrentActionState.Update();
            Game = game;
            SoundManager.PlaySound("grow");
        }

        public IPowerUpState PromoteMario()
        {
            Avatar.CurrentActionState = new IdleState(Game, Avatar);
            return new SmallMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteSuperMario()
        {
            return new SuperMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState PromoteFireMario()
        {
            Avatar.CurrentActionState = new IdleState(Game, Avatar);

            return new FireMarioPowerUpState(Game, Avatar);
        }

        public IPowerUpState Hit()
        {
            return new DeadMarioPowerUpState(Game, Avatar);
        }
        public void Update(GameTime time)
        {
            //NOT IMPLEMENTED
        }
        public IState PromoteStarMario()
        {
            return new StarMarioPowerUpState(Game, Avatar);
        }
    }
}