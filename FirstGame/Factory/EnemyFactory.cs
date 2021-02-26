using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;

namespace FirstGame
{
    static class EnemyFactory
    {
        
        public static ISprite CreateSprite(Game1 game,string type)
        {
            ISprite enemy;
            switch (type)
            {
                case "NormalGoomba":
                    enemy= MovingNormalGoombaFactory();
                    break;
                case "BlueGoomba":
                    enemy=MovingBlueGoombaFactory();
                    break;
                case "GreyGoomba":
                    enemy=MovingGreyGoombaFactory();
                    break;
                case "NormalFlattened":
                    enemy = FlattenedNormalGoomba();
                    break;
                case "BlueFlattened":
                    enemy = FlattenedBlueGoomba();
                    break;
                case "GreyFlattened":
                    enemy = FlattenedGreyGoomba();
                    break;
                case "GreenKoopa":
                    enemy = MovingGreenKoopaFactory();
                    break;
                case "RedKoopa":
                    enemy = MovingRedKoopaFactory();
                    break;
                case "GreenShell":
                    enemy = GreenKoopaShell();
                    break;
                case "RedShell":
                    enemy = RedKoopaShell();
                    break;
                case "PirranhaPlant":
                    enemy = PirranhaPlantFactory();
                    break;
             
                default:
                    enemy = MovingNormalGoombaFactory();
                    break;

            }
            enemy.Texture=game.Content.Load<Texture2D>("Enemies/enemySpritesheet");
            enemy.SheetSize = new Point(12, 2);
            enemy.FrameSize = new Point(18, 26);
            return enemy;
        }
          
        #region Goomba

        private static AnimatedSprite MovingNormalGoombaFactory()
        {
            AnimatedSprite movingGoomba = new MovingGoombaSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false,
                AnimationFrame = 12
            };
            return movingGoomba;
        }
        public static AnimatedSprite MovingBlueGoombaFactory()
        {
            AnimatedSprite movingGoomba = new MovingGoombaSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false,
                AnimationFrame = 15
            };
            return movingGoomba;
        }

        public static ISprite MovingGreyGoombaFactory()
        {
            AnimatedSprite movingGoomba = new MovingGoombaSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false,
                AnimationFrame = 18
            };
            return movingGoomba;
        }

        public static StaticSprite FlattenedNormalGoomba()
        {
            StaticSprite flattenedGoomba = new StaticSprite
            {
                CurrentFrame = new Point(2, 1),
              //  MillisecondsPerFrame = 1000,
                NeedFlip = false,
              //  AnimationFrame = 14
            };
            return flattenedGoomba;
        }
        public static StaticSprite FlattenedBlueGoomba()
        {
            StaticSprite flattenedGoomba = new StaticSprite
            {
                CurrentFrame = new Point(5, 1),
                //MillisecondsPerFrame = 1000,
                NeedFlip = false,
               // AnimationFrame = 17
            };
            return flattenedGoomba;
        }
        public static StaticSprite FlattenedGreyGoomba()
        {
            StaticSprite flattenedGoomba = new StaticSprite
            {
                CurrentFrame = new Point(8, 1),
                //MillisecondsPerFrame = 1000,
                NeedFlip = false,
                //AnimationFrame = 20
            };
            return flattenedGoomba;
        }
        #endregion

        #region Koopa
        private static AnimatedSprite MovingGreenKoopaFactory()
        {
            AnimatedSprite movingKoopa = new GreenWalkingKoopa
            {
                MillisecondsPerFrame = 400,
                CurrentFrame = new Point(1, 0),
                NeedFlip = false
            };
            ;
            movingKoopa.AnimationFrame = 1;
            return movingKoopa;
        }
        private static AnimatedSprite MovingRedKoopaFactory()
        {
            AnimatedSprite movingKoopa = new RedWalkingKoopa
            {
                CurrentFrame = new Point(4, 0),
                MillisecondsPerFrame = 400,
                NeedFlip = true,
                AnimationFrame = 4
            };
            return movingKoopa;
        }

        private static StaticSprite GreenKoopaShell()
        {
            StaticSprite koopaShell = new StaticSprite
            {
                CurrentFrame = new Point(0, 0),
                //MillisecondsPerFrame = 800,
                NeedFlip = true,
                //AnimationFrame = 0
            };
            return koopaShell;
        }
        private static StaticSprite RedKoopaShell()
        {
            StaticSprite koopaShell = new StaticSprite
            {
                CurrentFrame = new Point(3, 0),
                //MillisecondsPerFrame = 800,
                NeedFlip = true,
                //AnimationFrame = 3
            };
            return koopaShell;
        }

        #endregion

        private static AnimatedSprite PirranhaPlantFactory()
        {
            AnimatedSprite pplant = new PirranhaPlant
            {
                MillisecondsPerFrame = 400,
                CurrentFrame = new Point(1, 0),
                NeedFlip = false
            };
            ;
            pplant.AnimationFrame = 21;
            return pplant;
        }
    }

}
