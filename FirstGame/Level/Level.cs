using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities.Items;
using Sprint0.Game_Enities.Enemies;
using System;
using System.Collections.Generic;
using System.IO;
using Sprint0.InputControllers;

namespace FirstGame
{
    class Level:ALevel
    {


        public Level(Game1 game, EntityManager entityManager)
        {
            this.Game = game;
            EntityManager = entityManager;
            ItemEnemyBlockList = new List<IEntity>();
            FloorList = new List<IBlockEntity>();
            CheckPoints= new List<float>();
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public override void LoadFile()
        {
            StreamReader sr;
            float positionY = 0;
            if(Game.Level == 1)
            {
                sr = File.OpenText(@"../../../../Level/Map1.csv");
            }
            else if (Game.Level == 2)
            {
                sr = File.OpenText(@"../../../../Level/Map2.csv");
            }
            else
            {
                sr = File.OpenText(@"../../../../Level/Map3.csv");
            }
            int scene = 0;
            float rightMost = 0;


            string nextLine;
            while ((nextLine = sr.ReadLine()) != null)
            {
    
                string[] cells = nextLine.Split(new Char[] { ',' });
                float positionX = 0;
            
                for (int i=0; i<cells.Length; i++)
                {
                    string[] split = cells[i].Split(new Char[] { '/' });
                    switch (split[0])
                    {
                        case "Player":
                            if(Game.Player1 == 1)
                            {
                                Game.CurrentScene.PlayerAvatar = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingLeftFactory(Game, "Mario"), new Vector2(positionX, positionY - 16), 1, "Mario");
                                CheckPoints.Add(positionX);
                            }
                            else if(Game.Player1 == 2)
                            {
                                Game.CurrentScene.PlayerAvatar = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Luigi"), new Vector2(positionX, positionY - 16), 1, "Luigi");
                                CheckPoints.Add(positionX);
                            }
                            else
                            {
                                Game.CurrentScene.PlayerAvatar = new TurtleAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Turtle"), new Vector2(positionX, positionY - 16), 1);
                                CheckPoints.Add(positionX);
                            }

                            break;

                        case "Player2":
                            if (Game.Player2 == 1)
                            {
                                Game.CurrentScene.PlayerAvatar2 = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingLeftFactory(Game, "Mario"), new Vector2(positionX, positionY - 16), 2, "Mario");
                                CheckPoints.Add(positionX);
                            }
                            else if (Game.Player2 == 2)
                            {
                                Game.CurrentScene.PlayerAvatar2 = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Luigi"), new Vector2(positionX, positionY - 16), 2, "Luigi");
                                CheckPoints.Add(positionX);
                            }
                            else
                            {
                                Game.CurrentScene.PlayerAvatar2 = new TurtleAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Turtle"), new Vector2(positionX, positionY - 16), 2);
                                CheckPoints.Add(positionX);
                            }
                            break;

                        #region Block Entities
                        case "Floor":
                            FloorList.Add(new FloorBlock(Game, "Floor", new Vector2(positionX, positionY), new Vector2(0,0)));
                            if (positionX > rightMost)
                            {
                                rightMost = positionX;
                            }
                            if (split.Length >1)
                            {
                                CheckPoints.Add(positionX);
                            }
                            break;
                        case "Step":
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "Step", new Vector2(positionX, positionY), new Vector2(0, 0)));
                            if (positionX > rightMost)
                            {
                                rightMost = positionX;
                            }
                            break;
                        case "EmptyBox":
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "EmptyBox", new Vector2(positionX, positionY), new Vector2(0, 0)));
                            break;
                        case "HiddenBox":
                            ItemEnemyBlockList.Add(new HiddenBlockEntity(Game, "Brick", new Vector2(positionX, positionY), int.Parse(split[1])+1, new Vector2(0, 0))); // hidden box can only contain coins, but can have multiple coins
                            break;
                        case "Brick":
                            ItemEnemyBlockList.Add(new StandardBlock(Game, "Brick", new Vector2(positionX, positionY), -1, "", new Vector2(0, 0))); // bricks do not have items, so default -1
                            break;
                        case "CoinBox":
                            ItemEnemyBlockList.Add(new StandardBlock(Game, "CoinBox", new Vector2(positionX, positionY), 1, split[1], new Vector2(0, 0))); // coinbox can contain different types of item, but only 1.
                            Console.WriteLine("split: " + split[1]);
                            break;
                        case "HiddenBrick":
                            ItemEnemyBlockList.Add(new HiddenBlockEntity(Game, "Brick", new Vector2(positionX, positionY), -1, new Vector2(0, 0))); // bricks do not have items, so default -1
                            break;
                        case "Platform":
                            ItemEnemyBlockList.Add(new PlatformEntity(Game, "Platform", new Vector2(positionX, positionY), new Vector2(0, 0))); // bricks do not have items, so default -1
                            break;

