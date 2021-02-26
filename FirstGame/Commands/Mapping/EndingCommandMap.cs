using FirstGame;
using Microsoft.Xna.Framework.Input;
using Sprint0.Game_Enities.Avatar;
using System.Collections.Generic;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities;
using Sprint0.Commands.SystemCommand;

namespace Sprint0.Commands.Mapping
{
    class EndingCommandMap : ICommandMap
    {
        private Dictionary<int, ICommand> ControlsMap;
        private readonly Game1 Game;

        public EndingCommandMap(Game1 game)
        {
            Game = game;

            ControlsMap = new Dictionary<int, ICommand>
            {

                #region Control Definitions
                #region LevelReset

                 { (int)Keys.R, new LevelResetCommand(Game) },

                #endregion

                
                  #region Quit
                { (int)Keys.Q, new QuitCommand(Game) },
                #endregion
                #endregion



                { (int)Keys.C, new HitBoxCommand(Game) }
            };
        }

        public ICommand GetCommand(int id)
        {
            if (ControlsMap.ContainsKey(id)) return ControlsMap[id];

            else return new UndefinedCommand();
        }
    }
}
