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

    public class WinState : IGameState
    {
        public Game1 Game { get; set; }
        public WinState(Game1 game)
        {
            Game = game;
            Game.CurrentScene.PauseBackground = false;
            Game.CurrentScene.Controller = new Controller(new EndingCommandMap(Game));
        }

        public void Update(GameTime gameTime)
        {
            Game.CurrentScene.Controller.UpdateInput();
            Game.EntityManager.UpdateEntities(gameTime);
        }

    }
}
