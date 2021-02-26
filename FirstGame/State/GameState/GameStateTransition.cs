using Sprint0.InputControllers;
using Sprint0.Commands.Mapping;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Sprint0.Sounds;
using Sprint0.Scenes;

namespace FirstGame
{
    class ProspectMemory
    {
        public float SavedCheckPoint { get; set; }

        public ProspectMemory (float check)
        {
            SavedCheckPoint = check;
        }

    }


    public class GameStateTransition
    {

        public Game1 Game { get; set; }
        public IGameState GameState { get; set; }
        private int TimeSinceDeath=0;
        public float CheckPoint { get; set; }
        private ProspectMemory Prospect;
        private int TimeSinceDeath2 = 0;
        public GameStateTransition(Game1 game,IGameState gameState)
        {
            Game = game;
            GameState = gameState;
            CheckPoint = 0;
            Prospect = new ProspectMemory(CheckPoint);
        }

        //public void LifeConsuming()
        //{
        //   Restore();
        //}

        public void Update(GameTime gameTime)
        {
            if (Game.CurrentScene.IndicatorManager.Lives.lives<=0)
            {
                TimeSinceDeath += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceDeath > 5000)
                {
                    Game.CurrentScene = new EndGameScene(Game);
                    Game.CurrentScene.Initialize();
                    Game.EntityManager.RemoveAllEntity();
                    Game.Winner = 2;
                    TimeSinceDeath = 0;
                }
            }
            else if (Game.CurrentScene.IndicatorManager2.Lives.lives <= 0)
            {
                TimeSinceDeath += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceDeath > 5000)
                {
                    Game.CurrentScene = new EndGameScene(Game);
                    Game.CurrentScene.Initialize();
                    Game.EntityManager.RemoveAllEntity();
                    Game.Winner = 1;
                    TimeSinceDeath = 0;
                }
            }
            else if (Game.CurrentScene.PlayerAvatar.CurrentPowerState is DeadMarioPowerUpState)
            {
                TimeSinceDeath += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceDeath > 5000)
                {
                    
                    Game.CurrentScene.PlayerAvatar.Position = new Vector2(100, 100);
                    Game.CurrentScene.PlayerAvatar.Damage = 0;
                    Game.CurrentScene.PlayerAvatar.CurrentPowerState = Game.CurrentScene.PlayerAvatar.CurrentPowerState.PromoteMario();
                    Game.CurrentScene.PlayerAvatar.PhysicsEnabled = true;
                    Game.CurrentScene.PlayerAvatar.HitBox = new Rectangle((int)Game.CurrentScene.PlayerAvatar.Position.X + 2, (int)Game.CurrentScene.PlayerAvatar.Position.Y + 1, Game.CurrentScene.PlayerAvatar.CurrentSprite.FrameSize.X - 4, Game.CurrentScene.PlayerAvatar.CurrentSprite.FrameSize.Y - 3);
                    TimeSinceDeath = 0;
                }
            }
            else if (Game.CurrentScene.PlayerAvatar2.CurrentPowerState is DeadMarioPowerUpState)
            {
                TimeSinceDeath2 += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceDeath2 > 5000)
                {
                    Game.CurrentScene.PlayerAvatar2.Position = new Vector2(100, 100);
                    Game.CurrentScene.PlayerAvatar2.CurrentPowerState=Game.CurrentScene.PlayerAvatar2.CurrentPowerState.PromoteMario();
                    Game.CurrentScene.PlayerAvatar2.PhysicsEnabled = true;
                    Game.CurrentScene.PlayerAvatar2.HitBox = new Rectangle((int)Game.CurrentScene.PlayerAvatar2.Position.X + 2, (int)Game.CurrentScene.PlayerAvatar2.Position.Y + 1, Game.CurrentScene.PlayerAvatar2.CurrentSprite.FrameSize.X - 4, Game.CurrentScene.PlayerAvatar2.CurrentSprite.FrameSize.Y - 3);
                    Game.CurrentScene.PlayerAvatar2.Damage = 0;

                    TimeSinceDeath2 = 0;
                }
            }
           
        }

        public void Restore()
        {
            if (Game.CurrentScene.IndicatorManager.Lives.lives <= 0|| Game.CurrentScene.IndicatorManager2.Lives.lives <= 0)
            {
                if(Game.CurrentScene.IndicatorManager.Lives.lives <= 0)
                {
                    Game.Winner = 1;
                }
                else
                {
                    Game.Winner = 2;
                }
                Game.CurrentScene = new EndGameScene(Game);
                Game.CurrentScene.Initialize();
                Game.CurrentScene.GameState = new FaliureState(Game);
                
                Prospect.SavedCheckPoint = 0;
                if (!SoundManager.PlayedOnce)
                {
                    SoundManager.PlayedOnce = true;
                    SoundManager.PlaySound("gameover");
                }
            }
            else
            {
                Game.CurrentScene.MainLevel.ResetAvator(Prospect.SavedCheckPoint);
                SoundManager.PlaySoundContinuous("theme");
            }
        }

    }
}
