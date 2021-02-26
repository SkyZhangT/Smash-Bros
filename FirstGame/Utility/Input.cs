using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGame
{
    public class Input
    {
        public enum ControllerType
        {
            [Description("Undefined")]
            Undefined,
            [Description("Keyboard")]
            Keyboard,
            [Description("Gamepad")]
            Gamepad
        }

        public ControllerType Controller { get; set; }
        public int Key { get; set; }

        public Input()
        {
            Controller = ControllerType.Undefined;
        }

        public override string ToString()
        {
            string key = (Controller == ControllerType.Keyboard) ? ((Keys)Key).ToString() : ((Buttons)Key).ToString();
            return base.ToString() + ": " + Controller.GetDescription() + " - " + key;
        }
    }
}
