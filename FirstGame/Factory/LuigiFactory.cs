using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    static public class LuigiFactory
    {


        #region SmallLuigi

        public static StaticSprite SmallLuigiFacingLeftFactory(Game game)
        {
            StaticSprite smallLuigiFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = false
            };
            smallLuigiFacingLeft.FrameSize = new Point(18, 18);

            return smallLuigiFacingLeft;
        }

        public static StaticSprite SmallLuigiFacingRightFactory(Game game)
        {
            StaticSprite smallLuigiFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = true
            };
            smallLuigiFacingRight.FrameSize = new Point(smallLuigiFacingRight.Texture.Width / smallLuigiFacingRight.SheetSize.X, smallLuigiFacingRight.Texture.Height / smallLuigiFacingRight.SheetSize.Y);

            return smallLuigiFacingRight;
        }

        public static AnimatedSprite SmallLuigiRunningLeftFactory(Game game)
        {
            AnimatedSprite smallLuigiRunningLeft = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            smallLuigiRunningLeft.FrameSize = new Point(smallLuigiRunningLeft.Texture.Width / smallLuigiRunningLeft.SheetSize.X, smallLuigiRunningLeft.Texture.Height / smallLuigiRunningLeft.SheetSize.Y);

            return smallLuigiRunningLeft;
        }

        public static AnimatedSprite SmallLuigiRunningRightFactory(Game game)
        {
            AnimatedSprite smallLuigiRunningRight = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            smallLuigiRunningRight.FrameSize = new Point(smallLuigiRunningRight.Texture.Width / smallLuigiRunningRight.SheetSize.X, smallLuigiRunningRight.Texture.Height / smallLuigiRunningRight.SheetSize.Y);

            return smallLuigiRunningRight;
        }

        public static AnimatedSprite SmallLuigiWalkingLeftFactory(Game game)
        {
            AnimatedSprite smallLuigiWalkingLeft = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            smallLuigiWalkingLeft.FrameSize = new Point(smallLuigiWalkingLeft.Texture.Width / smallLuigiWalkingLeft.SheetSize.X, smallLuigiWalkingLeft.Texture.Height / smallLuigiWalkingLeft.SheetSize.Y);

            return smallLuigiWalkingLeft;
        }

        public static AnimatedSprite SmallLuigiWalkingRightFactory(Game game)
        {
            AnimatedSprite smallLuigiWalkingRight = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            smallLuigiWalkingRight.FrameSize = new Point(smallLuigiWalkingRight.Texture.Width / smallLuigiWalkingRight.SheetSize.X, smallLuigiWalkingRight.Texture.Height / smallLuigiWalkingRight.SheetSize.Y);
 
            return smallLuigiWalkingRight;
        }

        public static AnimatedSprite SmallLuigiJumpingLeftFactory(Game game)
        {
            AnimatedSprite smallLuigiJumpingLeft = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                Top = new Vector2(300, 50 - 40),
                Ground = new Vector2(300, 50),
                MillisecondsPerFrame = 10,
                NeedFlip = false
            };
            smallLuigiJumpingLeft.FrameSize = new Point(smallLuigiJumpingLeft.Texture.Width / smallLuigiJumpingLeft.SheetSize.X, smallLuigiJumpingLeft.Texture.Height / smallLuigiJumpingLeft.SheetSize.Y);

            return smallLuigiJumpingLeft;
        }

        public static AnimatedSprite SmallLuigiJumpingRightFactory(Game game)
        {
            AnimatedSprite smallLuigiJumpingRight = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                NeedFlip = true,
                Top = new Vector2(350, 50 - 40),
                Ground = new Vector2(350, 50)
            };
            smallLuigiJumpingRight.FrameSize = new Point(smallLuigiJumpingRight.Texture.Width / smallLuigiJumpingRight.SheetSize.X, smallLuigiJumpingRight.Texture.Height / smallLuigiJumpingRight.SheetSize.Y);

            return smallLuigiJumpingRight;
        }

        public static AnimatedSprite DeadLuigiFactory(Game game)
        {
            AnimatedSprite deadLuigi = new DeadLuigi
            {
                Texture = game.Content.Load<Texture2D>("Luigi/DeadLuigi"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                Top = new Vector2(400, 50),
                Ground = new Vector2(400, game.GraphicsDevice.Viewport.Height)
            };
            deadLuigi.FrameSize = new Point(deadLuigi.Texture.Width / deadLuigi.SheetSize.X, deadLuigi.Texture.Height / deadLuigi.SheetSize.Y);

            return deadLuigi;
        }
        #endregion

        #region SuperLuigi
        public static StaticSprite SuperLuigiFacingLeftFactory(Game game)
        {
            StaticSprite superLuigiFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = false
            };
            superLuigiFacingLeft.FrameSize = new Point(superLuigiFacingLeft.Texture.Width / superLuigiFacingLeft.SheetSize.X, superLuigiFacingLeft.Texture.Height / superLuigiFacingLeft.SheetSize.Y);

            return superLuigiFacingLeft;
        }

        public static StaticSprite SuperLuigiFacingRightFactory(Game game)
        {
            StaticSprite SuperLuigiFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = true
            };
            SuperLuigiFacingRight.FrameSize = new Point(SuperLuigiFacingRight.Texture.Width / SuperLuigiFacingRight.SheetSize.X, SuperLuigiFacingRight.Texture.Height / SuperLuigiFacingRight.SheetSize.Y);

            return SuperLuigiFacingRight;
        }

        public static StaticSprite SuperLuigiPunchingLeftFactory(Game game)
        {
            StaticSprite superLuigiPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(10, 0),
                NeedFlip = false
            };
            superLuigiPunchingLeft.FrameSize = new Point(superLuigiPunchingLeft.Texture.Width / superLuigiPunchingLeft.SheetSize.X, superLuigiPunchingLeft.Texture.Height / superLuigiPunchingLeft.SheetSize.Y);

            return superLuigiPunchingLeft;
        }

        public static StaticSprite SuperLuigiPunchingLeftBFactory(Game game)
        {
            StaticSprite superLuigiPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                NeedFlip = false
            };
            superLuigiPunchingLeft.FrameSize = new Point(superLuigiPunchingLeft.Texture.Width / superLuigiPunchingLeft.SheetSize.X, superLuigiPunchingLeft.Texture.Height / superLuigiPunchingLeft.SheetSize.Y);

            return superLuigiPunchingLeft;
        }

        public static StaticSprite SuperLuigiPunchingRightFactory(Game game)
        {
            StaticSprite superLuigiPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(10, 0),
                NeedFlip = true
            };
            superLuigiPunchingRight.FrameSize = new Point(superLuigiPunchingRight.Texture.Width / superLuigiPunchingRight.SheetSize.X, superLuigiPunchingRight.Texture.Height / superLuigiPunchingRight.SheetSize.Y);

            return superLuigiPunchingRight;
        }

        public static StaticSprite SuperLuigiPunchingRightBFactory(Game game)
        {
            StaticSprite superLuigiPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                NeedFlip = true
            };
            superLuigiPunchingRight.FrameSize = new Point(superLuigiPunchingRight.Texture.Width / superLuigiPunchingRight.SheetSize.X, superLuigiPunchingRight.Texture.Height / superLuigiPunchingRight.SheetSize.Y);

            return superLuigiPunchingRight;
        }

        public static AnimatedSprite SuperLuigiRunningLeftFactory(Game game)
        {
            AnimatedSprite superLuigiRunningLeft = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            superLuigiRunningLeft.FrameSize = new Point(superLuigiRunningLeft.Texture.Width / superLuigiRunningLeft.SheetSize.X, superLuigiRunningLeft.Texture.Height / superLuigiRunningLeft.SheetSize.Y);

            return superLuigiRunningLeft;
        }

        public static AnimatedSprite SuperLuigiRunningRightFactory(Game game)
        {
            AnimatedSprite superLuigiRunningRight = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            superLuigiRunningRight.FrameSize = new Point(superLuigiRunningRight.Texture.Width / superLuigiRunningRight.SheetSize.X, superLuigiRunningRight.Texture.Height / superLuigiRunningRight.SheetSize.Y);

            return superLuigiRunningRight;
        }

        public static AnimatedSprite SuperLuigiWalkingLeftFactory(Game game)
        {

            AnimatedSprite superLuigiWalkingLeft = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            superLuigiWalkingLeft.FrameSize = new Point(superLuigiWalkingLeft.Texture.Width / superLuigiWalkingLeft.SheetSize.X, superLuigiWalkingLeft.Texture.Height / superLuigiWalkingLeft.SheetSize.Y);

            return superLuigiWalkingLeft;
        }

        public static AnimatedSprite SuperLuigiWalkingRightFactory(Game game)
        {
            AnimatedSprite superLuigiWalkingRight = new LuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            superLuigiWalkingRight.FrameSize = new Point(superLuigiWalkingRight.Texture.Width / superLuigiWalkingRight.SheetSize.X, superLuigiWalkingRight.Texture.Height / superLuigiWalkingRight.SheetSize.Y);

            return superLuigiWalkingRight;
        }

        public static AnimatedSprite SuperLuigiJumpingLeftFactory(Game game)
        {
            AnimatedSprite superLuigiJumpingLeft = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                Top = new Vector2(300, 100 - 40),
                Ground = new Vector2(300, 100),
                NeedFlip = false
            };
            superLuigiJumpingLeft.FrameSize = new Point(superLuigiJumpingLeft.Texture.Width / superLuigiJumpingLeft.SheetSize.X, superLuigiJumpingLeft.Texture.Height / superLuigiJumpingLeft.SheetSize.Y);

           return superLuigiJumpingLeft;
        }

        public static AnimatedSprite SuperLuigiJumpingRightFactory(Game game)
        {
            AnimatedSprite superLuigiJumpingRight = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigi"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                NeedFlip = true,
                Top = new Vector2(350, 100 - 40),
                Ground = new Vector2(350, 100)
            };
            superLuigiJumpingRight.FrameSize = new Point(superLuigiJumpingRight.Texture.Width / superLuigiJumpingRight.SheetSize.X, superLuigiJumpingRight.Texture.Height / superLuigiJumpingRight.SheetSize.Y);

           return superLuigiJumpingRight;
        }

        public static StaticSprite SuperLuigiCrouchLeftFactory(Game game)
        {
            StaticSprite superLuigiCrouchLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigiCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = false
            };
            superLuigiCrouchLeft.FrameSize = new Point(superLuigiCrouchLeft.Texture.Width / superLuigiCrouchLeft.SheetSize.X, superLuigiCrouchLeft.Texture.Height / superLuigiCrouchLeft.SheetSize.Y);

            return superLuigiCrouchLeft;
        }

        public static StaticSprite SuperLuigiCrouchRightFactory(Game game)
        {
            StaticSprite superLuigiCrouchRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigiCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = true
            };
            superLuigiCrouchRight.FrameSize = new Point(superLuigiCrouchRight.Texture.Width / superLuigiCrouchRight.SheetSize.X, superLuigiCrouchRight.Texture.Height / superLuigiCrouchRight.SheetSize.Y);

            return superLuigiCrouchRight;
        }

        #endregion

        #region FireLuigi
        public static StaticSprite FireLuigiFacingLeftFactory(Game game)
        {
            StaticSprite fireLuigiFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(6, 0),
                NeedFlip = false
            };
            fireLuigiFacingLeft.FrameSize = new Point(fireLuigiFacingLeft.Texture.Width / fireLuigiFacingLeft.SheetSize.X, fireLuigiFacingLeft.Texture.Height / fireLuigiFacingLeft.SheetSize.Y);

            return fireLuigiFacingLeft;
        }

        public static StaticSprite FireLuigiFacingRightFactory(Game game)
        {
            StaticSprite fireLuigiFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(6, 0),
                NeedFlip = true
            };
            fireLuigiFacingRight.FrameSize = new Point(fireLuigiFacingRight.Texture.Width / fireLuigiFacingRight.SheetSize.X, fireLuigiFacingRight.Texture.Height / fireLuigiFacingRight.SheetSize.Y);

            return fireLuigiFacingRight;
        }

        public static StaticSprite FireLuigiPunchingLeftFactory(Game game)
        {
            StaticSprite fireLuigiPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(1, 0),
                NeedFlip = true
            };
            fireLuigiPunchingLeft.FrameSize = new Point(fireLuigiPunchingLeft.Texture.Width / fireLuigiPunchingLeft.SheetSize.X, fireLuigiPunchingLeft.Texture.Height / fireLuigiPunchingLeft.SheetSize.Y);

            return fireLuigiPunchingLeft;
        }

        public static StaticSprite FireLuigiPunchingLeftBFactory(Game game)
        {
            StaticSprite fireLuigiPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                NeedFlip = false
            };
            fireLuigiPunchingLeft.FrameSize = new Point(fireLuigiPunchingLeft.Texture.Width / fireLuigiPunchingLeft.SheetSize.X, fireLuigiPunchingLeft.Texture.Height / fireLuigiPunchingLeft.SheetSize.Y);

            return fireLuigiPunchingLeft;
        }

        public static StaticSprite FireLuigiPunchingRightFactory(Game game)
        {
            StaticSprite fireLuigiPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(1, 0),
                NeedFlip = false
            };
            fireLuigiPunchingRight.FrameSize = new Point(fireLuigiPunchingRight.Texture.Width / fireLuigiPunchingRight.SheetSize.X, fireLuigiPunchingRight.Texture.Height / fireLuigiPunchingRight.SheetSize.Y);

            return fireLuigiPunchingRight;
        }

        public static StaticSprite FireLuigiPunchingRightBFactory(Game game)
        {
            StaticSprite fireLuigiPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                NeedFlip = true
            };
            fireLuigiPunchingRight.FrameSize = new Point(fireLuigiPunchingRight.Texture.Width / fireLuigiPunchingRight.SheetSize.X, fireLuigiPunchingRight.Texture.Height / fireLuigiPunchingRight.SheetSize.Y);

            return fireLuigiPunchingRight;
        }

        public static AnimatedSprite FireLuigiRunningLeftFactory(Game game)
        {
            AnimatedSprite fireLuigiRunningLeft = new FireLuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 150,
                NeedFlip = false
            };
            fireLuigiRunningLeft.FrameSize = new Point(fireLuigiRunningLeft.Texture.Width / fireLuigiRunningLeft.SheetSize.X, fireLuigiRunningLeft.Texture.Height / fireLuigiRunningLeft.SheetSize.Y);

            return fireLuigiRunningLeft;
        }

        public static AnimatedSprite FireLuigiRunningRightFactory(Game game)
        {
            AnimatedSprite fireLuigiRunningRight = new FireLuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 150,
                NeedFlip = true
            };
            fireLuigiRunningRight.FrameSize = new Point(fireLuigiRunningRight.Texture.Width / fireLuigiRunningRight.SheetSize.X, fireLuigiRunningRight.Texture.Height / fireLuigiRunningRight.SheetSize.Y);

            return fireLuigiRunningRight;
        }

        public static AnimatedSprite FireLuigiWalkingLeftFactory(Game game)
        {
            AnimatedSprite fireLuigiWalkingLeft = new FireLuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            fireLuigiWalkingLeft.FrameSize = new Point(fireLuigiWalkingLeft.Texture.Width / fireLuigiWalkingLeft.SheetSize.X, fireLuigiWalkingLeft.Texture.Height / fireLuigiWalkingLeft.SheetSize.Y);

            return fireLuigiWalkingLeft;
        }

        public static AnimatedSprite FireLuigiWalkingRightFactory(Game game)
        {
            AnimatedSprite fireLuigiWalkingRight = new FireLuigiRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(5, 0),
                MillisecondsPerFrame = 200,
                NeedFlip = true
            };
            fireLuigiWalkingRight.FrameSize = new Point(fireLuigiWalkingRight.Texture.Width / fireLuigiWalkingRight.SheetSize.X, fireLuigiWalkingRight.Texture.Height / fireLuigiWalkingRight.SheetSize.Y);

            return fireLuigiWalkingRight;
        }

        public static AnimatedSprite  FireLuigiJumpingLeftFactory(Game game)
        {
            AnimatedSprite jumpingLeft = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(0, 0),
                Top = new Vector2(300, 200 - 40),
                Ground = new Vector2(300, 200),
                MillisecondsPerFrame = 10,
                NeedFlip = false
            };
            jumpingLeft.FrameSize = new Point(jumpingLeft.Texture.Width / jumpingLeft.SheetSize.X, jumpingLeft.Texture.Height / jumpingLeft.SheetSize.Y);

            return jumpingLeft;
        }

        public static AnimatedSprite FireLuigiJumpingRightFactory(Game game)
        {
            AnimatedSprite fireLuigiJumpingRight = new LuigiJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                Top = new Vector2(350, 200 - 40),
                Ground = new Vector2(350, 200),
                NeedFlip = true
            };
            fireLuigiJumpingRight.FrameSize = new Point(fireLuigiJumpingRight.Texture.Width / fireLuigiJumpingRight.SheetSize.X, fireLuigiJumpingRight.Texture.Height / fireLuigiJumpingRight.SheetSize.Y);

            return fireLuigiJumpingRight;
        }

        public static StaticSprite FireLuigiCrouchLeftFactory(Game game)
        {
            StaticSprite fireLuigiCrouchLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigiCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = false
            };
            fireLuigiCrouchLeft.FrameSize = new Point(fireLuigiCrouchLeft.Texture.Width / fireLuigiCrouchLeft.SheetSize.X, fireLuigiCrouchLeft.Texture.Height / fireLuigiCrouchLeft.SheetSize.Y);

            return fireLuigiCrouchLeft;
        }

        public static StaticSprite FireLuigiCrouchRightFactory(Game game)
        {
            StaticSprite fireLuigiCrouchRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigiCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = true
            };
            fireLuigiCrouchRight.FrameSize = new Point(fireLuigiCrouchRight.Texture.Width / fireLuigiCrouchRight.SheetSize.X, fireLuigiCrouchRight.Texture.Height / fireLuigiCrouchRight.SheetSize.Y);

            return fireLuigiCrouchRight;
        }

        #endregion

        public static AnimatedSprite ClimbingLuigi(Game game)
        {
            AnimatedSprite climbingLuigi = new ClimbingLuigi
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SmallLuigiClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingLuigi.FrameSize = new Point(13, 16);

            return climbingLuigi;
        }
        public static AnimatedSprite SuperClimbingLuigi(Game game)
        {
            AnimatedSprite climbingLuigi = new ClimbingLuigi
            {
                Texture = game.Content.Load<Texture2D>("Luigi/SuperLuigiClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingLuigi.FrameSize = new Point(14, 30);

            return climbingLuigi;
        }
        public static AnimatedSprite FireClimbingLuigi(Game game)
        {
            AnimatedSprite climbingLuigi = new ClimbingLuigi
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigiClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingLuigi.FrameSize = new Point(14, 30);

            return climbingLuigi;
        }
        public static StaticSprite FireBallThrowingLuigi(Game game)
        {
            StaticSprite Luigi = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/FireLuigi"),
                NeedFlip = false,
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(2, 0)
            };
            Luigi.FrameSize = new Point(18, 32);
            return Luigi;
        }
        #region Changing Luigi
        public static AnimatedSprite GrowingLuigi(Game game)
        {
            AnimatedSprite growingLuigi = new LuigiGrowingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/LuigiGrowing"),
                SheetSize = new Point(3, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            growingLuigi.FrameSize = new Point(18,34);

            return growingLuigi;
        }
        public static AnimatedSprite ShrinkingLuigi(Game game)
        {
            AnimatedSprite growingLuigi = new LuigiShrinkingSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/LuigiGrowing"),
                SheetSize = new Point(3, 1),
                CurrentFrame = new Point(2, 0),
                MillisecondsPerFrame = 150,
            };
            growingLuigi.FrameSize = new Point(18, 34);

            return growingLuigi;
        }
        #endregion

        public static AnimatedSprite BlueKoopaWalking(Game game)
        {
            AnimatedSprite growingLuigi = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("BlueWalkingKoopa"),
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            growingLuigi.FrameSize = new Point(16, 24);

            return growingLuigi;
        }

        public static StaticSprite GreenStandingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("GreenKoopaStanding"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        public static StaticSprite RedStandingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("RedKoopaStanding"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
            };
            return turt;
        }
        public static StaticSprite BlueStandingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("BlueWalkingKoopa"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }

        public static AnimatedSprite BlueJumpingKoopa(Game game)
        {
            AnimatedSprite turt = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("BlueJumpingKoopa"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
                SheetSize = new Point(2, 1),
                MillisecondsPerFrame = 200
            };
            return turt;
        }
        public static AnimatedSprite RedJumpingKoopa(Game game)
        {
            AnimatedSprite turt = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("RedJumpingKoopa"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
                SheetSize = new Point(2, 1),
                MillisecondsPerFrame = 200
            };
            return turt;
        }
        public static AnimatedSprite GreenJumpingKoopa(Game game)
        {
            AnimatedSprite turt = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("GreenJumpingKoopa"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
                AnimationFrame = 0,
                SheetSize = new Point(2, 1),
                MillisecondsPerFrame = 200
            };
            return turt;
        }

        public static AnimatedSprite GreenWalkingKoopa(Game game)
        {
            AnimatedSprite turt = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("GreenKoopaWalking"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
                AnimationFrame = 0,
                SheetSize = new Point(2, 1),
                MillisecondsPerFrame = 200
            };
            return turt;
        }
        public static AnimatedSprite RedWalkingKoopa(Game game)
        {
            AnimatedSprite turt = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("RedKoopaWalking"),
                FrameSize = new Point(16, 24),
                CurrentFrame = new Point(0, 0),
                AnimationFrame = 0,
                SheetSize = new Point(2, 1),
                MillisecondsPerFrame = 200
            };
            return turt;

        }
        public static StaticSprite BlueCrouchingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("Luigi/BlueKoopaCrouch"),
                FrameSize = new Point(16, 15),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        public static StaticSprite GreenCrouchingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("GreenKoopaCrouch"),
                FrameSize = new Point(16, 15),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        public static StaticSprite RedCrouchingKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("RedKoopaCrouch"),
                FrameSize = new Point(16, 15),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
       
        public static StaticSprite GreenDeadKoopa(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("GreenDeadKoopa"),
                FrameSize = new Point(16, 15),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        

    }
}