                        case "ShortPipe":
                            Vector2 tp = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "ShortPipe", new Vector2(positionX, positionY-16),tp));
                            break;
                        case "MediumPipe":
                            Vector2 tp2 = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp2 = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "MediumPipe", new Vector2(positionX, positionY-32), tp2));
                            break;
                        case "LongPipe":
                            Vector2 tp3 = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp3 = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "LongPipe", new Vector2(positionX, positionY-48), tp3));
                            break;
                        case "LongLPipe":
                            Vector2 tp4 = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp4 = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "LongLPipe", new Vector2(positionX, positionY-48), tp4));
                            break;
                        case "ShortLPipe":
                            Vector2 tp5 = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp5 = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "ShortLPipe", new Vector2(positionX, positionY-16), tp5));
                            break;
                        case "Pipe":
                            Vector2 tp6 = new Vector2(0, 0);
                            if (split.Length > 1)
                            {
                                if (split[1] is "PiranhaPlant")
                                {
                                    Console.WriteLine("ADD PiranhaPlant!");
                                    ItemEnemyBlockList.Add(new PiranhaPlantEntity(Game, EnemyFactory.CreateSprite(Game, "PirranhaPlant"), new Vector2(positionX + 7.5f, positionY - 14), new Vector2(0, 0)));
                                }
                                else
                                {
                                    tp6 = new Vector2(int.Parse(split[1]), int.Parse(split[2]));
                                }
                            }
                            ItemEnemyBlockList.Add(new BlockEntity(Game, "Pipe", new Vector2(positionX, positionY), tp6));
                            break;
                        case "Flagpole":
                            FlagEntity flag = new FlagEntity(new Vector2(positionX-7, positionY), BlockFactory.AllBlockFactory(Game, "Flag"),Game);
                            ItemEnemyBlockList.Add(flag);
                            ItemEnemyBlockList.Add(new FlagPole(new Vector2(positionX, positionY-8),flag,BlockFactory.AllBlockFactory(Game,"FlagPole"),Game));
                            break;
                        case "Castle":
                            ItemEnemyBlockList.Add(new Castle(new Vector2(positionX, positionY), BlockFactory.AllBlockFactory(Game, "Castle"), Game));
                            break;
                            #endregion

                        #region Item Entities
                        case "NormalFlower":
                            ItemEnemyBlockList.Add(new FireFlower(Game, ItemFactory.CreateSprite(Game, "NormalFlower"), new Vector2(positionX, positionY), new Vector2(0, 0)));
                            break;
                        case "BlueFlower":
                            ItemEnemyBlockList.Add(new FireFlower(Game, ItemFactory.CreateSprite(Game, "BlueFlower"), new Vector2(positionX, positionY), new Vector2(0, 0)));
                            break;
                        case "Star":
                            ItemEnemyBlockList.Add(new Star(Game, ItemFactory.CreateSprite(Game, "Star"), new Vector2(positionX, positionY), new Vector2(0, 0)));
                            break;
                        case "Coin":
                            ItemEnemyBlockList.Add(new Coin(Game, ItemFactory.CreateSprite(Game, "Coin"), new Vector2(positionX, positionY), new Vector2(0, 0)));
                            break;
                        case "SuperMushroom":
                            ItemEnemyBlockList.Add(new SuperMushroom(Game, ItemFactory.CreateSprite(Game, "SuperMushroom"), new Vector2(positionX, positionY), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        case "1UpMushroom":
                            ItemEnemyBlockList.Add(new OneUpMushroom(Game, ItemFactory.CreateSprite(Game, "1UpMushroom"), new Vector2(positionX, positionY), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        #endregion

                        #region Enemy Entities
                        case "NormalGoomba":
                            ItemEnemyBlockList.Add(new Goomba(Game, EnemyFactory.CreateSprite(Game, "NormalGoomba"), new Vector2(positionX, positionY-11), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        case "BlueGoomba":
                            ItemEnemyBlockList.Add(new Goomba(Game, EnemyFactory.CreateSprite(Game, "BlueGoomba"), new Vector2(positionX, positionY-11), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        case "GreyGoomba":
                            ItemEnemyBlockList.Add(new Goomba(Game, EnemyFactory.CreateSprite(Game, "GreyGoomba"), new Vector2(positionX, positionY-11), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        case "GreenKoopa":
                            ItemEnemyBlockList.Add(new Koopa(Game, EnemyFactory.CreateSprite(Game, "GreenKoopa"), new Vector2(positionX, positionY-11), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        case "RedKoopa":
                            ItemEnemyBlockList.Add(new Koopa(Game, EnemyFactory.CreateSprite(Game, "RedKoopa"), new Vector2(positionX, positionY-11), new Vector2(float.Parse(split[1]), 0)));
                            break;
                        #endregion
                        case "Switch":
                            scene += 1;
                           // rightMost = 0;
                            break;
                    }
                    positionX += (float)16;
                    BottomRightBoundary = new Vector2(rightMost, Game.GraphicsDevice.Viewport.Height);
                    if (scene == 0)
                    {
                        BottomRightBoundary = new Vector2(rightMost, Game.GraphicsDevice.Viewport.Height);
                    }
                    else if(scene == 1)
                    {
                        BottomRightBoundary2 = new Vector2(rightMost, Game.GraphicsDevice.Viewport.Height);
                    }
                }
                positionY += (float)16;
            }
            sr.Close();
            Console.WriteLine(rightMost);
        }


        public override void LoadEntity()
        {
            Game.CurrentScene.PlayerAvatar.Initialize();
            Game.CurrentScene.PlayerAvatar2.Initialize();
            EntityManager.AddEntity(Game.CurrentScene.PlayerAvatar);
            EntityManager.AddEntity(Game.CurrentScene.PlayerAvatar2);
            Point currentBlockSize = new Point(0, 0);
           // Vector2 currentBlockPosition = Vector2.Zero;
           // Vector2 blockPosition = Vector2.Zero;
            /*
            foreach(FloorBlock block in FloorList)
            {
                if ((currentBlockPosition == Vector2.Zero))
                {
                    currentBlockPosition = block.Position;
                    currentBlockSize.X = currentBlockSize.X + 16;
                }
                else if(currentBlockPosition.X + currentBlockSize.X == block.Position.X)
                {
                    currentBlockSize.X = currentBlockSize.X + 16;
                }
                else 
                {
                    blockPosition = block.Position;
                    block.Initialize();
                    block.Position = currentBlockPosition;
                    currentBlockSize.Y = 32;
                    block.ChangeSize(currentBlockSize);
                    EntityManager.AddEntity(block);
                    currentBlockPosition = blockPosition;
                    currentBlockSize = new Point(16, 0);
                }

                if (block.Position.X == BottomRightBoundary.X)
                {
                    block.Initialize();
                    block.Position = currentBlockPosition;
                    currentBlockSize.Y =32;
                    block.ChangeSize(currentBlockSize);
                    EntityManager.AddEntity(block);
                }
            }
            */
            foreach (FloorBlock block in FloorList)
            {
                block.Initialize();
                EntityManager.AddEntity(block);
            }
                foreach (IEntity item in ItemEnemyBlockList)
            {
                item.Initialize();
                EntityManager.AddEntity(item);
            }
        }


        public override void ResetLevel()
        {
            EntityManager.RemoveAllEntity();
            ItemEnemyBlockList = new List<IEntity>();
            FloorList = new List<IBlockEntity>();
            this.LoadFile();
            this.LoadEntity();
            CollisionHandling.Create(ref EntityManager.entities);
            Game.CurrentScene.Camera = Game.CurrentScene.Camera1;
            Game.CurrentScene.Controller =new Controller(new Sprint0.Commands.Mapping.CommandMap(Game));
            Game.CurrentScene.Iter = 0;
            
            //Game.AvatorLife = 3;
        }

        public override void ResetAvator(float positionX)
        {
            EntityManager.RemoveEntity(Game.CurrentScene.PlayerAvatar);
            Game.CurrentScene.PlayerAvatar = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Mario"), new Vector2(positionX, 0),1,"Mario");
            Game.CurrentScene.PlayerAvatar.Initialize();
            EntityManager.AddEntity(Game.CurrentScene.PlayerAvatar,0);

            Game.CurrentScene.PlayerAvatar2 = new MarioAvatar(Game, AvatarFactory.SmallAvatarFacingRightFactory(Game, "Luigi"), new Vector2(positionX+50, 0),2,"Luigi");
            Game.CurrentScene.PlayerAvatar2.Initialize();
            EntityManager.AddEntity(Game.CurrentScene.PlayerAvatar2, 0);


            CollisionHandling.Create(ref EntityManager.entities);
            Game.CurrentScene.Controller = new Controller(new Sprint0.Commands.Mapping.CommandMap(Game));
        }
    }
}
