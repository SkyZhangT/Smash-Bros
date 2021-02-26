using FirstGame;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Sprint0.Commands.SystemCommand;

namespace Sprint0.Commands.Mapping
{
    public class CharacterSelectCommandMap : ICommandMap
    {
        private Dictionary<int, ICommand> ControlsMap;
        private readonly Game1 Game;

        public CharacterSelectCommandMap(Game1 game)
        {
            Game = game;

            ControlsMap = new Dictionary<int, ICommand>
            {
                { (int)Keys.D1, new SelectMarioCommand(Game)},
                { (int)Keys.D2, new SelectLuigiCommand(Game)},
                { (int)Keys.D3, new SelectKoopaCommand(Game)},
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