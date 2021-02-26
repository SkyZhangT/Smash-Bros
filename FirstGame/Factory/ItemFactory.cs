using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.ItemSprite;

namespace FirstGame
{
    static class ItemFactory
    {

        public static ISprite CreateSprite(Game1 game, string type)
        {
            ISprite item=null;
            switch (type)
            {
                case "NormalFlower":
                    item = NormalFlowerFactory();
                    break;
                case "BlueFlower":
                    item = BlueFlowerFactory();
                    break;
                case "Star":
                    item = StarFactory();
                    break;
                case "Coin":
                    item = CoinFactory();
                    break;
                case "SuperMushroom":
                    item = SuperMushroomFactory();
                    break;
                case "1UpMushroom":
                    item = OneUpMushroomFactory();
                    break;

            }
            item.Texture = game.Content.Load<Texture2D>("Items/Items");
            item.SheetSize = new Point(9, 4);
            item.FrameSize = new Point(16, 16);
            return item;
        }

        #region Flower

        private static AnimatedSprite NormalFlowerFactory()
        {
            AnimatedSprite flower = new NormalFireFlowerSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            return flower;
        }

        private static AnimatedSprite BlueFlowerFactory()
        {
            AnimatedSprite flower = new BlueFireFlowerSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            return flower;
        }
        public static AnimatedSprite StarFactory()
        {
            AnimatedSprite star = new StarSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            return star;
        }

        public static AnimatedSprite CoinFactory()
        {
            AnimatedSprite coin = new CoinSprite
            {
                MillisecondsPerFrame = 200,
                NeedFlip = false
            };
            return coin;
        }

        public static StaticSprite SuperMushroomFactory()
        {
            StaticSprite superMushroom = new StaticSprite
            {
                CurrentFrame = new Point(10, 1),
                NeedFlip = false
            };
            return superMushroom;
        }
        public static StaticSprite OneUpMushroomFactory()
        {
            StaticSprite oneUpMushroom = new StaticSprite
            {
                CurrentFrame = new Point(11, 1),
                NeedFlip = false
            };
            return oneUpMushroom;
        }

        #endregion
    }
}
