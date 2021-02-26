

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;


/* THIS CLASS IS DEPRECIATED */
namespace FirstGame
{
    class GamePadController : IController
    {   
        private GamePadState previousGamePadState;
        private EntityManager spriteController;
        public List<Input> GetInput()
        {
            List<Input> inputs = new List<Input>();
            GamePadState emptyInput = new GamePadState(new GamePadThumbSticks(new Vector2(0, 0), new Vector2(0, 0)), new GamePadTriggers(0, 0), new GamePadButtons(), new GamePadDPad());

            // Get the current GamePad state.
            GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

            // Process input only if connected.
            if (currentGamePadState.IsConnected)
            {
                if (currentGamePadState != emptyInput) // Button Pressed
                {
                    var buttonList = (Buttons[])Enum.GetValues(typeof(Buttons));

                    foreach (var button in buttonList)
                    {
                        if (currentGamePadState.IsButtonDown(button) &&
                            !previousGamePadState.IsButtonDown(button))
                        {
                            Input input = new Input();
                            input.Controller = Input.ControllerType.Gamepad;
                            input.Key = (int)button;
                            inputs.Add(input);
                        }
                    }
                }
            }
            previousGamePadState = currentGamePadState;
            return inputs;
        }

        public GamePadController(EntityManager spriteController)
        {
            this.spriteController = spriteController;
            previousGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public void UpdateInput(Game1 game)
        {
            List<Input> inputs = GetInput();
            foreach (Input input in inputs)
            {
                Debug.WriteLine(input); // Output Input
                //switch (input.Key)
                {/*
                    case (int)Buttons.A:
                        this.spriteController.ToggleVisibility(0);
                        break;

                    case (int)Buttons.B:
                        this.spriteController.ToggleVisibility(1);
                        break;

                    case (int)Buttons.X:
                        this.spriteController.ToggleVisibility(2);
                        break;

                    case (int)Buttons.Y:
                        this.spriteController.ToggleVisibility(3);
                        break;

                    case (int)Buttons.Start:
                        game.Exit();
                        break;
                }*/
                }
            }
        }
    }
}
