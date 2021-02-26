using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using System;
using System.Collections.Generic;

namespace Sprint0.Collision
{
    public interface ICollision
    {
        IEntity CurrentEntity { get; set; }
        void Response(IEntity s, GameTime time);
        void HitFromTop(IEntity s, GameTime time);
        void HitFromBot(IEntity s, GameTime time);
        void HitFromSide(IEntity s, GameTime time);
    }
}