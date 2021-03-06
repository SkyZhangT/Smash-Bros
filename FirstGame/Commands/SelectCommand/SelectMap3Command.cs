﻿using FirstGame;
using Sprint0.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.SelectCommand
{
    public class SelectMap3Command : ICommand
    {
        private Game1 game;
        public SelectMap3Command(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Level = 3;
            game.CurrentScene = new FinishSelectScene(game);
            game.CurrentScene.Initialize();
        }

        public void Undo()
        {
        }
    }
}
