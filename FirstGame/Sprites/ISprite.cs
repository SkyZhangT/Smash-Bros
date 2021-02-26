using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;

namespace FirstGame
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        IEntity Entity { get;  set; }
        Point SheetSize { get; set; }
        Point FrameSize { get; set; }
        Point CurrentFrame { get; set; }
        void UpdateSprite(GameTime gameTime);
        Vector2 Ground { get; set; }
        Vector2 Top { get; set; }
        int JumpDirection { get; set; }
        bool NeedFlip { get; set; }
    }
}
