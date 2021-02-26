using Sprint0.Game_Enities.Blocks;
using FirstGame;
using Microsoft.Xna.Framework;
using System;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Items;
using Sprint0.Sounds;
using Sprint0.Indicators.Instants;

namespace Sprint0.State.BlockStates
{
    class BumpState : IBlockState, IState
    {
        public IBlockEntity Block { get; set; }
        public Game1 Game { get; set; }
        private Vector2 OriginalPosition { get; set; }
        public IEntity Entity { get; set; }
        public BumpState(Game1 g, IBlockEntity b,GameTime time)
        {
            Game = g;
            OriginalPosition = b.Position;
            IEntity nearAvatar;
            if (Math.Abs(Game.CurrentScene.PlayerAvatar.Position.X - this.OriginalPosition.X) > Math.Abs(Game.CurrentScene.PlayerAvatar2.Position.X - this.OriginalPosition.X))
            {
                nearAvatar = Game.CurrentScene.PlayerAvatar2;
            }
            else
            {
                nearAvatar = Game.CurrentScene.PlayerAvatar;
            }



            this.Entity = b;
           
            
            Console.WriteLine("COIN LEFT: " + b.CoinLeft);
            if (b.CoinLeft == 1)
            {
                b.CurrentSprite = BlockFactory.AllBlockFactory(g, "JumpingEmptyBox");
                b.CurrentSprite.Ground = new Vector2(b.Position.X, b.Position.Y);
                b.CurrentSprite.Top = new Vector2(b.Position.X, b.Position.Y-5);
                if(b.ItemType is "SuperMushroom")
                {
                    int xV;
                    if (nearAvatar.FacingRight)
                    {
                        xV = 1;
                    }
                    else
                    {
                        xV = -1;
                    }
                    IEntity superMushroom;
                    if(nearAvatar.CurrentPowerState is SmallMarioPowerUpState)
                    {
                        superMushroom = new SuperMushroom(Game, ItemFactory.CreateSprite(Game, "SuperMushroom"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(xV, 0))
                        {
                            Gravity = 0.08f
                        };
                    }
                    else if(nearAvatar.CurrentPowerState is SuperMarioPowerUpState)
                    {
                        superMushroom = new FireFlower(Game, ItemFactory.CreateSprite(Game, "NormalFlower"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(0, 0f))
                        {
                            Gravity = 0.08f
                        };
                    }
                    else
                    {
                        superMushroom = new Star(Game, ItemFactory.CreateSprite(Game, "Star"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(xV, -1.5f))
                        {
                            Gravity = 0.08f
                        };
                    }
                   
                    superMushroom.Initialize();
                    Game.EntityManager.AddEntity(superMushroom);
                    CollisionHandling.Update(superMushroom, superMushroom.Position);
                    SoundManager.PlaySound("powerupup");

                }
                else if (b.ItemType is "1UpMushroom")
                {
                    int xV;
                    if (nearAvatar.FacingRight)
                    {
                        xV = -1;
                    }
                    else
                    {
                        xV = 1;
                    }
                    IEntity oneUpMushroom = new OneUpMushroom(Game, ItemFactory.CreateSprite(Game, "1UpMushroom"), new Vector2(b.Position.X, b.Position.Y-16), new Vector2(xV, 0))
                    {
                        Gravity = 0.08f
                    };
                    Console.WriteLine("xV: " + xV);
                    Console.WriteLine("X speed: " + oneUpMushroom.Velocity);
                    oneUpMushroom.Initialize();
                    Game.EntityManager.AddEntity(oneUpMushroom);
                    CollisionHandling.Update(oneUpMushroom, oneUpMushroom.Position);
                    SoundManager.PlaySound("powerupup");
                }
                else if(b.ItemType is "Star")
                {
                    int xV;
                    if (nearAvatar.FacingRight)
                    {
                        xV = 1;
                    }
                    else
                    {
                        xV = -1;
                    }
                    ItemEntity superMushroom = new Star(Game, ItemFactory.CreateSprite(Game, "Star"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(xV, -1.5f))
                    {
                        Gravity = 0.08f
                    };
                    

                    superMushroom.Initialize();
                    Game.EntityManager.AddEntity(superMushroom);
                    CollisionHandling.Update(superMushroom, superMushroom.Position);
                    SoundManager.PlaySound("powerupup");
                }
                else
                {

                    if(nearAvatar==Game.CurrentScene.PlayerAvatar)
                    {
                        Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.COIN, Entity.Position, time);
                    }
                    else
                    {
                        Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.COIN, Entity.Position, time);
                    }

                    Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(Entity.Position, (Indicators.IndicatorManager.COIN_SCORE).ToString()));
                    IEntity coin = new Coin(Game, ItemFactory.CreateSprite(Game, "Coin"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(0, -2))
                    {
                        Gravity = 0.08f
                    };
                    Console.WriteLine("VELOCITY: " + coin.Velocity);
                    coin.Initialize();
                    Game.EntityManager.AddEntity(coin);
                    //CollisionHandling.Update(coin, coin.Position);
                    SoundManager.PlaySound("coin");
                }
            }
            else 
            {
                b.CurrentSprite = BlockFactory.AllBlockFactory(g, "JumpingBrick");
                b.CurrentSprite.Ground = new Vector2(b.Position.X, b.Position.Y);
                b.CurrentSprite.Top = new Vector2(b.Position.X, b.Position.Y - 5);
                if (b.CoinLeft >= 0)
                {

                    if (nearAvatar == Game.CurrentScene.PlayerAvatar)
                    {
                        Game.CurrentScene.IndicatorManager.UpdateIndicators(Indicators.IndicatorManager.COIN, Entity.Position, time);
                    }
                    else
                    {
                        Game.CurrentScene.IndicatorManager2.UpdateIndicators(Indicators.IndicatorManager.COIN, Entity.Position, time);
                    }

                   
                    Game.FloatingScoreManager.Addfloatingscore(new FloatingScore(Entity.Position, (Indicators.IndicatorManager.COIN_SCORE).ToString()));
                    IEntity coin = new Coin(Game, ItemFactory.CreateSprite(Game, "Coin"), new Vector2(b.Position.X, b.Position.Y - 16), new Vector2(0, -2))
                    {
                        Gravity = 0.08f
                    };
                    coin.Initialize();
                    Game.EntityManager.AddEntity(coin);
                    CollisionHandling.Update(coin, coin.Position);
                    SoundManager.PlaySound("coin");
                }
                else
                {
                    SoundManager.PlaySound("bump");
                }
            }
            b.CurrentSprite.Entity = b;
            b.Position = new Vector2(b.Position.X, b.Position.Y - 1);
            Block = b;
            Block.HitBox = new Rectangle((int)Block.Position.X, (int)Block.Position.Y, Block.CurrentSprite.FrameSize.X, Block.CurrentSprite.FrameSize.Y);
        }

        public void StandardTransition()
        {
            if (Block.Position.Y == OriginalPosition.Y)
            {
                if (Block.CoinLeft == 0)
                {
                    Block.CurrentState = new StaticBlockState(Game, Block);
                }
                else if (Block.CoinLeft > 0)
                {
                    Block.CurrentState = new StandardCoinBrickState(Game, Block);
                }
                else
                {
                    Block.CurrentState = new StandardBrickState(Game, Block);
                }
            }
        }

        public void BumpTransition(IEntity cause, GameTime time)
        {

        }

        public void UsedTransition()
        {

        }
        public void Update(GameTime time)
        {
           //NOT IMPLEMENTED
        }
    }
}
