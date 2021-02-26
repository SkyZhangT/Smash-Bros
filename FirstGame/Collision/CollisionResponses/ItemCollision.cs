using Sprint0.Game_Enities;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Items;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Sounds;
using FirstGame;
using Sprint0.Indicators.Instants;
using System;

namespace Sprint0.Collision
{
    class ItemCollision : ICollision
    {
        public IEntity CurrentEntity { get; set; }
        public Game1 Game { get; set; }

        public ItemCollision(Game1 game,IEntity enemy)
        {
            CurrentEntity = enemy;
            Game = game;
            //CollisionHandling.Collision += OnCollision;
        }
      
        public void Response(IEntity entityHit, GameTime time)
        {
            if (entityHit is MarioAvatar||entityHit is TurtleAvatar)
            {
                if (CurrentEntity is SuperMushroom)
                {
                    if (entityHit.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        entityHit.CurrentPowerState = entityHit.CurrentPowerState.PromoteSuperMario();
                        entityHit.CurrentActionState.Update(time);
                    }

                    CurrentEntity.Visible = false;
                    CurrentEntity.HitBox = new Rectangle(-1, -1, -1, -1);
                    if (entityHit == Game.CurrentScene.PlayerAvatar)
                    {
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.SUPERMUSHROOM, entityHit.Position, time);
                    }
                    else
                    {
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.SUPERMUSHROOM, entityHit.Position, time);
                    }

                    CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, Indicators.IndicatorManager.SUPERMUSHROOM_SCORE.ToString()));

                }
                else if (CurrentEntity is OneUpMushroom)
                {

                    CurrentEntity.Visible = false;
                    CurrentEntity.HitBox = new Rectangle(-1, -1, -1, -1);
                    SoundManager.PlaySound("1up");

                    if (entityHit == Game.CurrentScene.PlayerAvatar)
                    {
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.ONEUPMUSHROOM, entityHit.Position, time);
                    }
                    else
                    {
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.ONEUPMUSHROOM, entityHit.Position, time);
                    }


                    CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, Indicators.IndicatorManager.ONEUPMUSHROOM));

                }
                else if (CurrentEntity is Coin)
                {

                    if (entityHit == Game.CurrentScene.PlayerAvatar)
                    {
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.COIN, entityHit.Position, time);
                    }
                    else
                    {
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.COIN, entityHit.Position, time);
                    }


                    CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, Indicators.IndicatorManager.COIN_SCORE.ToString()));


                    CurrentEntity.Visible = false;
                    SoundManager.PlaySound("coin");
                }
            }
        }
        public void HitFromTop(IEntity entityHit, GameTime time)
        {
            // HUD Rule:
            // Coin: coin++
            // OnUpMushroom: Live++
            // SuperMushroom: Score+=500
            // FireFlower: Score+=1000
            
        }
        public void HitFromBot(IEntity entityHit, GameTime time)
        {
            //todo: add collision response
            if (entityHit is BlockEntity)
            {
                if (!(entityHit is HiddenBlockEntity) || entityHit.Visible)
                {
                    Console.WriteLine(CurrentEntity);
                    if(CurrentEntity is Star)
                    {
                        CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y - CurrentEntity.HitBox.Height - 1);
                        CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, -2);
                    }
                    else
                    {
                        CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y - CurrentEntity.HitBox.Height);
                        CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, 0);
                    }
                }
            }
            
        }
        public void HitFromSide(IEntity entityHit, GameTime time)
        {
            if (entityHit is BlockEntity)
            {
                if (!(entityHit is HiddenBlockEntity) || entityHit.Visible)
                {
                    if (CurrentEntity.HitBox.X < entityHit.HitBox.X)
                    {
                        CurrentEntity.Position = new Vector2(entityHit.Position.X - CurrentEntity.CurrentSprite.FrameSize.X - 1, CurrentEntity.Position.Y);
                    }
                    else
                    {
                        CurrentEntity.Position = new Vector2(entityHit.Position.X + entityHit.CurrentSprite.FrameSize.X + 1, CurrentEntity.Position.Y);
                    }
                    CurrentEntity.Velocity = new Vector2(-CurrentEntity.Velocity.X, CurrentEntity.Velocity.Y);
                    CurrentEntity.FacingRight = !CurrentEntity.FacingRight;
                }
            }
            
        }
    }
}
