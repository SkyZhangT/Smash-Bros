using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Mapping;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sprint0.InputControllers
{
    public class Controller
    {
        private KeyboardState previousKeyboardState;
        private readonly GamePadState[] previousGamePadStates;
        private ICommandMap commandMap;
        

        private static readonly int MAX_CONTROLLERS = 4;

        //Supressed warning as a dynamic Collection is needed
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public Collection<Collection<Input>> Poll()
        {
            Collection<Input> pressedButtons = new Collection<Input>();
            Collection<Input> releasedButtons = new Collection<Input>();

            #region Update Keyboard
            // Get the current Keyboard state.
            KeyboardState currentKeyboardState = Keyboard.GetState();

            Keys[] keysPressed = currentKeyboardState.GetPressedKeys();
            
            foreach (Keys key in keysPressed)
                if (!previousKeyboardState.IsKeyDown(key))
                {
                    Input input = new Input
                    {
                        Controller = Input.ControllerType.Keyboard,
                        Key = (int)key
                    };
                    pressedButtons.Add(input);
                }
            foreach(Keys key in previousKeyboardState.GetPressedKeys())
            {
                if (!currentKeyboardState.IsKeyDown(key))
                {
                    Input input = new Input
                    {
                        Controller = Input.ControllerType.Keyboard,
                        Key = (int)key
                    };
                    releasedButtons.Add(input);
                }
            }
        
            // Update previous Keyboard state.
            previousKeyboardState = currentKeyboardState;
            #endregion

            GamePadState emptyInput = new GamePadState(new GamePadThumbSticks(new Vector2(0, 0), new Vector2(0, 0)), new GamePadTriggers(0, 0), new GamePadButtons(), new GamePadDPad());

            // Get the current GamePad state.

            for (int i = 0; i < MAX_CONTROLLERS; i++)
            {
                GamePadState currentGamePadState = GamePad.GetState(i);

                // Process input only if connected.
                if (currentGamePadState.IsConnected)
                {
                    if (currentGamePadState != emptyInput) // Button Pressed
                    {
                        var buttonCollection = (Buttons[])Enum.GetValues(typeof(Buttons));

                        foreach (var button in buttonCollection)
                        {
                            if (currentGamePadState.IsButtonDown(button) &&
                                !previousGamePadStates[i].IsButtonDown(button))
                            {
                                Input input = new Input
                                {
                                    Controller = Input.ControllerType.Gamepad,
                                    Key = (int)button
                                };
                                pressedButtons.Add(input);
                            }
                        }
                    }
                }
                previousGamePadStates[i] = currentGamePadState;
            }
            Collection<Collection<Input>> inputs = new Collection<Collection<Input>>
            {
                pressedButtons,
                releasedButtons
            };
            return inputs;
        }
        public Controller(ICommandMap commandMap)
        {
            this.commandMap = commandMap;
            previousKeyboardState = Keyboard.GetState();
            previousGamePadStates = new GamePadState[MAX_CONTROLLERS];
            for (int i = 0; i < MAX_CONTROLLERS; i++)
            {
                previousGamePadStates[i] = GamePad.GetState(i);
            }
        }

        public void UpdateInput()
        {
            Collection<Collection<Input>> inputs = Poll();
            foreach (Input input in inputs[0])
            {
                Debug.WriteLine("Key pressed: "+input); // Output Input
                commandMap.GetCommand(input.Key).Execute();
            }
            foreach (Input input in inputs[1])
            {
                Debug.WriteLine("Key released: "+input); // Output key released
                commandMap.GetCommand(input.Key).Undo();
            }
        }
    }
}
