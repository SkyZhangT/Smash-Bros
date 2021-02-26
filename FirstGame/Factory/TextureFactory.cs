using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.BackGroundSprite;

namespace FirstGame
{
    public static class TextureFactory
    {
        public static ISprite Factory(Game game, string type)
        {
            ISprite Texture;
            switch (type)
            {
                case "Super":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/Super")
                    };
                    break;
                case "Smash":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/Smash")
                    };
                    break;
                case "Bros":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/Bros")
                    };
                    break;
                case "Chaos":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/Chaos")
                    };
                    break;
                case "Plate":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/plate")
                    };
                    break;
                case "Circle":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/circle")
                    };
                    break;
                case "Bang":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/bang")
                    };
                    break;
                case "BlackMario":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/BlackMario")
                    };
                    break;
                case "WhiteMario":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/WhiteMario")
                    };
                    break;
                case "BlackLuigi":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/BlackLuigi")
                    };
                    break;
                case "WhiteLuigi":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/WhiteLuigi")
                    };
                    break;
                case "MarioIntro":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/MarioIntro")
                    };
                    break;
                case "LuigiIntro":
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/LuigiIntro")
                    };
                    break;
                case "Fire":
                    Texture = FireFactory(game);
                    break;
                default:
                    Texture = new StaticSprite
                    {
                        Texture = game.Content.Load<Texture2D>("SSB/Smash")
                    };
                    break;
            }
            return Texture;
        }


        public static AnimatedSprite FireFactory(Game game)
        {
            AnimatedSprite Fire = new FireSprite
            {
                Texture = game.Content.Load<Texture2D>("SSB/Fire"),
                SheetSize = new Point(15, 2),
                CurrentFrame = new Point(0, 0),
                MillisecondsPerFrame = 150
            };
            Fire.FrameSize = new Point(Fire.Texture.Width / Fire.SheetSize.X, Fire.Texture.Height / Fire.SheetSize.Y);
            return Fire;
        }
    }
}
