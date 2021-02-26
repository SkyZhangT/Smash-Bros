using Sprint0.Game_Enities;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities.Enemies;
using FirstGame;
using Sprint0.Game_Enities.Items;
using Sprint0.State.EnemyStates;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Sounds;
using Sprint0.EntityState.BlockStates;
using Sprint0.Indicators.Instants;
using Sprint0.Scripts;
using Sprint0.Commands;

namespace Sprint0.Collision
{
    class AvatarCollision : ICollision
    {

        public IEntity CurrentEntity { get; set; }
        public AvatarMain ThisEntity { get; set; }
        private int TimeSinceHit { get; set; }
        public Game1 Game { get; set; }
        public AvatarCollision(Game1 game, IEntity enemy)
        {
            CurrentEntity = enemy;
            ThisEntity = (AvatarMain)enemy;
            TimeSinceHit = 0;
            this.Game = game;
        }

        private void HandleAvatar(IEntity entityHit)
        {
            if (CurrentEntity.ActionState is null)
            {
                if (entityHit.CurrentActionState is PunchState || entityHit.CurrentActionState is TurtlePunchState)
                {
                    if ((CurrentEntity.CurrentActionState is CrouchState || CurrentEntity.CurrentActionState is TurtleCrouchState)&&entityHit.ActionState is null)
                    {
                        
                        entityHit.CurrentActionState.Stun();
                        SoundManager.PlaySound("kick");
                    }
                    else
                    {
                        if (CurrentEntity.CurrentPowerState is SmallMarioPowerUpState && !(entityHit.CurrentPowerState is SmallMarioPowerUpState))
                        {
                            ((AvatarMain)CurrentEntity).Damage += 2;
                            ((AvatarMain)CurrentEntity).Launch(1.2);
                            SoundManager.PlaySound("bump");
                        }
                        else
                        {
                            ((AvatarMain)CurrentEntity).Damage += 1;
                            ((AvatarMain)CurrentEntity).Launch(.8);
                            SoundManager.PlaySound("bump");
                        }

                    }

                }
            }
        }

