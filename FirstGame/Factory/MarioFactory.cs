using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    static public class MarioFactory
    {


        #region SmallMario

        public static StaticSprite SmallMarioFacingLeftFactory(Game game)
        {
            StaticSprite smallMarioFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = false
            };
            smallMarioFacingLeft.FrameSize = new Point(18, 18);

            return smallMarioFacingLeft;
        }

        public static StaticSprite SmallMarioFacingRightFactory(Game game)
        {
            StaticSprite smallMarioFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = true
            };
            smallMarioFacingRight.FrameSize = new Point(smallMarioFacingRight.Texture.Width / smallMarioFacingRight.SheetSize.X, smallMarioFacingRight.Texture.Height / smallMarioFacingRight.SheetSize.Y);

            return smallMarioFacingRight;
        }

        public static AnimatedSprite SmallMarioRunningLeftFactory(Game game)
        {
            AnimatedSprite smallMarioRunningLeft = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            smallMarioRunningLeft.FrameSize = new Point(smallMarioRunningLeft.Texture.Width / smallMarioRunningLeft.SheetSize.X, smallMarioRunningLeft.Texture.Height / smallMarioRunningLeft.SheetSize.Y);

            return smallMarioRunningLeft;
        }

        public static AnimatedSprite SmallMarioRunningRightFactory(Game game)
        {
            AnimatedSprite smallMarioRunningRight = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            smallMarioRunningRight.FrameSize = new Point(smallMarioRunningRight.Texture.Width / smallMarioRunningRight.SheetSize.X, smallMarioRunningRight.Texture.Height / smallMarioRunningRight.SheetSize.Y);

            return smallMarioRunningRight;
        }

        public static AnimatedSprite SmallMarioWalkingLeftFactory(Game game)
        {
            AnimatedSprite smallMarioWalkingLeft = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            smallMarioWalkingLeft.FrameSize = new Point(smallMarioWalkingLeft.Texture.Width / smallMarioWalkingLeft.SheetSize.X, smallMarioWalkingLeft.Texture.Height / smallMarioWalkingLeft.SheetSize.Y);

            return smallMarioWalkingLeft;
        }

        public static AnimatedSprite SmallMarioWalkingRightFactory(Game game)
        {
            AnimatedSprite smallMarioWalkingRight = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            smallMarioWalkingRight.FrameSize = new Point(smallMarioWalkingRight.Texture.Width / smallMarioWalkingRight.SheetSize.X, smallMarioWalkingRight.Texture.Height / smallMarioWalkingRight.SheetSize.Y);
 
            return smallMarioWalkingRight;
        }

        public static AnimatedSprite SmallMarioJumpingLeftFactory(Game game)
        {
            AnimatedSprite smallMarioJumpingLeft = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                Top = new Vector2(300, 50 - 40),
                Ground = new Vector2(300, 50),
                MillisecondsPerFrame = 10,
                NeedFlip = false
            };
            smallMarioJumpingLeft.FrameSize = new Point(smallMarioJumpingLeft.Texture.Width / smallMarioJumpingLeft.SheetSize.X, smallMarioJumpingLeft.Texture.Height / smallMarioJumpingLeft.SheetSize.Y);

            return smallMarioJumpingLeft;
        }

        public static AnimatedSprite SmallMarioJumpingRightFactory(Game game)
        {
            AnimatedSprite smallMarioJumpingRight = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("SmallMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                NeedFlip = true,
                Top = new Vector2(350, 50 - 40),
                Ground = new Vector2(350, 50)
            };
            smallMarioJumpingRight.FrameSize = new Point(smallMarioJumpingRight.Texture.Width / smallMarioJumpingRight.SheetSize.X, smallMarioJumpingRight.Texture.Height / smallMarioJumpingRight.SheetSize.Y);

            return smallMarioJumpingRight;
        }

        public static AnimatedSprite DeadMarioFactory(Game game)
        {
            AnimatedSprite deadMario = new DeadMario
            {
                Texture = game.Content.Load<Texture2D>("DeadMario"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                Top = new Vector2(400, 50),
                Ground = new Vector2(400, game.GraphicsDevice.Viewport.Height)
            };
            deadMario.FrameSize = new Point(deadMario.Texture.Width / deadMario.SheetSize.X, deadMario.Texture.Height / deadMario.SheetSize.Y);

            return deadMario;
        }
        #endregion

        #region SuperMario
        public static StaticSprite SuperMarioFacingLeftFactory(Game game)
        {
            StaticSprite superMarioFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = false
            };
            superMarioFacingLeft.FrameSize = new Point(superMarioFacingLeft.Texture.Width / superMarioFacingLeft.SheetSize.X, superMarioFacingLeft.Texture.Height / superMarioFacingLeft.SheetSize.Y);

            return superMarioFacingLeft;
        }

        public static StaticSprite SuperMarioFacingRightFactory(Game game)
        {
            StaticSprite SuperMarioFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(5, 0),
                NeedFlip = true
            };
            SuperMarioFacingRight.FrameSize = new Point(SuperMarioFacingRight.Texture.Width / SuperMarioFacingRight.SheetSize.X, SuperMarioFacingRight.Texture.Height / SuperMarioFacingRight.SheetSize.Y);

            return SuperMarioFacingRight;
        }

        public static StaticSprite SuperMarioPunchingLeftFactory(Game game)
        {
            StaticSprite superMarioPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(10, 0),
                NeedFlip = false
            };
            superMarioPunchingLeft.FrameSize = new Point(superMarioPunchingLeft.Texture.Width / superMarioPunchingLeft.SheetSize.X, superMarioPunchingLeft.Texture.Height / superMarioPunchingLeft.SheetSize.Y);

            return superMarioPunchingLeft;
        }

        public static StaticSprite SuperMarioPunchingLeftBFactory(Game game)
        {
            StaticSprite superMarioPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                NeedFlip = false
            };
            superMarioPunchingLeft.FrameSize = new Point(superMarioPunchingLeft.Texture.Width / superMarioPunchingLeft.SheetSize.X, superMarioPunchingLeft.Texture.Height / superMarioPunchingLeft.SheetSize.Y);

            return superMarioPunchingLeft;
        }

        public static StaticSprite SuperMarioPunchingRightFactory(Game game)
        {
            StaticSprite superMarioPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(10, 0),
                NeedFlip = true
            };
            superMarioPunchingRight.FrameSize = new Point(superMarioPunchingRight.Texture.Width / superMarioPunchingRight.SheetSize.X, superMarioPunchingRight.Texture.Height / superMarioPunchingRight.SheetSize.Y);

            return superMarioPunchingRight;
        }

        public static StaticSprite SuperMarioPunchingRightBFactory(Game game)
        {
            StaticSprite superMarioPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(2, 0),
                NeedFlip = true
            };
            superMarioPunchingRight.FrameSize = new Point(superMarioPunchingRight.Texture.Width / superMarioPunchingRight.SheetSize.X, superMarioPunchingRight.Texture.Height / superMarioPunchingRight.SheetSize.Y);

            return superMarioPunchingRight;
        }

        public static AnimatedSprite SuperMarioRunningLeftFactory(Game game)
        {
            AnimatedSprite superMarioRunningLeft = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            superMarioRunningLeft.FrameSize = new Point(superMarioRunningLeft.Texture.Width / superMarioRunningLeft.SheetSize.X, superMarioRunningLeft.Texture.Height / superMarioRunningLeft.SheetSize.Y);

            return superMarioRunningLeft;
        }

        public static AnimatedSprite SuperMarioRunningRightFactory(Game game)
        {
            AnimatedSprite superMarioRunningRight = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            superMarioRunningRight.FrameSize = new Point(superMarioRunningRight.Texture.Width / superMarioRunningRight.SheetSize.X, superMarioRunningRight.Texture.Height / superMarioRunningRight.SheetSize.Y);

            return superMarioRunningRight;
        }

        public static AnimatedSprite SuperMarioWalkingLeftFactory(Game game)
        {

            AnimatedSprite superMarioWalkingLeft = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = false
            };
            superMarioWalkingLeft.FrameSize = new Point(superMarioWalkingLeft.Texture.Width / superMarioWalkingLeft.SheetSize.X, superMarioWalkingLeft.Texture.Height / superMarioWalkingLeft.SheetSize.Y);

            return superMarioWalkingLeft;
        }

        public static AnimatedSprite SuperMarioWalkingRightFactory(Game game)
        {
            AnimatedSprite superMarioWalkingRight = new MarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 100,
                NeedFlip = true
            };
            superMarioWalkingRight.FrameSize = new Point(superMarioWalkingRight.Texture.Width / superMarioWalkingRight.SheetSize.X, superMarioWalkingRight.Texture.Height / superMarioWalkingRight.SheetSize.Y);

            return superMarioWalkingRight;
        }

        public static AnimatedSprite SuperMarioJumpingLeftFactory(Game game)
        {
            AnimatedSprite superMarioJumpingLeft = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                Top = new Vector2(300, 100 - 40),
                Ground = new Vector2(300, 100),
                NeedFlip = false
            };
            superMarioJumpingLeft.FrameSize = new Point(superMarioJumpingLeft.Texture.Width / superMarioJumpingLeft.SheetSize.X, superMarioJumpingLeft.Texture.Height / superMarioJumpingLeft.SheetSize.Y);

           return superMarioJumpingLeft;
        }

        public static AnimatedSprite SuperMarioJumpingRightFactory(Game game)
        {
            AnimatedSprite superMarioJumpingRight = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMario"),
                SheetSize = new Point(12, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                NeedFlip = true,
                Top = new Vector2(350, 100 - 40),
                Ground = new Vector2(350, 100)
            };
            superMarioJumpingRight.FrameSize = new Point(superMarioJumpingRight.Texture.Width / superMarioJumpingRight.SheetSize.X, superMarioJumpingRight.Texture.Height / superMarioJumpingRight.SheetSize.Y);

           return superMarioJumpingRight;
        }

        public static StaticSprite SuperMarioCrouchLeftFactory(Game game)
        {
            StaticSprite superMarioCrouchLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMarioCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = false
            };
            superMarioCrouchLeft.FrameSize = new Point(superMarioCrouchLeft.Texture.Width / superMarioCrouchLeft.SheetSize.X, superMarioCrouchLeft.Texture.Height / superMarioCrouchLeft.SheetSize.Y);

            return superMarioCrouchLeft;
        }

        public static StaticSprite SuperMarioCrouchRightFactory(Game game)
        {
            StaticSprite superMarioCrouchRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("SuperMarioCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = true
            };
            superMarioCrouchRight.FrameSize = new Point(superMarioCrouchRight.Texture.Width / superMarioCrouchRight.SheetSize.X, superMarioCrouchRight.Texture.Height / superMarioCrouchRight.SheetSize.Y);

            return superMarioCrouchRight;
        }

        #endregion

        #region FireMario
        public static StaticSprite FireMarioFacingLeftFactory(Game game)
        {
            StaticSprite fireMarioFacingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(6, 0),
                NeedFlip = false
            };
            fireMarioFacingLeft.FrameSize = new Point(fireMarioFacingLeft.Texture.Width / fireMarioFacingLeft.SheetSize.X, fireMarioFacingLeft.Texture.Height / fireMarioFacingLeft.SheetSize.Y);

            return fireMarioFacingLeft;
        }

        public static StaticSprite FireMarioFacingRightFactory(Game game)
        {
            StaticSprite fireMarioFacingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(6, 0),
                NeedFlip = true
            };
            fireMarioFacingRight.FrameSize = new Point(fireMarioFacingRight.Texture.Width / fireMarioFacingRight.SheetSize.X, fireMarioFacingRight.Texture.Height / fireMarioFacingRight.SheetSize.Y);

            return fireMarioFacingRight;
        }

        public static StaticSprite FireMarioPunchingLeftFactory(Game game)
        {
            StaticSprite fireMarioPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(1, 0),
                NeedFlip = true
            };
            fireMarioPunchingLeft.FrameSize = new Point(fireMarioPunchingLeft.Texture.Width / fireMarioPunchingLeft.SheetSize.X, fireMarioPunchingLeft.Texture.Height / fireMarioPunchingLeft.SheetSize.Y);

            return fireMarioPunchingLeft;
        }

        public static StaticSprite FireMarioPunchingLeftBFactory(Game game)
        {
            StaticSprite fireMarioPunchingLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                NeedFlip = false
            };
            fireMarioPunchingLeft.FrameSize = new Point(fireMarioPunchingLeft.Texture.Width / fireMarioPunchingLeft.SheetSize.X, fireMarioPunchingLeft.Texture.Height / fireMarioPunchingLeft.SheetSize.Y);

            return fireMarioPunchingLeft;
        }

        public static StaticSprite FireMarioPunchingRightFactory(Game game)
        {
            StaticSprite fireMarioPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(1, 0),
                NeedFlip = false
            };
            fireMarioPunchingRight.FrameSize = new Point(fireMarioPunchingRight.Texture.Width / fireMarioPunchingRight.SheetSize.X, fireMarioPunchingRight.Texture.Height / fireMarioPunchingRight.SheetSize.Y);

            return fireMarioPunchingRight;
        }

        public static StaticSprite FireMarioPunchingRightBFactory(Game game)
        {
            StaticSprite fireMarioPunchingRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                NeedFlip = true
            };
            fireMarioPunchingRight.FrameSize = new Point(fireMarioPunchingRight.Texture.Width / fireMarioPunchingRight.SheetSize.X, fireMarioPunchingRight.Texture.Height / fireMarioPunchingRight.SheetSize.Y);

            return fireMarioPunchingRight;
        }

        public static AnimatedSprite FireMarioRunningLeftFactory(Game game)
        {
            AnimatedSprite fireMarioRunningLeft = new FireMarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 150,
                NeedFlip = false
            };
            fireMarioRunningLeft.FrameSize = new Point(fireMarioRunningLeft.Texture.Width / fireMarioRunningLeft.SheetSize.X, fireMarioRunningLeft.Texture.Height / fireMarioRunningLeft.SheetSize.Y);

            return fireMarioRunningLeft;
        }

        public static AnimatedSprite FireMarioRunningRightFactory(Game game)
        {
            AnimatedSprite fireMarioRunningRight = new FireMarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 150,
                NeedFlip = true
            };
            fireMarioRunningRight.FrameSize = new Point(fireMarioRunningRight.Texture.Width / fireMarioRunningRight.SheetSize.X, fireMarioRunningRight.Texture.Height / fireMarioRunningRight.SheetSize.Y);

            return fireMarioRunningRight;
        }

        public static AnimatedSprite FireMarioWalkingLeftFactory(Game game)
        {
            AnimatedSprite fireMarioWalkingLeft = new FireMarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(3, 0),
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            fireMarioWalkingLeft.FrameSize = new Point(fireMarioWalkingLeft.Texture.Width / fireMarioWalkingLeft.SheetSize.X, fireMarioWalkingLeft.Texture.Height / fireMarioWalkingLeft.SheetSize.Y);

            return fireMarioWalkingLeft;
        }

        public static AnimatedSprite FireMarioWalkingRightFactory(Game game)
        {
            AnimatedSprite fireMarioWalkingRight = new FireMarioRunningSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(5, 0),
                MillisecondsPerFrame = 200,
                NeedFlip = true
            };
            fireMarioWalkingRight.FrameSize = new Point(fireMarioWalkingRight.Texture.Width / fireMarioWalkingRight.SheetSize.X, fireMarioWalkingRight.Texture.Height / fireMarioWalkingRight.SheetSize.Y);

            return fireMarioWalkingRight;
        }

        public static AnimatedSprite  FireMarioJumpingLeftFactory(Game game)
        {
            AnimatedSprite jumpingLeft = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
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

        public static AnimatedSprite FireMarioJumpingRightFactory(Game game)
        {
            AnimatedSprite fireMarioJumpingRight = new MarioJumpingSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 10,
                Top = new Vector2(350, 200 - 40),
                Ground = new Vector2(350, 200),
                NeedFlip = true
            };
            fireMarioJumpingRight.FrameSize = new Point(fireMarioJumpingRight.Texture.Width / fireMarioJumpingRight.SheetSize.X, fireMarioJumpingRight.Texture.Height / fireMarioJumpingRight.SheetSize.Y);

            return fireMarioJumpingRight;
        }

        public static StaticSprite FireMarioCrouchLeftFactory(Game game)
        {
            StaticSprite fireMarioCrouchLeft = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMarioCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = false
            };
            fireMarioCrouchLeft.FrameSize = new Point(fireMarioCrouchLeft.Texture.Width / fireMarioCrouchLeft.SheetSize.X, fireMarioCrouchLeft.Texture.Height / fireMarioCrouchLeft.SheetSize.Y);

            return fireMarioCrouchLeft;
        }

        public static StaticSprite FireMarioCrouchRightFactory(Game game)
        {
            StaticSprite fireMarioCrouchRight = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMarioCrouchLeft"),
                SheetSize = new Point(1, 1),
                CurrentFrame = new Point(0, 0),
                NeedFlip = true
            };
            fireMarioCrouchRight.FrameSize = new Point(fireMarioCrouchRight.Texture.Width / fireMarioCrouchRight.SheetSize.X, fireMarioCrouchRight.Texture.Height / fireMarioCrouchRight.SheetSize.Y);

            return fireMarioCrouchRight;
        }

        #endregion

        public static AnimatedSprite ClimbingMario(Game game)
        {
            AnimatedSprite climbingMario = new ClimbingMario
            {
                Texture = game.Content.Load<Texture2D>("SmallMarioClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingMario.FrameSize = new Point(13, 16);

            return climbingMario;
        }
        public static AnimatedSprite SuperClimbingMario(Game game)
        {
            AnimatedSprite climbingMario = new ClimbingMario
            {
                Texture = game.Content.Load<Texture2D>("SuperMarioClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingMario.FrameSize = new Point(14, 30);

            return climbingMario;
        }
        public static AnimatedSprite FireClimbingMario(Game game)
        {
            AnimatedSprite climbingMario = new ClimbingMario
            {
                Texture = game.Content.Load<Texture2D>("FireMarioClimb"),
                NeedFlip = false,
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            climbingMario.FrameSize = new Point(14, 30);

            return climbingMario;
        }
        public static StaticSprite FireBallThrowingMario(Game game)
        {
            StaticSprite mario = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("FireMario"),
                NeedFlip = false,
                SheetSize = new Point(7, 1),
                CurrentFrame = new Point(2, 0)
            };
            mario.FrameSize = new Point(18, 32);
            return mario;
        }
        #region Changing Mario
        public static AnimatedSprite GrowingMario(Game game)
        {
            AnimatedSprite growingMario = new MarioGrowingSprite
            {
                Texture = game.Content.Load<Texture2D>("MarioGrowing"),
                SheetSize = new Point(3, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            growingMario.FrameSize = new Point(18,34);

            return growingMario;
        }
        public static AnimatedSprite ShrinkingMario(Game game)
        {
            AnimatedSprite growingMario = new MarioShrinkingSprite
            {
                Texture = game.Content.Load<Texture2D>("MarioGrowing"),
                SheetSize = new Point(3, 1),
                CurrentFrame = new Point(2, 0),
                MillisecondsPerFrame = 150,
            };
            growingMario.FrameSize = new Point(18, 34);

            return growingMario;
        }
        #endregion

        public static AnimatedSprite BlueKoopaWalking(Game game)
        {
            AnimatedSprite growingMario = new GreenWalkingKoopa
            {
                Texture = game.Content.Load<Texture2D>("BlueWalkingKoopa"),
                SheetSize = new Point(2, 1),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150,
            };
            growingMario.FrameSize = new Point(16, 24);

            return growingMario;
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
                CurrentFrame = new Point(1, 0)
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
                Texture = game.Content.Load<Texture2D>("BlueKoopaCrouch"),
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
        public static StaticSprite BlueKoopaShell(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("BlueKoopaShell"),
                FrameSize = new Point(16, 14),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        public static StaticSprite GreenKoopaShell(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("GreenKoopaShell"),
                FrameSize = new Point(16, 14),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }
        public static StaticSprite RedKoopaShell(Game game)
        {
            StaticSprite turt = new StaticSprite
            {
                Texture = game.Content.Load<Texture2D>("RedKoopaShell"),
                FrameSize = new Point(16, 14),
                CurrentFrame = new Point(0, 0)
            };
            return turt;
        }




    }
}
