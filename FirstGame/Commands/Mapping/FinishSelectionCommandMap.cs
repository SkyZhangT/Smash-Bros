using FirstGame;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.SystemCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mapping
{
    class FinishSelectCommandMap : ICommandMap
    {
        private Dictionary<int, ICommand> ControlsMap;
        private readonly Game1 Game;

        public FinishSelectCommandMap(Game1 game)
        {
            Game = game;

            ControlsMap = new Dictionary<int, ICommand>
            {
                { (int)Keys.Enter, new NextSceneCommand(Game)},
                //{ (int)Keys.E, new NextSceneCommand2(Game)}, this line is for test only
                { (int)Keys.R, new ReselectCommand(Game)},
                                #region Quit
                { (int)Keys.Q, new QuitCommand(Game) }
                #endregion
            };
        }

        public ICommand GetCommand(int id)
        {
            if (ControlsMap.ContainsKey(id)) return ControlsMap[id];

            else return new UndefinedCommand();
        }
    }
}
