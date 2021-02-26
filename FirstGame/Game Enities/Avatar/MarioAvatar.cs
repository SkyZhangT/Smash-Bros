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
    public class MarioAvatar : AvatarMain
    {
       public MarioAvatar(Game1 game, ISprite initialSprite, Vector2 position, int playerNumber, string name) : base(game, initialSprite, position, playerNumber)
        {
            this.CurrentActionState = new IdleState(Game, this);
            this.CurrentPowerState = new SmallMarioPowerUpState(Game, this);
            this.Name = name;
        }
    }
}
