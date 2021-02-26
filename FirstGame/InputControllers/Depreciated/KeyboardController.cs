using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FirstGame
{
    class KeyboardController : IController
    {
        private KeyboardState previousKeyboardState;
        private EntityManager spriteController;
        public List<Input> GetInput()
        {
            List<Input> inputs = new List<Input>();
            
            // Get the current Keyboard state.
            KeyboardState currentKeyboardState = Keyboard.GetState();

            Keys[] keysPressed = currentKeyboardState.GetPressedKeys();
            foreach (Keys key in keysPressed)
                if (!previousKeyboardState.IsKeyDown(key))
                {
                    Input input = new Input();
                    input.Controller = Input.ControllerType.Keyboard;
                    input.Key = (int)key;
                    inputs.Add(input);
                }

            // Update previous Keyboard state.
            previousKeyboardState = currentKeyboardState;
            return inputs;
        }

        public KeyboardController(EntityManager spriteController)
        {
            this.spriteController = spriteController;
            previousKeyboardState = Keyboard.GetState();
        }

        public void UpdateInput(Game1 game)
        { 
            List<Input> inputs = GetInput();
            foreach (Input input in inputs)
            {
                Console.WriteLine(input); // Output Input
                
               // switch (input.Key)
                //{
                   /* 
                    case (int)Keys.W:
                        this.spriteController.ToggleVisibility(0); 
                        break;

                    case (int)Keys.E:
                        this.spriteController.ToggleVisibility(1);
                        break;

                    case (int)Keys.R:
                        this.spriteController.ToggleVisibility(2);
                        break;

                    case (int)Keys.T:
                        this.spriteController.ToggleVisibility(3);
                        break;

                    case (int)Keys.Q:
                        game.Exit();
                        break;
                }*/
            }
        }
    }
}