        private void HandleFireFlower(IEntity entityHit, GameTime time)
        {
            if (CurrentEntity.CurrentPowerState is SuperMarioPowerUpState || CurrentEntity.CurrentPowerState is FireMarioPowerUpState)
            {
                CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.PromoteFireMario();
                CurrentEntity.CurrentActionState.Update(time);

            }
            else if (CurrentEntity.CurrentPowerState is SmallMarioPowerUpState)
            {
                CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.PromoteSuperMario();
                CurrentEntity.CurrentActionState.Update(time);

            }
            entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FIREFLOWER, CurrentEntity.Position, time);
            entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FIREFLOWER_SCORE.ToString()));


            entityHit.Visible = false;
            entityHit.HitBox = new Rectangle(-1, -1, -1, -1);
        }

        private void HandlePiranhaPlant(IEntity entityHit, GameTime time)
        {
            if (time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds >= TimeSinceHit && CurrentEntity.ActionState == null)
            {
                CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.Hit();
                CurrentEntity.CurrentActionState.Update(time);
                TimeSinceHit = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 3;
            }
            else if (CurrentEntity.ActionState != null)
            {
                entityHit.ActionState = new DeadEnemy(entityHit);

                if (CurrentEntity == Game.CurrentScene.PlayerAvatar)
                {
                    entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                }
                else
                {
                    entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                }

                entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier - 1)).ToString()));
                entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                entityHit.Velocity = new Vector2(Math.Abs(entityHit.Velocity.X) / entityHit.Velocity.X * 2, -4);
            }
        }

        public void Response(IEntity entityHit, GameTime time)
        {
            if (entityHit is FlagPole)
            {
                FlagPoleHit(entityHit, time);
            }
            else if (entityHit is CheepCheep)
            {
                if (!(entityHit.Master == CurrentEntity))
                {
                    if (CurrentEntity.ActionState is null)
                        ((AvatarMain)CurrentEntity).Damage += 5;
                    ((AvatarMain)CurrentEntity).Launch(.1);
                    entityHit.Visible = false;
                }
            }
            else if (entityHit is AvatarMain)
            {
                HandleAvatar(entityHit);
            }
            else if (entityHit is BulletBill)
            {

                if (!(entityHit.Master == CurrentEntity))
                {
                    if (CurrentEntity.ActionState is null)
                        ((AvatarMain)CurrentEntity).Damage += 50;
                    ((AvatarMain)CurrentEntity).Launch(1);
                    entityHit.Visible = false;
                }
            }
            else if (entityHit is CheepCheepItem)
            {
                ThisEntity.CheepCheepItem();
                entityHit.Visible = false;
            }
            else if (entityHit is ThwompItem)
            {
                ThisEntity.ThwompItem();
                entityHit.Visible = false;
            }
            else if (entityHit is BulletBillItem)
            {
                ThisEntity.BulletBillItem();
                entityHit.Visible = false;
            }
            else if (entityHit is Thwomp)
            {
                if (time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds >= TimeSinceHit && CurrentEntity.ActionState == null)
                {
                    if (!(entityHit.Master == CurrentEntity))
                    {
                        if (CurrentEntity.ActionState is null)
                            ((AvatarMain)CurrentEntity).Damage += 20;
                        CurrentEntity.CurrentActionState.Stun();
                        CurrentEntity.CurrentActionState.Update(time);
                        TimeSinceHit = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 3;
                    }

                }
            }
            else if (entityHit is PiranhaPlantEntity)
            {
                HandlePiranhaPlant(entityHit, time);
            }

            else if (entityHit is Star)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.SUPERSTAR, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.SUPERSTAR_SCORE.ToString()));
                CurrentEntity.ActionState = CurrentEntity.CurrentPowerState.PromoteStarMario();
                Console.WriteLine(CurrentEntity.CurrentPowerState);
                entityHit.Visible = false;
                entityHit.HitBox = new Rectangle(-1, -1, -1, -1);
            }

            else if (entityHit is FireFlower)
            {
                HandleFireFlower(entityHit,time);
            }
            else if (entityHit is Fireball)
            {
                if (entityHit.Master != CurrentEntity)
                {
                    /*if (!(CurrentEntity.CurrentPowerState is SmallMarioPowerUpState))
                    {
                        AvatarMain a = (AvatarMain)CurrentEntity;
                        ICommand c = new HitMarioCommand(a);
                        c.Execute();
                    }*/

                    CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X + entityHit.Velocity.X, CurrentEntity.Velocity.Y);
                    if (CurrentEntity.ActionState is null)
                        ((AvatarMain)CurrentEntity).Damage += 2;
                    entityHit.Visible = false;
                    entityHit.HitBox = new Rectangle(-1, -1, -1, -1);
                }

            }
            else if (entityHit is SuperMushroom)
            {
                if (((AvatarMain)CurrentEntity).Damage < 10)
                {
                    ((AvatarMain)CurrentEntity).Damage = 0;
                }
                else
                {
                    ((AvatarMain)CurrentEntity).Damage -= 10;
                }
            }
        }
       
        public void HitFromTop(IEntity entityHit, GameTime time)
        {
            if (entityHit is BlockEntity && !(entityHit is PlatformEntity))
            {
                Console.WriteLine(entityHit.CurrentActionState);
                if (entityHit is HiddenBlockEntity)
                {
                    CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y + entityHit.HitBox.Height);
                }
                else
                {
                    CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y + entityHit.HitBox.Height);
                }
                if (CurrentEntity.Velocity.Y < 0)
                {
                    CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, 0);
                }
            }
            else if (entityHit is Goomba || entityHit is Koopa)
            {
                if (time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds >= TimeSinceHit&&CurrentEntity.ActionState==null)
                {
                    if (entityHit.Master != CurrentEntity)
                    {
                        if (CurrentEntity is MarioAvatar)
                        {
                            CurrentEntity.CurrentActionState = new IdleState(CurrentEntity.Game, CurrentEntity);
                        }
                        else
                        {
                            CurrentEntity.CurrentActionState = new TurtleIdleState(CurrentEntity.Game, CurrentEntity);
                        }
                        CurrentEntity.Velocity = new Vector2(0, 0);
                        if(!(CurrentEntity.CurrentPowerState is SmallMarioPowerUpState))
                        {
                            CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.Hit();
                            CurrentEntity.CurrentActionState.Update(time);
                        }
                        ((AvatarMain)CurrentEntity).Damage += 10;
                        ((AvatarMain)CurrentEntity).Launch(.5);
                        TimeSinceHit = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 3;
                    }
                }
                else if (CurrentEntity.ActionState != null && entityHit.Master !=CurrentEntity)
                {
                    entityHit.ActionState = new DeadEnemy(entityHit);
                    if (CurrentEntity == Game.CurrentScene.PlayerAvatar)
                    {
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                    }
                    else
                    {
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                    }

                    
                    entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier - 1)).ToString()));
                    entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                    entityHit.Velocity = new Vector2(Math.Abs(entityHit.Velocity.X) / entityHit.Velocity.X * 2, -4);
                }
            }



        }

        public void HitFromBot(IEntity entityHit, GameTime time)
        {
            if(entityHit is BlockEntity)
            {
                if (CurrentEntity.Velocity.Y >= 0 && (!(entityHit is HiddenBlockEntity) || entityHit.Visible))
                {
                    CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.Position.Y - CurrentEntity.HitBox.Height - 1);
                    CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, 0);
                    if (CurrentEntity.CurrentActionState is JumpState||CurrentEntity.CurrentActionState is TurtleJumpState)
                    {
                        CurrentEntity.CurrentActionState.GoDown(2);

                    }
                }
                if(CurrentEntity.CurrentActionState is CrouchState|| CurrentEntity.CurrentActionState is TurtleCrouchState)
                {
                    if(entityHit.TPosition != new Vector2(0, 0))
                    {
                        Console.WriteLine("POSITION: " + CurrentEntity.Position);
                        CurrentEntity.CurrentActionState.GoUp(0);
                        CurrentEntity.Gravity = 0;
                        CurrentEntity.PhysicsEnabled = false;
                        Vector2 tposition = new Vector2(entityHit.TPosition.X, entityHit.TPosition.Y + 3);
                        CurrentEntity.Position = new Vector2(entityHit.Position.X + 8, entityHit.Position.Y - CurrentEntity.CurrentSprite.FrameSize.Y);
                        this.CurrentEntity.Game.CurrentScene.StartScript(new WarpScript((AvatarMain)CurrentEntity, this.Game, tposition));
                        //CurrentEntity.Position = new Vector2(entityHit.TPosition.X,entityHit.TPosition.Y-CurrentEntity.CurrentSprite.FrameSize.Y) ;
                        SoundManager.PlaySound("pipe");
                        /*
                        CurrentEntity.Gravity = 0;
                        Console.WriteLine("CurrentEntity.Position.Y: " + CurrentEntity.Position.Y);
                        Console.WriteLine("entityHit.TPosition.Y - CurrentEntity.CurrentSprite.SheetSize.Y: " + (entityHit.TPosition.Y - CurrentEntity.CurrentSprite.FrameSize.Y));
                        Console.WriteLine("CurrentEntity.CurrentSprite.SheetSize.Y: " + CurrentEntity.CurrentSprite.FrameSize.Y);
                        while (CurrentEntity.Position.Y > entityHit.TPosition.Y - CurrentEntity.CurrentSprite.FrameSize.Y)
                        {
                            CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, CurrentEntity.Position.Y - 1);
                        }
                        CurrentEntity.Velocity = new Vector2(0, 0);
                        */
                    }
                }
            }
           
            else if (CurrentEntity.Velocity.Y >= 0 && (entityHit is Goomba || entityHit is Koopa) &&!(entityHit.ActionState is InjuredGoomba))
            {
                if (CurrentEntity.ActionState == null&& entityHit.Master !=CurrentEntity)
                {
                    if (CurrentEntity.Position.Y + CurrentEntity.HitBox.Height < entityHit.HitBox.Y)
                    {
                        CurrentEntity.Position = new Vector2(CurrentEntity.Position.X, entityHit.HitBox.Y - CurrentEntity.CurrentSprite.FrameSize.Y);
                        CurrentEntity.Velocity = new Vector2(CurrentEntity.Velocity.X, -2);
                        CurrentEntity.CurrentActionState.Update(time);
                    }
                    else
                    {
                        if (!(CurrentEntity.CurrentPowerState is SmallMarioPowerUpState))
                        {
                            CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.Hit();
                            CurrentEntity.CurrentActionState.Update(time);
                        }
                        ((AvatarMain)CurrentEntity).Damage += 10;
                        ((AvatarMain)CurrentEntity).Launch(.5);
                        TimeSinceHit = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 3;
                    }
                }
                else if (CurrentEntity.ActionState != null)
                {
                    entityHit.ActionState = new DeadEnemy(entityHit);
                    if (CurrentEntity == Game.CurrentScene.PlayerAvatar)
                    {
                        entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                    }
                    else
                    {
                        entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                    }
                    entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                    entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier - 1)).ToString()));
                    entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                    entityHit.Velocity = new Vector2(Math.Abs(entityHit.Velocity.X) / entityHit.Velocity.X * 2, -4);
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
                        CurrentEntity.Position = new Vector2(entityHit.Position.X - CurrentEntity.HitBox.Width - 2, CurrentEntity.Position.Y);
                        //CurrentEntity.CurrentActionState.GoLeft(2);
                        CurrentEntity.CurrentActionState.Update(time);

                    }
                    else
                    {
                        CurrentEntity.Position = new Vector2(entityHit.Position.X + entityHit.HitBox.Width - 1, CurrentEntity.Position.Y);
                        //CurrentEntity.CurrentActionState.GoRight(2);
                        CurrentEntity.CurrentActionState.Update(time);

                    }
                     CurrentEntity.Velocity = new Vector2(0, CurrentEntity.Velocity.Y);
                }              
            }
            else if(entityHit.ActionState is AliveGoomba ||entityHit.ActionState is AliveKoopa||entityHit.ActionState is MovingShell)
            {
                if (entityHit.Master != CurrentEntity)
                {
                    if (time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds >= TimeSinceHit && CurrentEntity.ActionState == null)
                    {
                        if(!(CurrentEntity.CurrentPowerState is SmallMarioPowerUpState))
                        {
                            CurrentEntity.CurrentPowerState = CurrentEntity.CurrentPowerState.Hit();
                            CurrentEntity.CurrentActionState.Update(time);
                        }
                        ((AvatarMain)CurrentEntity).Damage += 10;
                        ((AvatarMain)CurrentEntity).Launch(.5);
                        TimeSinceHit = time.TotalGameTime.Minutes * 60 + time.TotalGameTime.Seconds + 3;

                    }
                    else if (CurrentEntity.ActionState != null)
                    {
                        entityHit.ActionState = new DeadEnemy(entityHit);
                        if (CurrentEntity == Game.CurrentScene.PlayerAvatar)
                        {
                            entityHit.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                        }
                        else
                        {
                            entityHit.Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.GREENKOOPA, entityHit.Position, time);
                        }


                        entityHit.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, (Indicators.IndicatorManager.GREENKOOPA_SCORE * Math.Pow(2, CurrentEntity.Game.FloatingScoreManager.Multiplier - 1)).ToString()));
                        entityHit.Game.FloatingScoreManager.UpdateMultiplier(time);
                        entityHit.Velocity = new Vector2(Math.Abs(entityHit.Velocity.X) / entityHit.Velocity.X * 2, -4);
                    }
                }
            }        
        }

        public void FlagPoleHit(IEntity entityHit, GameTime time)
        {

            CalcScore(entityHit, time);
            entityHit.ActionState.Update(time);
            SoundManager.EndBackground();
            SoundManager.PlaySound("ending");
            if (CurrentEntity.Position.Y < entityHit.Position.Y)
            {
                CurrentEntity.Position= new Vector2(entityHit.Position.X - 16, entityHit.Position.Y);
            }
            this.CurrentEntity.Position = new Vector2(this.CurrentEntity.Position.X +9, this.CurrentEntity.Position.Y);
            this.CurrentEntity.Velocity = Vector2.Zero;
            this.CurrentEntity.Game.CurrentScene.PlayerAvatar.AccelX = 0;
            this.CurrentEntity.Gravity = 0f;
            if(CurrentEntity.CurrentPowerState is SmallMarioPowerUpState)
            {
                this.CurrentEntity.CurrentSprite = MarioFactory.ClimbingMario(this.CurrentEntity.Game);

            }
            else if(CurrentEntity.CurrentPowerState is FireMarioPowerUpState)
            {
                this.CurrentEntity.CurrentSprite = MarioFactory.FireClimbingMario(this.CurrentEntity.Game);
            }
            else
            {
                this.CurrentEntity.CurrentSprite = MarioFactory.SuperClimbingMario(this.CurrentEntity.Game);

            }
            this.CurrentEntity.FacingRight = false;
            this.CurrentEntity.Game.CurrentScene.StartScript(new EndScript(this.CurrentEntity.Game, (AvatarMain)this.CurrentEntity, time.TotalGameTime.Minutes * 6000 + time.TotalGameTime.Seconds * 1000 + time.TotalGameTime.Milliseconds, time, (int)entityHit.Position.Y + 152 - CurrentEntity.CurrentSprite.FrameSize.Y));
        }

        public void CalcScore(IEntity entityHit, GameTime time)
        {
            float avatarColMidpoint = this.CurrentEntity.HitBox.Center.Y;
            entityHit.HitBox = new Rectangle((int)entityHit.Position.X, (int)entityHit.Position.Y, entityHit.CurrentSprite.FrameSize.X, entityHit.CurrentSprite.FrameSize.Y);
            float interval = .2f * entityHit.HitBox.Height;
            float tier1 = -(interval * 1) + entityHit.HitBox.Bottom;
            float tier2 = -(interval * 2) + entityHit.HitBox.Bottom;
            float tier3 = -(interval * 3) + entityHit.HitBox.Bottom;
            float tier4 = -(interval * 4) + entityHit.HitBox.Bottom;
            float tier5 = -(interval * 5) + entityHit.HitBox.Bottom;

            if(avatarColMidpoint >= tier1)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FLAG1, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FLAG1_SCORE.ToString()));

            }
            else if (avatarColMidpoint < tier1 && avatarColMidpoint >= tier2)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FLAG2, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FLAG2_SCORE.ToString()));

            }
            else if (avatarColMidpoint < tier2 && avatarColMidpoint >= tier3)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FLAG3, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FLAG3_SCORE.ToString()));

            }
            else if (avatarColMidpoint < tier3 && avatarColMidpoint >= tier4)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FLAG4, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FLAG4_SCORE.ToString()));

            }
            else if (avatarColMidpoint < tier4 && avatarColMidpoint >= tier5)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.FLAG5, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.FLAG5_SCORE.ToString()));

            }
            else if (avatarColMidpoint < entityHit.HitBox.Top)
            {
                CurrentEntity.Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.ONEUPMUSHROOM, CurrentEntity.Position, time);
                CurrentEntity.Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(entityHit.Position, Indicators.IndicatorManager.ONEUPMUSHROOM));

            }
            //CurrentEntity.Game.IndicatorManager.AddTimeScore();
        }
    }
}
