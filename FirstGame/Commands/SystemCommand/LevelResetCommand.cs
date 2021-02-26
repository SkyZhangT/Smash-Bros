using System;
using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Sounds;

namespace Sprint0.Commands
{
    class LevelResetCommand : ICommand
    {
        private Game1 game;
        public LevelResetCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentScene.GameState = new PlayState(game);
            game.CurrentScene.StartScript(null);
            game.CurrentScene.IndicatorManager = new Indicators.IndicatorManager(game, game.CurrentScene.PlayerAvatar, new Vector2(50, (float)this.game.GraphicsDevice.Viewport.Height / 3.2f - 20));
            game.CurrentScene.IndicatorManager2 = new Indicators.IndicatorManager(game, game.CurrentScene.PlayerAvatar2, new Vector2(450, (float)game.GraphicsDevice.Viewport.Height / 3.2f - 20));
            game.Once = true;
            SoundManager.EndAllSound();
            if (game.Level == 1)
            {
                SoundManager.PlaySoundContinuous("mariotheme");
            }
            else if (game.Level == 2)
            {
                SoundManager.PlaySoundContinuous("dktheme");
            }
            else if (game.Level == 3)
            {
                SoundManager.PlaySoundContinuous("bowsertheme");
            }
            game.LastTime = 0;
            game.CurrentScene.MainLevel.ResetLevel();
        }

        public void Undo() {}
    }
}
