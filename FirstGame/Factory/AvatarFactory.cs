using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities.Items;
using Sprint0.Game_Enities.Enemies;
using System.IO;
using Sprint0.InputControllers;

namespace FirstGame
{
    static public class AvatarFactory
    {
        #region SmallAvatar

        public static StaticSprite SmallAvatarFacingLeftFactory(Game game, string name)
        {
            StaticSprite smallAvatarFacingLeft = null;
            if (name is "Mario")
            {
                smallAvatarFacingLeft = MarioFactory.SmallMarioFacingLeftFactory(game);
            }
            else
            {
                smallAvatarFacingLeft = LuigiFactory.SmallLuigiFacingLeftFactory(game);
            }
            smallAvatarFacingLeft.FrameSize = new Point(18, 18);

            return smallAvatarFacingLeft;
        }

        public static StaticSprite SmallAvatarFacingRightFactory(Game game, string name)
        {
            StaticSprite smallAvatarFacingRight = null;
            if (name is "Mario")
            {
                smallAvatarFacingRight = MarioFactory.SmallMarioFacingRightFactory(game);
            }
            else
            {
                smallAvatarFacingRight = LuigiFactory.SmallLuigiFacingRightFactory(game);
            }
            smallAvatarFacingRight.FrameSize = new Point(smallAvatarFacingRight.Texture.Width / smallAvatarFacingRight.SheetSize.X, smallAvatarFacingRight.Texture.Height / smallAvatarFacingRight.SheetSize.Y);

            return smallAvatarFacingRight;
        }

        public static AnimatedSprite SmallAvatarRunningLeftFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarRunningLeft = null;
            if (name is "Mario")
            {
                smallAvatarRunningLeft = MarioFactory.SmallMarioRunningLeftFactory(game);
            }
            else
            {
                smallAvatarRunningLeft = LuigiFactory.SmallLuigiRunningLeftFactory(game);
            }
            smallAvatarRunningLeft = MarioFactory.SmallMarioRunningLeftFactory(game);
            smallAvatarRunningLeft.FrameSize = new Point(smallAvatarRunningLeft.Texture.Width / smallAvatarRunningLeft.SheetSize.X, smallAvatarRunningLeft.Texture.Height / smallAvatarRunningLeft.SheetSize.Y);

            return smallAvatarRunningLeft;
        }

        public static AnimatedSprite SmallAvatarRunningRightFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarRunningRight = null;
            if (name is "Mario")
            {
                smallAvatarRunningRight = MarioFactory.SmallMarioRunningRightFactory(game);
            }
            else
            {
                smallAvatarRunningRight = LuigiFactory.SmallLuigiRunningRightFactory(game);
            }
            smallAvatarRunningRight.FrameSize = new Point(smallAvatarRunningRight.Texture.Width / smallAvatarRunningRight.SheetSize.X, smallAvatarRunningRight.Texture.Height / smallAvatarRunningRight.SheetSize.Y);

