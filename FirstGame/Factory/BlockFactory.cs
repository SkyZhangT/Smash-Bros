using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    static class BlockFactory
    {
        //Factory classes will usually have a high cyclomatic complexity
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static ISprite AllBlockFactory(Game1 game, string type)
        {
            ISprite block;
            switch (type)
            {
                case "Floor":
                    block = FloorBlockFactory(game);
                    break;
                case "NFloor":
                    block = NFloorBlockFactory(game);
                    break;
                case "UGFloor":
                    block = UGFloorBlockFactory(game);
                    break;
                case "CFloor":
                    block = CFloorBlockFactory(game);
                    break;
                case "Platform":
                    block = PlatformFactory(game);
                    break;
                case "Step":
                    block = SpecialBlockFactory(game);
                    break;
                case "Brick":
                    block = StaticBrickFactory(game);
                    break;
                case "JumpingBrick":
                    block = JumpingBrickFactory(game);
                    break;
                case "CoinBox":
                    block = CoinBoxFactory(game);
                    break;
                case "EmptyBox":
                    block = EmptyCoinBoxFactory(game);
                    break;
                case "JumpingEmptyBox":
                    block = JumpingEmptyBoxFactory(game);
                    break;
                case "BreakBrick":
                    block = ExplodeBrickFactory(game);
                    break;
                case "LongPipe":
                    block = LongPipeFactory(game);
                    break;
                case "LongLPipe":
                    block = LongLPipeFactory(game);
                    break;
                case "MediumPipe":
                    block = MediumPipeFactory(game);
                    break;
                case "ShortPipe":
                    block = ShortPipeFactory(game);
                    break;
                case "ShortLPipe":
                    block = ShortLPipeFactory(game);
                    break;
                case "Pipe":
                    block = PipingFactory(game);
                    break;
                case "Frag":
                    block = BrickFragFactory(game);
                    break;
                case "FlagPole":
                    block = FlagPole(game);
                    break;
                case "Flag":
                    block = Flag(game);
                    break;
                case "Castle":
                    block = Castle(game);
                    break;
                case "FireWorks":
                    block = FireWorks(game);
                    break;
                case "StarFlag":
                    block = StarFlag(game);
                    break;
                case "fireball":
                    block = Fireball(game);
                    break;
                case "greenfireball":
                    block = GreenFireball(game);
                    break;
                case "bluefireball":
                    block = BlueFireball(game);
                    break;
                case "thwomp":
                    block = Thwomp(game);
                    break;
                case "fish":
                    block = Fish(game);
                    break;
                default:
                    block = StaticBrickFactory(game);
                    break;
            }
            return block;
        }

        private static AnimatedSprite Fireball(Game1 game)
        {
            AnimatedSprite fireball = new FireBallSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/FireBall"),
                SheetSize = new Point(4, 1),
                CurrentFrame = new Point(1, 0),
                MillisecondsPerFrame = 200,
                FrameSize = new Point(8, 8)
            };
            return fireball;
        }
        private static AnimatedSprite GreenFireball(Game1 game)
        {
            AnimatedSprite fireball = new FireBallSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/GreenFireBall"),
                SheetSize = new Point(4, 1),
                CurrentFrame = new Point(1, 0),
                MillisecondsPerFrame = 200,
                FrameSize = new Point(8, 8)
            };
            return fireball;
        }
        private static AnimatedSprite BlueFireball(Game1 game)
        {
            AnimatedSprite fireball = new FireBallSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/BlueFireBall"),
                SheetSize = new Point(4, 1),
                CurrentFrame = new Point(1, 0),
                MillisecondsPerFrame = 200,
                FrameSize = new Point(8, 8)
            };
            return fireball;
        }


        #region StaticBlocks

        public static StaticSprite FloorBlockFactory(Game1 game)
        {
            StaticSprite FloorBlockFactory = new StaticSprite
            {
                SheetSize = new Point(1, 1)
            };
            if (game.Level == 1)
            {
                FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/FloorBlock");
            }
            else if (game.Level == 2)
            {
                FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGFloorBlock");
            }
            else
            {
                FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/CFloorBlock");
            }
            FloorBlockFactory.FrameSize = new Point(FloorBlockFactory.Texture.Width / FloorBlockFactory.SheetSize.X, FloorBlockFactory.Texture.Height / FloorBlockFactory.SheetSize.Y);
            FloorBlockFactory.CurrentFrame = new Point(0, 0);
            return FloorBlockFactory;
        }

        public static StaticSprite NFloorBlockFactory(Game1 game)
        {
            StaticSprite FloorBlockFactory = new StaticSprite
            {
                SheetSize = new Point(1, 1)
            };
            FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/FloorBlock");
            FloorBlockFactory.FrameSize = new Point(FloorBlockFactory.Texture.Width / FloorBlockFactory.SheetSize.X, FloorBlockFactory.Texture.Height / FloorBlockFactory.SheetSize.Y);
            FloorBlockFactory.CurrentFrame = new Point(0, 0);
            return FloorBlockFactory;
        }

        public static StaticSprite UGFloorBlockFactory(Game1 game)
        {
            StaticSprite FloorBlockFactory = new StaticSprite
            {
                SheetSize = new Point(1, 1)
            };
            FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGFloorBlock");
            FloorBlockFactory.FrameSize = new Point(FloorBlockFactory.Texture.Width / FloorBlockFactory.SheetSize.X, FloorBlockFactory.Texture.Height / FloorBlockFactory.SheetSize.Y);
            FloorBlockFactory.CurrentFrame = new Point(0, 0);
            return FloorBlockFactory;
        }

        public static StaticSprite CFloorBlockFactory(Game1 game)
        {
            StaticSprite FloorBlockFactory = new StaticSprite
            {
                SheetSize = new Point(1, 1)
            };
            FloorBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/CFloorBlock");
            FloorBlockFactory.FrameSize = new Point(FloorBlockFactory.Texture.Width / FloorBlockFactory.SheetSize.X, FloorBlockFactory.Texture.Height / FloorBlockFactory.SheetSize.Y);
            FloorBlockFactory.CurrentFrame = new Point(0, 0);
            return FloorBlockFactory;
        }

        public static StaticSprite PlatformFactory(Game1 game)
        {
            StaticSprite PlatformFactory = new StaticSprite
            {
                SheetSize = new Point(1, 1)
            };
            PlatformFactory.Texture = game.Content.Load<Texture2D>("Blocks/Platform");
            PlatformFactory.FrameSize = new Point(PlatformFactory.Texture.Width / PlatformFactory.SheetSize.X, PlatformFactory.Texture.Height / PlatformFactory.SheetSize.Y);
            PlatformFactory.CurrentFrame = new Point(0, 0);
            return PlatformFactory;
        }

        public static StaticSprite SpecialBlockFactory(Game1 game)
        {
            StaticSprite SpecialBlockFactory = new StaticSprite {
                SheetSize = new Point(1, 1)
            };
            if (game.Level == 1)
            {
                SpecialBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/SpecialBlock");
            }
            else if (game.Level == 2)
            {
                SpecialBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGSpecialBlock");
            }
            else
            {
                SpecialBlockFactory.Texture = game.Content.Load<Texture2D>("Blocks/CSpecialBlock");
            }
            SpecialBlockFactory.FrameSize = new Point(SpecialBlockFactory.Texture.Width / SpecialBlockFactory.SheetSize.X, SpecialBlockFactory.Texture.Height / SpecialBlockFactory.SheetSize.Y);
            SpecialBlockFactory.CurrentFrame = new Point(0, 0);
            return SpecialBlockFactory;
        }

        public static StaticSprite StaticBrickFactory(Game1 game)
        {
            StaticSprite StaticBrickFactory = new StaticSprite{
                SheetSize = new Point(5, 1)
            };
            if (game.Level == 1)
            {
                StaticBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/Brick");
            }
            else if (game.Level == 2)
            {
                StaticBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGBrick");
            }
            else
            {
                StaticBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/CBrick");
            }
            StaticBrickFactory.FrameSize = new Point(StaticBrickFactory.Texture.Width / StaticBrickFactory.SheetSize.X, StaticBrickFactory.Texture.Height / StaticBrickFactory.SheetSize.Y);
            StaticBrickFactory.CurrentFrame = new Point(0, 0);
            return StaticBrickFactory;
        }

        public static StaticSprite EmptyCoinBoxFactory(Game1 game)
        {
            StaticSprite StaticCoinBoxFactory = new StaticSprite
            {
                SheetSize = new Point(5, 1)
            };

            if (game.Level == 1)
            {
                StaticCoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CoinBox");
            }
            else if (game.Level == 2)
            {
                StaticCoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGCoinBox");
            }
            else
            {
                StaticCoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CCoinBox");
            }

            StaticCoinBoxFactory.FrameSize = new Point(StaticCoinBoxFactory.Texture.Width / StaticCoinBoxFactory.SheetSize.X, StaticCoinBoxFactory.Texture.Height / StaticCoinBoxFactory.SheetSize.Y);
            StaticCoinBoxFactory.CurrentFrame = new Point(4, 0);
            return StaticCoinBoxFactory;
        }

        public static AnimatedSprite JumpingBrickFactory(Game1 game)
        {
            AnimatedSprite JumpingBrickFactory = new JumpingBlock
            {
                SheetSize = new Point(5, 1),
                MillisecondsPerFrame = 50,
                CurrentFrame = new Point(0, 0)
            };
            if (game.Level == 1)
            {
                JumpingBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/Brick");
            }
            else if (game.Level == 2)
            {
                JumpingBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGBrick");
            }
            else
            {
                JumpingBrickFactory.Texture = game.Content.Load<Texture2D>("Blocks/CBrick");
            }
            JumpingBrickFactory.FrameSize = new Point(JumpingBrickFactory.Texture.Width / JumpingBrickFactory.SheetSize.X, JumpingBrickFactory.Texture.Height / JumpingBrickFactory.SheetSize.Y);
            return JumpingBrickFactory;
        }

        public static AnimatedSprite JumpingEmptyBoxFactory(Game1 game)
        {
            AnimatedSprite JumpingEmptyBoxFactory = new JumpingBlock
            {
                SheetSize = new Point(5, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 50
            };

            if (game.Level == 1)
            {
                JumpingEmptyBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CoinBox");
            }
            else if (game.Level == 2)
            {
                JumpingEmptyBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGCoinBox");
            }
            else
            {
                JumpingEmptyBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CCoinBox");
            }

            JumpingEmptyBoxFactory.FrameSize = new Point(JumpingEmptyBoxFactory.Texture.Width / JumpingEmptyBoxFactory.SheetSize.X, JumpingEmptyBoxFactory.Texture.Height / JumpingEmptyBoxFactory.SheetSize.Y);

            return JumpingEmptyBoxFactory;
        }

        public static StaticSprite BrickFragFactory(Game1 game)
        {
            StaticSprite frag = new StaticSprite
            { 
                FrameSize = new Point(10, 10),
                CurrentFrame = new Point(0, 0)
            };
            if (game.Level == 1)
            {
                frag.Texture = game.Content.Load<Texture2D>("Blocks/frag");
            }else if (game.Level == 2)
            {
                frag.Texture = game.Content.Load<Texture2D>("Blocks/UGfrag");
            }
            else
            {
                frag.Texture = game.Content.Load<Texture2D>("Blocks/Cfrag");
            }
            return frag;
        }
        #endregion

        #region AnimatedBlocks
        public static AnimatedSprite CoinBoxFactory(Game1 game)
        {
            AnimatedSprite CoinBoxFactory = new CoinBox
            {
                SheetSize = new Point(5, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 200
            };
            if (game.Level == 1)
            {
                CoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CoinBox");
            }
            else if (game.Level == 2)
            {
                CoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/UGCoinBox");
            }
            else
            {
                CoinBoxFactory.Texture = game.Content.Load<Texture2D>("Blocks/CCoinBox");
            }
            CoinBoxFactory.FrameSize = new Point(CoinBoxFactory.Texture.Width / CoinBoxFactory.SheetSize.X, CoinBoxFactory.Texture.Height / CoinBoxFactory.SheetSize.Y);
            return CoinBoxFactory;
        }

        public static AnimatedSprite ExplodeBrickFactory(Game1 game)
        {
            AnimatedSprite ExplodeBrick = new BreakBrick
            {
                SheetSize = new Point(5, 1),
                CurrentFrame = new Point(1, 0),
                MillisecondsPerFrame = 80
            };
            if (game.Level == 1)
            {
                ExplodeBrick.Texture = game.Content.Load<Texture2D>("Blocks/Brick");
            }
            else if (game.Level == 2)
            {
                ExplodeBrick.Texture = game.Content.Load<Texture2D>("Blocks/UGBrick");
            }
            else
            {
                ExplodeBrick.Texture = game.Content.Load<Texture2D>("Blocks/CBrick");
            }
            ExplodeBrick.FrameSize = new Point(ExplodeBrick.Texture.Width / ExplodeBrick.SheetSize.X, ExplodeBrick.Texture.Height / ExplodeBrick.SheetSize.Y);

            return ExplodeBrick;
        }
        #endregion

        #region Pipe
        public static StaticSprite LongPipeFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(32, 64),
                CurrentFrame = new Point(4, 0)
            };
            return pipe;
        }
        public static StaticSprite MediumPipeFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(32, 48),
                CurrentFrame = new Point(5, 0)
            };
            return pipe;
        }
        public static StaticSprite ShortPipeFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(32, 32),
                CurrentFrame = new Point(6, 0)
            };
            return pipe;
        }
        public static StaticSprite LongLPipeFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(64, 128),
                CurrentFrame = new Point(0, 0)
            };
            return pipe;
        }
        public static StaticSprite ShortLPipeFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(64, 64),
                CurrentFrame = new Point(1, 0)
            };
            return pipe;
        }
        public static StaticSprite PipingFactory(Game1 game)
        {
            StaticSprite pipe = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Pipe"),
                FrameSize = new Point(32, 32),
                CurrentFrame = new Point(1, 0)
            };
            return pipe;
        }

        #endregion

        public static StaticSprite FlagPole(Game1 game)
        {
            StaticSprite flagpole = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/Flag"),
                FrameSize = new Point(16, 168),
                CurrentFrame = new Point(1, 0)
            };
            return flagpole;
        }

        public static StaticSprite Flag(Game1 game)
        {
            StaticSprite flagpole = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Blocks/ActualFlag"),
                FrameSize = new Point(16, 16),
                CurrentFrame = new Point(1, 0)
            };
            return flagpole;
        }

        public static StaticSprite Castle(Game1 game)
        {
            StaticSprite Castle = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Background/Castle"),
                FrameSize = new Point(80, 80),
                CurrentFrame = new Point(1, 0)
            };
            return Castle;
        }

        public static AnimatedSprite FireWorks(Game1 game)
        {
            AnimatedSprite fireworks = new Fireworks
            {
                Texture = game.Content.Load<Texture2D>("Background/Firework"),
                SheetSize = new Point(3, 1),
                CurrentFrame = new Point(1, 0),
                MillisecondsPerFrame = 200,
                FrameSize = new Point(16, 16)
            };
            return fireworks;
        }

        public static StaticSprite StarFlag(Game1 game)
        {
            StaticSprite flag = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Background/StarFlag"),
                FrameSize = new Point(13, 14),
                CurrentFrame = new Point(1, 0)
            };
            return flag;
        }
        public static StaticSprite Thwomp(Game1 game)
        {
            StaticSprite thwomp = new StaticSprite
            {
                CurrentFrame = new Point(0, 0),
                Texture = game.Content.Load<Texture2D>("Enemies/Thwomp"),
                FrameSize = new Point(26, 34)
            };
            return thwomp;
        }

        public static AnimatedSprite Fish(Game1 game)
        {
            AnimatedSprite fish = new MovingGoombaSprite
            {
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                FrameSize = new Point(16),
                Texture = game.Content.Load<Texture2D>("Enemies/CheepCheep"),
                MillisecondsPerFrame = 200
            };
            return fish;
        }

        public static StaticSprite BulletBill(Game1 game)
        {
            StaticSprite bull = new StaticSprite
            {
                CurrentFrame = new Point(0),
                Texture = game.Content.Load<Texture2D>("Enemies/BulletBill"),
                FrameSize = new Point(160, 140)
            };
            return bull;
        }

        public static StaticSprite BulletBillItem(Game1 game)
        {
            StaticSprite bull = new StaticSprite
            {
                CurrentFrame = new Point(0),
                Texture = game.Content.Load<Texture2D>("Items/BulletBillItem"),
                FrameSize = new Point(16, 14)
            };
            return bull;
        }

        public static StaticSprite CheepCheepItem(Game1 game)
        {
            StaticSprite bull = new StaticSprite
            {
                CurrentFrame = new Point(0),
                Texture = game.Content.Load<Texture2D>("Items/CheepCheepItem"),
                FrameSize = new Point(16, 14)
            };
            return bull;
        }
        public static StaticSprite ThwompItem(Game1 game)
        {
            StaticSprite bull = new StaticSprite
            {
                CurrentFrame = new Point(0),
                Texture = game.Content.Load<Texture2D>("Items/ThwompItem"),
                FrameSize = new Point(16, 14)
            };
            return bull;
        }



    }


}