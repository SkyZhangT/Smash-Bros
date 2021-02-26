using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;
using System.Diagnostics;
using Sprint0.InputControllers;
using Sprint0.Commands.Mapping;
using Sprint0.Sounds;
using Sprint0.Game_Enities.Avatar;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Commands;
using Sprint0.Commands.SystemCommand;

namespace FirstGame
{

    public class SkillState : IGameState
    {
        public Game1 Game { get; set; }
        public AvatarMain PlayerAvatar { get; set; }
        public SpriteBatch Spritebatch { get => spritebatch; set => spritebatch = value; }

        private SpriteBatch spritebatch;
        private int  StartTime;
        public SkillState(Game1 game, AvatarMain avatar)
        {
            //SoundManager.PlaySound("skill1");
            Game = game;
            Game.CurrentScene.PauseBackground = true;
            //Game.Controller = new Controller(new PauseCommandMap(Game));
            PlayerAvatar = avatar;
            StartTime = 0;
            if (avatar is MarioAvatar)
                avatar.Meteorite();
            else if (avatar is TurtleAvatar)
                avatar.TURTLES();
        }

        public void Update(GameTime gameTime)
        {
            Game.CurrentScene.Camera =Game.CurrentScene.Camera2;
            Game.CurrentScene.Camera2.Limits = new Rectangle((int)(PlayerAvatar.Position.X-150), (int)(PlayerAvatar.Position.Y-100), 300, 200);

            Game.CurrentScene.Camera2.LookAtWithLimit(PlayerAvatar.Position);
            
            StartTime += gameTime.ElapsedGameTime.Milliseconds;

            if (StartTime > 1000)
            {
                Game.CurrentScene.Camera = Game.CurrentScene.Camera1;
                ICommand c = new ResumeCommand(Game);
                c.Execute();
            }
        }
    }
}
