using Sprint0.Game_Enities;
using Microsoft.Xna.Framework;
using FirstGame;
using System;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.State.EnemyStates;
using Sprint0.Game_Enities.Enemies;
using Sprint0.State.BlockStates;
using Sprint0.Sounds;
using Sprint0.Indicators.Instants;
using Sprint0.Text;

namespace Sprint0.Collision
{
    public class EnemyCollision:ICollision
    {
        delegate void EnemyCollisionEventHandler(Object sender, CollisionEventArgs e);
        event EnemyCollisionEventHandler KoopaSideCollision;
        event EnemyCollisionEventHandler KoopaTopCollision;
        event EnemyCollisionEventHandler KoopaBotCollision;
        event EnemyCollisionEventHandler GoombaTopCollision;
        event EnemyCollisionEventHandler GoombaSideCollision;
        event EnemyCollisionEventHandler GoombaBotCollision;


        public IEntity CurrentEntity { get; set; }
        public int TimeSinceLast { get; set; }

        public EnemyCollision(IEntity enemy)
        {
            this.KoopaSideCollision += OnKoopaSideCollision;
            this.KoopaBotCollision += OnKoopaBotCollision;
            this.KoopaTopCollision += OnKoopaTopCollision;
            this.GoombaTopCollision += OnGoombaTopCollision;
            this.GoombaSideCollision += OnGoombaSideCollision;
            this.GoombaBotCollision += OnGoombaBotCollision;
            
            CurrentEntity = enemy;
        }
        

        public void Response(IEntity entityHit, GameTime time)
        {
            if(entityHit is BlockEntity && CurrentEntity is Thwomp)
            {
                if((!(entityHit is HiddenBlockEntity) || entityHit.Visible))
                {
                    entityHit.Visible = false;
                }
            }
        }

        #region Specific
        public void OnKoopaSideCollision(object sender, CollisionEventArgs args)
        {
            if (args.hit is MarioAvatar||args.hit is TurtleAvatar)
            {
                if (CurrentEntity.ActionState is InjuredKoopa)
                {
                    if (CurrentEntity.HitBox.X < args.hit.HitBox.X)
                    {
                        CurrentEntity.Position = new Vector2(args.hit.Position.X - CurrentEntity.CurrentSprite.FrameSize.X - 2, CurrentEntity.Position.Y);
                    }
                    else
                    {
                        CurrentEntity.Position = new Vector2(args.hit.Position.X + CurrentEntity.CurrentSprite.FrameSize.X + 2, CurrentEntity.Position.Y);
                    }
                    CurrentEntity.ActionState = new MovingShell(CurrentEntity);
                    CurrentEntity.Velocity = new Vector2(args.hit.Velocity.X/(Math.Abs(args.hit.Velocity.X))*2.5f, CurrentEntity.Velocity.Y);
                }
            }
        }

