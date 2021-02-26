using Microsoft.Xna.Framework;
using Sprint0.InputControllers;
using Sprint0.Commands.Mapping;

namespace FirstGame
{

    public class FaliureState : IGameState
    {
        public Game1 Game { get; set; }
        public FaliureState(Game1 game)
        {
            Game = game;
            Game.CurrentScene.PauseBackground = false;
            Game.CurrentScene.Controller = new Controller(new FailureCommandMap(Game));
        }

        public void Update(GameTime gameTime)
        {
            Game.CurrentScene.Controller.UpdateInput();
            Game.EntityManager.UpdateEntities(gameTime);
        }

    }
}
