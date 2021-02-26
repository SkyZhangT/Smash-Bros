using FirstGame;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Sprint0.Commands.SystemCommand;
using Sprint0.Commands.SelectCommand;

namespace Sprint0.Commands.Mapping
{
    public class MapSelectCommandMap : ICommandMap
    {
        private Dictionary<int, ICommand> ControlsMap;
        private readonly Game1 Game;

        public MapSelectCommandMap(Game1 game)
        {
            Game = game;

            ControlsMap = new Dictionary<int, ICommand>
            {
                { (int)Keys.D1, new SelectMap1Command(Game)},
                { (int)Keys.D2, new SelectMap2Command(Game)},
                { (int)Keys.D3, new SelectMap3Command(Game)},
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
