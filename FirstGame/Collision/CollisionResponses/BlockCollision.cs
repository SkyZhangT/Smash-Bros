using Sprint0.Game_Enities;
using Microsoft.Xna.Framework;
using System;
using FirstGame;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Enemies;
using Sprint0.Game_Enities.Blocks;

namespace Sprint0.Collision
{
    class BlockCollision : ICollision
    {
        public IEntity CurrentEntity { get; set; }

        public BlockCollision(IEntity enemy)
        {
            //CollisionHandling.Collision += OnCollision;
            CurrentEntity = enemy;
        }
        
        public void Response(IEntity entity, GameTime time)
        {
            CurrentEntity.Indicator = Color.Brown;
        }

        public void HitFromTop(IEntity entityHit, GameTime time)
        {
            if(entityHit is MarioAvatar||entityHit is TurtleAvatar)
            {
                if(entityHit.CurrentActionState is CrouchState||entityHit.CurrentActionState is TurtleCrouchState)
                {
                    if(CurrentEntity.TPosition != new Vector2(0, 0))
                    {
                        entityHit.Position = CurrentEntity.TPosition;
                    }
                }
            }
            
        }

        public void HitFromBot(IEntity entityHit, GameTime time)
        {
            CurrentEntity.CurrentState.BumpTransition(entityHit, time);
        }

        public void HitFromSide(IEntity entityHit, GameTime time)
        {
            //todo: add collision response
        }
    }
}