using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;
using System.Diagnostics;
using Sprint0.InputControllers;
using Sprint0.Commands.Mapping;
using Sprint0.Sounds;

namespace FirstGame
{

    public class PauseState : IGameState
    {
        public Game1 Game { get; set; }
        public PauseState(Game1 game)
        {
            Game = game;
            Game.CurrentScene.PauseBackground = true;
            Game.CurrentScene.Controller = new Controller(new PauseCommandMap(Game));
            SoundManager.PauseAllSound();
        }

        public void Update(GameTime gameTime)
        {
            Game.CurrentScene.Controller.UpdateInput();
        }

    }
}
