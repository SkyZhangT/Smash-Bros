﻿using FirstGame;
using Microsoft.Xna.Framework.Input;
using Sprint0.Game_Enities.Avatar;
using System.Collections.Generic;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities;
using Sprint0.Commands.SystemCommand;

namespace Sprint0.Commands.Mapping
{
    public class StartGameCommandMap : ICommandMap
    {
        private Dictionary<int, ICommand> ControlsMap;
        //private readonly Game1 Game;

        public StartGameCommandMap(Game1 game)
        {
            //Game = game;

            ControlsMap = new Dictionary<int, ICommand>();
            for(int i =0; i < 256; i++)
            {
                ControlsMap.Add(i,new StartGameCommand(game));
            }


        }

        public ICommand GetCommand(int id)
        {
            if (ControlsMap.ContainsKey(id)) return ControlsMap[id];

            else return new UndefinedCommand();
        }
    }
}
