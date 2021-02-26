using System;
using System.Collections.Generic;
using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Cameraa;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Indicators;
using Sprint0.InputControllers;
using Sprint0.Scripts;

namespace Sprint0.Scenes
{
    public interface IScene
    {
        AvatarMain PlayerAvatar { get; set; }
        AvatarMain PlayerAvatar2 { get; set; }
        IndicatorManager IndicatorManager { get; set; }
        IndicatorManager IndicatorManager2 { get; set; }
        Camera Camera { get; set; }
        Camera Camera1 { get; set; }
        Camera Camera2 { get; set; }
        Controller Controller { get; set; }
        ALevel MainLevel { get; set; }
        IGameState GameState { get; set; }
        AScript CurrentScript { get; set; }
        bool PauseBackground { get; set; }
        bool GrowPause { get; set; }
        int TimeSinceLast { get; set; }
        float Iter { get; set; }
        IEntity ThwompItem { get; set; }
        Vector2 FirstBottomRightBoundary { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Initialize();
        void StartScript(AScript script);
        void ToggleFullScreen();
    }
}
