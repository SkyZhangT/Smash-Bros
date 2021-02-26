using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Collision;
using Sprint0.State.BlockStates;
using System.Diagnostics;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities;
using Sprint0.InputControllers;
using Sprint0.Sounds;

namespace FirstGame
{
   
    public class PlayState : IGameState
    {
        public Game1 Game { get; set; }
        public PlayState(Game1 game)
        {
            Game = game;
            Game.CurrentScene.PauseBackground = false;
            Game.CurrentScene.Controller = new Controller(new Sprint0.Commands.Mapping.CommandMap(Game));
           // SoundManager.EndAllSound();
            if (!SoundManager.MusicPlaying)
            {
                if(Game.Level == 1)
                {
                    SoundManager.PlaySoundContinuous("mariotheme");
                } else if (Game.Level == 2)
                {
                    SoundManager.PlaySoundContinuous("dktheme");
                } else if (Game.Level == 3)
                {
                    SoundManager.PlaySoundContinuous("bowsertheme");
                }
            }
            SoundManager.ResumeAllSound();
            SoundManager.PlayedOnce = false;
        }

        public void Update(GameTime gameTime)
        {
           
            if (!Game.CurrentScene.GrowPause)
            {
                Game.CurrentScene.Controller.UpdateInput();
                Game.EntityManager.UpdateEntities(gameTime);
                
            }
            else
            {

                IEntity entity = Game.CurrentScene.PlayerAvatar;
                if(!(entity.CurrentPowerState is Shrinking) && !(entity.CurrentPowerState is Growing))
                {
                    entity = Game.CurrentScene.PlayerAvatar2;
                }
                {
                    entity.UpdateEntity(gameTime);
                    Game.CurrentScene.TimeSinceLast += gameTime.ElapsedGameTime.Milliseconds;
                    if (entity.Indicator == Color.TransparentBlack)
                    {
                        entity.Indicator = Color.White;
                    }
                    else
                    {
                        entity.Indicator = Color.TransparentBlack;
                    }
                    if (Game.CurrentScene.TimeSinceLast > 1000)
                    {
                        Game.CurrentScene.GrowPause = false;
                        if (entity.CurrentPowerState is Growing)
                        {
                            entity.CurrentPowerState = entity.CurrentPowerState.PromoteSuperMario();
                        }
                        else
                        {
                            entity.CurrentPowerState = new SmallMarioPowerUpState(Game, entity);
                        }
                        if(entity is MarioAvatar)
                            entity.FacingRight = !entity.FacingRight;
                        entity.Indicator = Color.White;
                        entity.CurrentActionState.Update(gameTime);
                    }
                }

                
            }

        }

    }
}