        public void OnKoopaTopCollision(object sender, CollisionEventArgs args)
        {
            if (args.hit is MarioAvatar|| args.hit is TurtleAvatar)
            {
                if (CurrentEntity.ActionState is AliveKoopa)
                {
                    CurrentEntity.Velocity = new Vector2(0, 0);
                    CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, CurrentEntity.Position, args.time);
                    CurrentEntity.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, CurrentEntity.Position, args.time);
                    CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE *Math.Pow(2,CurrentEntity.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                    CurrentEntity.Game.FloatingScoreManager.UpdateMultiplier(args.time);
                    //CurrentEntity.Gravity = new Vector2(0, 0);
                    CurrentEntity.ActionState = new InjuredKoopa(CurrentEntity);
                    SoundManager.PlaySound("stomp");
                }
                else if (CurrentEntity.ActionState is MovingShell)
                {
                    CurrentEntity.ActionState = new InjuredKoopa(CurrentEntity);
                    CurrentEntity.Velocity = Vector2.Zero;
                    SoundManager.PlaySound("stomp");
                }
                else if(CurrentEntity.ActionState is InjuredKoopa)
                {
                    CurrentEntity.ActionState = new MovingShell(CurrentEntity);
                    if (CurrentEntity.Position.X >= args.hit.Position.X)
                    {
                        CurrentEntity.Velocity = new Vector2(2f, CurrentEntity.Velocity.Y);
                    }
                    else
                    {
                        CurrentEntity.Velocity = new Vector2(-2f, CurrentEntity.Velocity.Y);
                    }
                    SoundManager.PlaySound("kick");
                }
            }

        }
        public void OnKoopaBotCollision(object sender, CollisionEventArgs args)
        {
        }
        public void OnGoombaTopCollision(object sender, CollisionEventArgs args)
        {
            if (args.hit is MarioAvatar||args.hit is TurtleAvatar)
            {
                if (CurrentEntity.ActionState is AliveGoomba)
                {
                    //get 100 score for killing enemy
                    CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GOOMBA, CurrentEntity.Position, args.time);
                    CurrentEntity.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GOOMBA, CurrentEntity.Position, args.time);
                    CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, (Indicators.IndicatorManager.GOOMBA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                    CurrentEntity.Game.FloatingScoreManager.UpdateMultiplier(args.time);
                    CurrentEntity.Velocity = Vector2.Zero;
                    CurrentEntity.Gravity = 0;
                    CurrentEntity.ActionState = new InjuredGoomba(CurrentEntity);
                    CurrentEntity.HitBox = new Rectangle(-1, -1, 0, 0);
                    SoundManager.PlaySound("stomp");
                }

            }
        }
        public void OnGoombaSideCollision(object sender, CollisionEventArgs args)
        {

        }
        public void OnGoombaBotCollision(object sender, CollisionEventArgs args)
        {

        }
        #endregion
        public void HitFromTop(IEntity entityHit,GameTime time)
        {
            if(CurrentEntity is Koopa)
            {
                KoopaTopCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time=time });
            }
            else if(CurrentEntity is Goomba)
            {
                GoombaTopCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit,time=time });
            }
            else if(CurrentEntity is Fireball)
            {
                FireballTopCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
            }
        }

        private void FireballTopCollision(IEntity currentEntity, CollisionEventArgs args)
        {
            if (args.hit is BlockEntity)
            {
                if (!(args.hit is HiddenBlockEntity) || args.hit.Visible)
                {
                    CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, 2);
                    currentEntity.Position = new Vector2(currentEntity.Position.X, currentEntity.Position.Y - 1);
                    currentEntity.ActionState.Update(args.time);
                }
            }
            if (args.hit is EnemyEntity && !(args.hit is Fireball) && !(args.hit.CurrentSprite is DeadEnemy)&&!(args.hit is Thwomp))
            {
                args.hit.ActionState = new DeadEnemy(args.hit);
                args.hit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, args.hit.Position, args.time);
                args.hit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, args.hit.Position, args.time);

                args.hit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(args.hit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, args.hit.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                args.hit.Game.FloatingScoreManager.UpdateMultiplier(args.time);
                CurrentEntity.Visible = false;
                args.hit.Velocity = new Vector2(2, -4); 

                SoundManager.PlaySound("kick");
            }
        }

        public void HitFromBot(IEntity entityHit, GameTime time)
        {
            //NoResponseWithMario
            if(!(CurrentEntity is PiranhaPlantEntity)&&!(CurrentEntity is Thwomp))
            {
                if (entityHit is BlockEntity&& !(CurrentEntity is Fireball) )
                {
                    
                        if ((!(entityHit is HiddenBlockEntity) || entityHit.Visible) && !(CurrentEntity.ActionState is DeadEnemy))
                        {
                            CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y - (CurrentEntity.CurrentSprite.FrameSize.Y - 1));
                            CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, 0);
                        }
                        if ((entityHit.CurrentState is BumpState || entityHit.CurrentState.Block.Name is "Rising") && !(CurrentEntity.ActionState is DeadEnemy))
                        {
                            //get 100 score for killing enemy (goombas and koopas are the same)
                            CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GOOMBA, CurrentEntity.Position, time);
                            CurrentEntity.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GOOMBA, CurrentEntity.Position, time);

                            CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, (Indicators.IndicatorManager.GOOMBA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier - 1)).ToString()));
                            CurrentEntity.Game.FloatingScoreManager.UpdateMultiplier(time);
                            CurrentEntity.ActionState = new DeadEnemy(CurrentEntity);
                            CurrentEntity.Velocity = new Vector2(2, -4);
                            SoundManager.PlaySound("kick");
                        }
                    
                }
                else if (CurrentEntity is Koopa)
                {
                    KoopaBotCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
                }
                else if (CurrentEntity is Goomba)
                {
                    GoombaBotCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
                }
                else if(CurrentEntity is Fireball)
                {
                    FireballBotCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
                }
            }
        }

        private void FireballBotCollision(IEntity currentEntity, CollisionEventArgs args)
        {
            if(args.hit is BlockEntity)
            {
                if(!(args.hit is HiddenBlockEntity) || args.hit.Visible)
                {
                    CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, -2);
                    currentEntity.Position = new Vector2(currentEntity.Position.X, currentEntity.Position.Y - 2);
                    currentEntity.ActionState.Update(args.time);
                }
            }
            if(args.hit is EnemyEntity&& !(args.hit is Fireball)&&!(args.hit.CurrentSprite is DeadEnemy) && !(args.hit is Thwomp))
            {
                args.hit.ActionState = new DeadEnemy(args.hit);
                args.hit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, args.hit.Position, args.time);
                args.hit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, args.hit.Position, args.time);


                args.hit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(args.hit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, args.hit.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                args.hit.Game.FloatingScoreManager.UpdateMultiplier(args.time);
                CurrentEntity.Visible = false;
                args.hit.Velocity = new Vector2(2, -4); 
                SoundManager.PlaySound("kick");
            }

        }

        public void HitFromSide(IEntity entityHit, GameTime time)
        {
            
            if(CurrentEntity is Fireball)
            {
                if (entityHit is BlockEntity)
                {
                    CurrentEntity.Velocity = new Vector2(-CurrentEntity.Velocity.X, CurrentEntity.Velocity.Y);
                    if (CurrentEntity.HitBox.X < entityHit.HitBox.X)
                    {
                        CurrentEntity.Position = new Vector2(entityHit.Position.X - CurrentEntity.CurrentSprite.FrameSize.X - 1, CurrentEntity.Position.Y);
                    }
                    else
                    {
                        CurrentEntity.Position = new Vector2(entityHit.Position.X + entityHit.CurrentSprite.FrameSize.X + 1, CurrentEntity.Position.Y);
                    }
                }
            }
            else if (!(CurrentEntity is PiranhaPlantEntity))
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
                        if (CurrentEntity is Koopa && CurrentEntity.ActionState is MovingShell)
                        {
                            if ((CurrentEntity.Position.X < entityHit.Position.X && CurrentEntity.Velocity.X > 0) || (CurrentEntity.Position.X > entityHit.Position.X && CurrentEntity.Velocity.X < 0))
                            {
                                entityHit.CurrentState.BumpTransition(CurrentEntity, time);
                            }
                        }
                        if ((CurrentEntity.Position.X < entityHit.Position.X && CurrentEntity.Velocity.X > 0) || (CurrentEntity.Position.X > entityHit.Position.X && CurrentEntity.Velocity.X < 0))
                        {
                            CurrentEntity.Velocity = new Vector2(-CurrentEntity.Velocity.X, CurrentEntity.Velocity.Y);
                            CurrentEntity.FacingRight = !CurrentEntity.FacingRight;
                        }
                    }
                }
                else if (entityHit.ActionState is MovingShell)
                {
                    if (CurrentEntity is Fireball)
                    {
                        entityHit.ActionState = new DeadEnemy(entityHit);
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);

                        entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                        entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                        entityHit.Velocity = new Vector2(2, -4);
                        CurrentEntity.Visible = false;

                    }
                    else
                    {
                        CurrentEntity.ActionState = new DeadEnemy(CurrentEntity);
                        CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GOOMBA, CurrentEntity.Position, time);
                        CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(CurrentEntity.Position, (Indicators.IndicatorManager.GOOMBA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                        CurrentEntity.Game.FloatingScoreManager.UpdateMultiplier(time);
                        CurrentEntity.Velocity = new Vector2(entityHit.Velocity.X * 1f, -Math.Abs(entityHit.Velocity.X * 2f));
                    }
                    SoundManager.PlaySound("kick");
                }

                if (CurrentEntity is Koopa)
                {
                    KoopaSideCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
                }
                else if (CurrentEntity is Goomba)
                {
                    GoombaSideCollision(CurrentEntity, new CollisionEventArgs { hit = entityHit, time = time });
                }

                if (CurrentEntity is Fireball)
                {
                    if (entityHit is EnemyEntity && !(entityHit is Fireball))
                    {
                        entityHit.ActionState = new DeadEnemy(entityHit);
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                        entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier-1)).ToString()));
                        entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                        entityHit.Velocity = new Vector2(2, -4);
                        SoundManager.PlaySound("kick");
                        CurrentEntity.Visible = false;
                    }
                }
            }
        }

       
    }
}