            return smallAvatarRunningRight;
        }

        public static AnimatedSprite SmallAvatarWalkingLeftFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarWalkingLeft = null;
            if (name is "Mario")
            {
                smallAvatarWalkingLeft = MarioFactory.SmallMarioWalkingLeftFactory(game);
            }
            else
            {
                smallAvatarWalkingLeft = LuigiFactory.SmallLuigiWalkingLeftFactory(game);
            }
            smallAvatarWalkingLeft.FrameSize = new Point(smallAvatarWalkingLeft.Texture.Width / smallAvatarWalkingLeft.SheetSize.X, smallAvatarWalkingLeft.Texture.Height / smallAvatarWalkingLeft.SheetSize.Y);

            return smallAvatarWalkingLeft;
        }

        public static AnimatedSprite SmallAvatarWalkingRightFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarWalkingRight = null;
            if (name is "Mario")
            {
                smallAvatarWalkingRight = MarioFactory.SmallMarioWalkingRightFactory(game);
            }
            else
            {
                smallAvatarWalkingRight = LuigiFactory.SmallLuigiWalkingRightFactory(game);
            }
            smallAvatarWalkingRight.FrameSize = new Point(smallAvatarWalkingRight.Texture.Width / smallAvatarWalkingRight.SheetSize.X, smallAvatarWalkingRight.Texture.Height / smallAvatarWalkingRight.SheetSize.Y);

            return smallAvatarWalkingRight;
        }

        public static AnimatedSprite SmallAvatarJumpingLeftFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarJumpingLeft = null;
            if (name is "Mario")
            {
                smallAvatarJumpingLeft = MarioFactory.SmallMarioJumpingLeftFactory(game);
            }
            else
            {
                smallAvatarJumpingLeft = LuigiFactory.SmallLuigiJumpingLeftFactory(game);
            }
            smallAvatarJumpingLeft.FrameSize = new Point(smallAvatarJumpingLeft.Texture.Width / smallAvatarJumpingLeft.SheetSize.X, smallAvatarJumpingLeft.Texture.Height / smallAvatarJumpingLeft.SheetSize.Y);

            return smallAvatarJumpingLeft;
        }

        public static AnimatedSprite SmallAvatarJumpingRightFactory(Game game, string name)
        {
            AnimatedSprite smallAvatarJumpingRight = null;
            if (name is "Mario")
            {
                smallAvatarJumpingRight = MarioFactory.SmallMarioJumpingRightFactory(game);
            }
            else
            {
                smallAvatarJumpingRight = LuigiFactory.SmallLuigiJumpingRightFactory(game);
            }
            smallAvatarJumpingRight.FrameSize = new Point(smallAvatarJumpingRight.Texture.Width / smallAvatarJumpingRight.SheetSize.X, smallAvatarJumpingRight.Texture.Height / smallAvatarJumpingRight.SheetSize.Y);

            return smallAvatarJumpingRight;
        }

        public static AnimatedSprite DeadAvatarFactory(Game game, string name)
        {
            AnimatedSprite deadAvatar = null;
            if (name is "Mario")
            {
                deadAvatar = MarioFactory.DeadMarioFactory(game);
            }
            else
            {
                deadAvatar = LuigiFactory.DeadLuigiFactory(game);
            }
            deadAvatar.FrameSize = new Point(deadAvatar.Texture.Width / deadAvatar.SheetSize.X, deadAvatar.Texture.Height / deadAvatar.SheetSize.Y);

            return deadAvatar;
        }
        #endregion


        #region SuperMario
        public static StaticSprite SuperAvatarFacingLeftFactory(Game game, string name)
        {
            StaticSprite superMarioFacingLeft = null;
            if (name is "Mario")
            {
                superMarioFacingLeft = MarioFactory.SuperMarioFacingLeftFactory(game);
            }
            else
            {
                superMarioFacingLeft = LuigiFactory.SuperLuigiFacingLeftFactory(game);
            }
            superMarioFacingLeft.FrameSize = new Point(superMarioFacingLeft.Texture.Width / superMarioFacingLeft.SheetSize.X, superMarioFacingLeft.Texture.Height / superMarioFacingLeft.SheetSize.Y);

            return superMarioFacingLeft;
        }

        public static StaticSprite SuperAvatarFacingRightFactory(Game game, string name)
        {
            StaticSprite SuperMarioFacingRight = null;
            if (name is "Mario")
            {
                SuperMarioFacingRight = MarioFactory.SuperMarioFacingRightFactory(game);
            }
            else
            {
                SuperMarioFacingRight = LuigiFactory.SuperLuigiFacingRightFactory(game);
            }
            SuperMarioFacingRight.FrameSize = new Point(SuperMarioFacingRight.Texture.Width / SuperMarioFacingRight.SheetSize.X, SuperMarioFacingRight.Texture.Height / SuperMarioFacingRight.SheetSize.Y);

            return SuperMarioFacingRight;
        }

        public static StaticSprite SuperAvatarPunchingLeftFactory(Game game, string name)
        {
            StaticSprite superMarioPunchingLeft = null;
            if (name is "Mario")
            {
                superMarioPunchingLeft = MarioFactory.SuperMarioPunchingLeftFactory(game);
            }
            else
            {
                superMarioPunchingLeft = LuigiFactory.SuperLuigiPunchingLeftFactory(game);
            }
            superMarioPunchingLeft.FrameSize = new Point(superMarioPunchingLeft.Texture.Width / superMarioPunchingLeft.SheetSize.X, superMarioPunchingLeft.Texture.Height / superMarioPunchingLeft.SheetSize.Y);

            return superMarioPunchingLeft;
        }

        public static StaticSprite SuperAvatarPunchingLeftBFactory(Game game, string name)
        {
            StaticSprite superMarioPunchingLeft = null;
            if (name is "Mario")
            {
                superMarioPunchingLeft = MarioFactory.SuperMarioPunchingLeftBFactory(game);
            }
            else
            {
                superMarioPunchingLeft = LuigiFactory.SuperLuigiPunchingLeftBFactory(game);
            }
            superMarioPunchingLeft.FrameSize = new Point(superMarioPunchingLeft.Texture.Width / superMarioPunchingLeft.SheetSize.X, superMarioPunchingLeft.Texture.Height / superMarioPunchingLeft.SheetSize.Y);

            return superMarioPunchingLeft;
        }

        public static StaticSprite SuperAvatarPunchingRightFactory(Game game, string name)
        {
            StaticSprite superMarioPunchingRight = null;
            if (name is "Mario")
            {
                superMarioPunchingRight = MarioFactory.SuperMarioPunchingRightFactory(game);
            }
            else
            {
                superMarioPunchingRight = LuigiFactory.SuperLuigiPunchingRightFactory(game);
            }
            superMarioPunchingRight.FrameSize = new Point(superMarioPunchingRight.Texture.Width / superMarioPunchingRight.SheetSize.X, superMarioPunchingRight.Texture.Height / superMarioPunchingRight.SheetSize.Y);

            return superMarioPunchingRight;
        }

        public static StaticSprite SuperAvatarPunchingRightBFactory(Game game, string name)
        {
            StaticSprite superMarioPunchingRight = null;
            if (name is "Mario")
            {
                superMarioPunchingRight = MarioFactory.SuperMarioPunchingRightBFactory(game);
            }
            else
            {
                superMarioPunchingRight = LuigiFactory.SuperLuigiPunchingRightBFactory(game);
            }
            superMarioPunchingRight.FrameSize = new Point(superMarioPunchingRight.Texture.Width / superMarioPunchingRight.SheetSize.X, superMarioPunchingRight.Texture.Height / superMarioPunchingRight.SheetSize.Y);

            return superMarioPunchingRight;
        }

        public static AnimatedSprite SuperAvatarRunningLeftFactory(Game game, string name)
        {
            AnimatedSprite superMarioRunningLeft = null;
            if (name is "Mario")
            {
                superMarioRunningLeft = MarioFactory.SuperMarioRunningLeftFactory(game);
            }
            else
            {
                superMarioRunningLeft = LuigiFactory.SuperLuigiRunningLeftFactory(game);
            }
            superMarioRunningLeft.FrameSize = new Point(superMarioRunningLeft.Texture.Width / superMarioRunningLeft.SheetSize.X, superMarioRunningLeft.Texture.Height / superMarioRunningLeft.SheetSize.Y);

            return superMarioRunningLeft;
        }

        public static AnimatedSprite SuperAvatarRunningRightFactory(Game game, string name)
        {
            AnimatedSprite superMarioRunningRight = null;
            if (name is "Mario")
            {
                superMarioRunningRight = MarioFactory.SuperMarioRunningRightFactory(game);
            }
            else
            {
                superMarioRunningRight = LuigiFactory.SuperLuigiRunningRightFactory(game);
            }
            superMarioRunningRight.FrameSize = new Point(superMarioRunningRight.Texture.Width / superMarioRunningRight.SheetSize.X, superMarioRunningRight.Texture.Height / superMarioRunningRight.SheetSize.Y);

            return superMarioRunningRight;
        }

        public static AnimatedSprite SuperAvatarWalkingLeftFactory(Game game, string name)
        {
            AnimatedSprite superMarioWalkingLeft = null;
            if (name is "Mario")
            {
                superMarioWalkingLeft = MarioFactory.SuperMarioWalkingLeftFactory(game);
            }
            else
            {
                superMarioWalkingLeft = LuigiFactory.SuperLuigiWalkingLeftFactory(game);
            }
            superMarioWalkingLeft.FrameSize = new Point(superMarioWalkingLeft.Texture.Width / superMarioWalkingLeft.SheetSize.X, superMarioWalkingLeft.Texture.Height / superMarioWalkingLeft.SheetSize.Y);

            return superMarioWalkingLeft;
        }

        public static AnimatedSprite SuperAvatarWalkingRightFactory(Game game, string name)
        {
            AnimatedSprite superMarioWalkingRight = null;
            if (name is "Mario")
            {
                superMarioWalkingRight = MarioFactory.SuperMarioWalkingRightFactory(game);
            }
            else
            {
                superMarioWalkingRight = LuigiFactory.SuperLuigiWalkingRightFactory(game);
            }
            superMarioWalkingRight.FrameSize = new Point(superMarioWalkingRight.Texture.Width / superMarioWalkingRight.SheetSize.X, superMarioWalkingRight.Texture.Height / superMarioWalkingRight.SheetSize.Y);

            return superMarioWalkingRight;
        }

        public static AnimatedSprite SuperAvatarJumpingLeftFactory(Game game, string name)
        {
            AnimatedSprite superMarioJumpingLeft = null;
            if (name is "Mario")
            {
                superMarioJumpingLeft = MarioFactory.SuperMarioJumpingLeftFactory(game);
            }
            else
            {
                superMarioJumpingLeft = LuigiFactory.SuperLuigiJumpingLeftFactory(game);
            }
            superMarioJumpingLeft.FrameSize = new Point(superMarioJumpingLeft.Texture.Width / superMarioJumpingLeft.SheetSize.X, superMarioJumpingLeft.Texture.Height / superMarioJumpingLeft.SheetSize.Y);

            return superMarioJumpingLeft;
        }

        public static AnimatedSprite SuperAvatarJumpingRightFactory(Game game, string name)
        {
            AnimatedSprite superMarioJumpingRight = null;
            if (name is "Mario")
            {
                superMarioJumpingRight = MarioFactory.SuperMarioJumpingRightFactory(game);
            }
            else
            {
                superMarioJumpingRight = LuigiFactory.SuperLuigiJumpingRightFactory(game);
            }
            superMarioJumpingRight.FrameSize = new Point(superMarioJumpingRight.Texture.Width / superMarioJumpingRight.SheetSize.X, superMarioJumpingRight.Texture.Height / superMarioJumpingRight.SheetSize.Y);

            return superMarioJumpingRight;
        }

        public static StaticSprite SuperAvatarCrouchLeftFactory(Game game, string name)
        {
            StaticSprite superMarioCrouchLeft = null;
            if (name is "Mario")
            {
                superMarioCrouchLeft = MarioFactory.SuperMarioCrouchLeftFactory(game);
            }
            else
            {
                superMarioCrouchLeft = LuigiFactory.SuperLuigiCrouchLeftFactory(game);
            }
            superMarioCrouchLeft.FrameSize = new Point(superMarioCrouchLeft.Texture.Width / superMarioCrouchLeft.SheetSize.X, superMarioCrouchLeft.Texture.Height / superMarioCrouchLeft.SheetSize.Y);

            return superMarioCrouchLeft;
        }

        public static StaticSprite SuperAvatarCrouchRightFactory(Game game, string name)
        {
            StaticSprite superMarioCrouchRight = null;
            if (name is "Mario")
            {
                superMarioCrouchRight = MarioFactory.SuperMarioCrouchRightFactory(game);
            }
            else
            {
                superMarioCrouchRight = LuigiFactory.SuperLuigiCrouchRightFactory(game);
            }
            superMarioCrouchRight.FrameSize = new Point(superMarioCrouchRight.Texture.Width / superMarioCrouchRight.SheetSize.X, superMarioCrouchRight.Texture.Height / superMarioCrouchRight.SheetSize.Y);

            return superMarioCrouchRight;
        }

        #endregion

        #region FireMario
        public static StaticSprite FireAvatarFacingLeftFactory(Game game, string name)
        {
            StaticSprite fireMarioFacingLeft = null;
            if (name is "Mario")
            {
                fireMarioFacingLeft = MarioFactory.FireMarioFacingLeftFactory(game);
            }
            else
            {
                fireMarioFacingLeft = LuigiFactory.FireLuigiFacingLeftFactory(game);
            }
            fireMarioFacingLeft.FrameSize = new Point(fireMarioFacingLeft.Texture.Width / fireMarioFacingLeft.SheetSize.X, fireMarioFacingLeft.Texture.Height / fireMarioFacingLeft.SheetSize.Y);

            return fireMarioFacingLeft;
        }

        public static StaticSprite FireAvatarFacingRightFactory(Game game, string name)
        {
            StaticSprite fireMarioFacingRight = null;
            if (name is "Mario")
            {
                fireMarioFacingRight = MarioFactory.FireMarioFacingRightFactory(game);
            }
            else
            {
                fireMarioFacingRight = LuigiFactory.FireLuigiFacingRightFactory(game);
            }
            fireMarioFacingRight.FrameSize = new Point(fireMarioFacingRight.Texture.Width / fireMarioFacingRight.SheetSize.X, fireMarioFacingRight.Texture.Height / fireMarioFacingRight.SheetSize.Y);

            return fireMarioFacingRight;
        }

        public static StaticSprite FireAvatarPunchingLeftFactory(Game game, string name)
        {
            StaticSprite fireMarioPunchingLeft = null;
            if (name is "Mario")
            {
                fireMarioPunchingLeft = MarioFactory.FireMarioPunchingLeftFactory(game);
            }
            else
            {
                fireMarioPunchingLeft = LuigiFactory.FireLuigiPunchingLeftFactory(game);
            }
            fireMarioPunchingLeft.FrameSize = new Point(fireMarioPunchingLeft.Texture.Width / fireMarioPunchingLeft.SheetSize.X, fireMarioPunchingLeft.Texture.Height / fireMarioPunchingLeft.SheetSize.Y);

            return fireMarioPunchingLeft;
        }

        public static StaticSprite FireAvatarPunchingLeftBFactory(Game game, string name)
        {
            StaticSprite fireMarioPunchingLeft = null;
            if (name is "Mario")
            {
                fireMarioPunchingLeft = MarioFactory.FireMarioPunchingLeftBFactory(game);
            }
            else
            {
                fireMarioPunchingLeft = LuigiFactory.FireLuigiPunchingLeftBFactory(game);
            }
            fireMarioPunchingLeft.FrameSize = new Point(fireMarioPunchingLeft.Texture.Width / fireMarioPunchingLeft.SheetSize.X, fireMarioPunchingLeft.Texture.Height / fireMarioPunchingLeft.SheetSize.Y);

            return fireMarioPunchingLeft;
        }

        public static StaticSprite FireAvatarPunchingRightFactory(Game game, string name)
        {
            StaticSprite fireMarioPunchingRight = null;
            if (name is "Mario")
            {
                fireMarioPunchingRight = MarioFactory.FireMarioPunchingRightFactory(game);
            }
            else
            {
                fireMarioPunchingRight = LuigiFactory.FireLuigiPunchingRightFactory(game);
            }
            fireMarioPunchingRight.FrameSize = new Point(fireMarioPunchingRight.Texture.Width / fireMarioPunchingRight.SheetSize.X, fireMarioPunchingRight.Texture.Height / fireMarioPunchingRight.SheetSize.Y);

            return fireMarioPunchingRight;
        }

        public static StaticSprite FireAvatarPunchingRightBFactory(Game game, string name)
        {
            StaticSprite fireMarioPunchingRight = null;
            if (name is "Mario")
            {
                fireMarioPunchingRight = MarioFactory.FireMarioPunchingRightBFactory(game);
            }
            else
            {
                fireMarioPunchingRight = LuigiFactory.FireLuigiPunchingRightBFactory(game);
            }
            fireMarioPunchingRight.FrameSize = new Point(fireMarioPunchingRight.Texture.Width / fireMarioPunchingRight.SheetSize.X, fireMarioPunchingRight.Texture.Height / fireMarioPunchingRight.SheetSize.Y);

            return fireMarioPunchingRight;
        }

        public static AnimatedSprite FireAvatarRunningLeftFactory(Game game, string name)
        {
            AnimatedSprite fireMarioRunningLeft = null;
            if (name is "Mario")
            {
                fireMarioRunningLeft = MarioFactory.FireMarioRunningLeftFactory(game);
            }
            else
            {
                fireMarioRunningLeft = LuigiFactory.FireLuigiRunningLeftFactory(game);
            }
            fireMarioRunningLeft.FrameSize = new Point(fireMarioRunningLeft.Texture.Width / fireMarioRunningLeft.SheetSize.X, fireMarioRunningLeft.Texture.Height / fireMarioRunningLeft.SheetSize.Y);

            return fireMarioRunningLeft;
        }

        public static AnimatedSprite FireAvatarRunningRightFactory(Game game, string name)
        {
            AnimatedSprite fireMarioRunningRight = null;
            if (name is "Mario")
            {
                fireMarioRunningRight = MarioFactory.FireMarioRunningRightFactory(game);
            }
            else
            {
                fireMarioRunningRight = LuigiFactory.FireLuigiRunningRightFactory(game);
            }
            fireMarioRunningRight.FrameSize = new Point(fireMarioRunningRight.Texture.Width / fireMarioRunningRight.SheetSize.X, fireMarioRunningRight.Texture.Height / fireMarioRunningRight.SheetSize.Y);

            return fireMarioRunningRight;
        }

        public static AnimatedSprite FireAvatarWalkingLeftFactory(Game game, string name)
        {
            AnimatedSprite fireMarioWalkingLeft = null;
            if (name is "Mario")
            {
                fireMarioWalkingLeft = MarioFactory.FireMarioWalkingLeftFactory(game);
            }
            else
            {
                fireMarioWalkingLeft = LuigiFactory.FireLuigiWalkingLeftFactory(game);
            }
            fireMarioWalkingLeft.FrameSize = new Point(fireMarioWalkingLeft.Texture.Width / fireMarioWalkingLeft.SheetSize.X, fireMarioWalkingLeft.Texture.Height / fireMarioWalkingLeft.SheetSize.Y);

            return fireMarioWalkingLeft;
        }

        public static AnimatedSprite FireAvatarWalkingRightFactory(Game game, string name)
        {
            AnimatedSprite fireMarioWalkingRight = null;
            if (name is "Mario")
            {
                fireMarioWalkingRight = MarioFactory.FireMarioWalkingRightFactory(game);
            }
            else
            {
                fireMarioWalkingRight = LuigiFactory.FireLuigiWalkingRightFactory(game);
            }
            fireMarioWalkingRight.FrameSize = new Point(fireMarioWalkingRight.Texture.Width / fireMarioWalkingRight.SheetSize.X, fireMarioWalkingRight.Texture.Height / fireMarioWalkingRight.SheetSize.Y);

            return fireMarioWalkingRight;
        }

        public static AnimatedSprite FireAvatarJumpingLeftFactory(Game game, string name)
        {
            AnimatedSprite jumpingLeft = null;
            if (name is "Mario")
            {
                jumpingLeft = MarioFactory.FireMarioJumpingLeftFactory(game);
            }
            else
            {
                jumpingLeft = LuigiFactory.FireLuigiJumpingLeftFactory(game);
            }
            jumpingLeft.FrameSize = new Point(jumpingLeft.Texture.Width / jumpingLeft.SheetSize.X, jumpingLeft.Texture.Height / jumpingLeft.SheetSize.Y);

            return jumpingLeft;
        }

        public static AnimatedSprite FireAvatarJumpingRightFactory(Game game, string name)
        {
            AnimatedSprite fireMarioJumpingRight = null;
            if (name is "Mario")
            {
                fireMarioJumpingRight = MarioFactory.FireMarioJumpingRightFactory(game);
            }
            else
            {
                fireMarioJumpingRight = LuigiFactory.FireLuigiJumpingRightFactory(game);
            }
            fireMarioJumpingRight.FrameSize = new Point(fireMarioJumpingRight.Texture.Width / fireMarioJumpingRight.SheetSize.X, fireMarioJumpingRight.Texture.Height / fireMarioJumpingRight.SheetSize.Y);

            return fireMarioJumpingRight;
        }

        public static StaticSprite FireAvatarCrouchLeftFactory(Game game, string name)
        {
            StaticSprite fireMarioCrouchLeft = null;
            if (name is "Mario")
            {
                fireMarioCrouchLeft = MarioFactory.FireMarioCrouchLeftFactory(game);
            }
            else
            {
                fireMarioCrouchLeft = LuigiFactory.FireLuigiCrouchLeftFactory(game);
            }
            fireMarioCrouchLeft.FrameSize = new Point(fireMarioCrouchLeft.Texture.Width / fireMarioCrouchLeft.SheetSize.X, fireMarioCrouchLeft.Texture.Height / fireMarioCrouchLeft.SheetSize.Y);

            return fireMarioCrouchLeft;
        }

        public static StaticSprite FireAvatarCrouchRightFactory(Game game, string name)
        {
            StaticSprite fireMarioCrouchRight = null;
            if (name is "Mario")
            {
                fireMarioCrouchRight = MarioFactory.FireMarioCrouchRightFactory(game);
            }
            else
            {
                fireMarioCrouchRight = LuigiFactory.FireLuigiCrouchRightFactory(game);
            }
            fireMarioCrouchRight.FrameSize = new Point(fireMarioCrouchRight.Texture.Width / fireMarioCrouchRight.SheetSize.X, fireMarioCrouchRight.Texture.Height / fireMarioCrouchRight.SheetSize.Y);

            return fireMarioCrouchRight;
        }

        #endregion

        public static AnimatedSprite ClimbingAvatar(Game game, string name)
        {
            AnimatedSprite climbingAvatar = null;
            if (name is "Mario")
            {
                climbingAvatar = MarioFactory.ClimbingMario(game);
            }
            else
            {
                climbingAvatar = LuigiFactory.ClimbingLuigi(game);
            }
            climbingAvatar.FrameSize = new Point(13, 16);

            return climbingAvatar;
        }
        public static AnimatedSprite SuperClimbingAvatar(Game game, string name)
        {
            AnimatedSprite climbingAvatar = null;
            if (name is "Mario")
            {
                climbingAvatar = MarioFactory.SuperClimbingMario(game);
            }
            else
            {
                climbingAvatar = LuigiFactory.SuperClimbingLuigi(game);
            }
            climbingAvatar.FrameSize = new Point(14, 30);

            return climbingAvatar;
        }
        public static AnimatedSprite FireClimbingAvatar(Game game, string name)
        {
            AnimatedSprite climbingAvatar = null;
            if (name is "Mario")
            {
                climbingAvatar = MarioFactory.FireClimbingMario(game);
            }
            else
            {
                climbingAvatar = LuigiFactory.FireClimbingLuigi(game);
            }
            climbingAvatar.FrameSize = new Point(14, 30);

            return climbingAvatar;
        }
        public static StaticSprite FireBallThrowingAvatar(Game game, string name)
        {
            StaticSprite Avatar = null;
            if (name is "Mario")
            {
                Avatar = MarioFactory.FireBallThrowingMario(game);
            }
            else
            {
                Avatar = LuigiFactory.FireBallThrowingLuigi(game);
            }
            Avatar.FrameSize = new Point(18, 32);
            return Avatar;
        }
        #region Changing Mario
        public static AnimatedSprite GrowingAvatar(Game game, string name)
        {
            AnimatedSprite growingAvatar = null;
            if (name is "Mario")
            {
                growingAvatar = MarioFactory.GrowingMario(game);
            }
            else
            {
                growingAvatar = LuigiFactory.GrowingLuigi(game);
            }
            growingAvatar.FrameSize = new Point(18, 34);

            return growingAvatar;
        }
        public static AnimatedSprite ShrinkingAvatar(Game game, string name)
        {
            AnimatedSprite growingAvatar = null;
            if (name is "Mario")
            {
                growingAvatar = MarioFactory.ShrinkingMario(game);
            }
            else
            {
                growingAvatar = LuigiFactory.ShrinkingLuigi(game);
            }
            growingAvatar.FrameSize = new Point(18, 34);

            return growingAvatar;
        }
        #endregion

        public static AnimatedSprite BlueKoopaWalking(Game game)
        {
            AnimatedSprite growingMario = MarioFactory.BlueKoopaWalking(game);
            growingMario.FrameSize = new Point(16, 24);

            return growingMario;
        }

        public static StaticSprite GreenStandingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.GreenStandingKoopa(game);
            return turt;
        }
        public static StaticSprite RedStandingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.RedStandingKoopa(game);
            return turt;
        }
        public static StaticSprite BlueStandingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.BlueStandingKoopa(game);
            return turt;
        }

        public static AnimatedSprite BlueJumpingKoopa(Game game)
        {
            AnimatedSprite turt = MarioFactory.BlueJumpingKoopa(game);
            return turt;
        }
        public static AnimatedSprite RedJumpingKoopa(Game game)
        {
            AnimatedSprite turt = MarioFactory.RedJumpingKoopa(game);
            return turt;
        }
        public static AnimatedSprite GreenJumpingKoopa(Game game)
        {
            AnimatedSprite turt = MarioFactory.GreenJumpingKoopa(game);
            return turt;
        }

        public static AnimatedSprite GreenWalkingKoopa(Game game)
        {
            AnimatedSprite turt = MarioFactory.GreenWalkingKoopa(game);
            return turt;
        }
        public static AnimatedSprite RedWalkingKoopa(Game game)
        {
            AnimatedSprite turt = MarioFactory.RedWalkingKoopa(game);
            return turt;

        }
        public static StaticSprite BlueCrouchingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.BlueCrouchingKoopa(game);
            return turt;
        }
        public static StaticSprite GreenCrouchingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.GreenCrouchingKoopa(game);
            return turt;
        }
        public static StaticSprite RedCrouchingKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.RedCrouchingKoopa(game);
            return turt;
        }

        public static StaticSprite GreenDeadKoopa(Game game)
        {
            StaticSprite turt = MarioFactory.GreenDeadKoopa(game);
            return turt;
        }
        public static StaticSprite BlueKoopaShell(Game game)
        {
            StaticSprite turt = MarioFactory.BlueKoopaShell(game);
            return turt;
        }
        public static StaticSprite GreenKoopaShell(Game game)
        {
            StaticSprite turt = MarioFactory.GreenKoopaShell(game);
            return turt;
        }
        public static StaticSprite RedKoopaShell(Game game)
        {
            StaticSprite turt = MarioFactory.RedKoopaShell(game);
            return turt;
        }
    }
}
