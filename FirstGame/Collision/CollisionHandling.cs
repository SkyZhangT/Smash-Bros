using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FirstGame
{
    public class CollisionEventArgs: EventArgs
    {
        public IEntity hit { get; set; }
        public String from { get; set; }
        public GameTime time { get; set; }
        public IEntity currentEntity { get; set; }
    }
    static class CollisionHandling
    {
        public delegate void CollisionDetectionEventHandler(IEntity source, CollisionEventArgs args);
       // public static event CollisionDetectionEventHandler Collision;
        

        public static Dictionary<Vector2,List<IEntity>> Grid { get; set; }


        private static HashSet<Vector2> GetPlace(IEntity entity)
        {
            HashSet<Vector2> gridPlaces = new HashSet<Vector2>();
            int xDistance = (int)Math.Ceiling((double)entity.CurrentSprite.FrameSize.X / (double)16);
            int yDistance = (int)Math.Ceiling((double)entity.CurrentSprite.FrameSize.Y / (double)16);
            for (int x = 0; x < xDistance; x++)
            {
                for (int y = 0; y < yDistance; y++)
                {
                    Vector2 gridPlace = new Vector2((float)Math.Ceiling(entity.Position.X / 16) + x, (float)Math.Ceiling(entity.Position.Y / 16) + y);
                    Vector2 gridPlace2 = new Vector2((float)Math.Ceiling(entity.Position.X / 16) + x, (float)Math.Floor(entity.Position.Y / 16) + y);
                    Vector2 gridPlace3 = new Vector2((float)Math.Floor(entity.Position.X / 16) + x, (float)Math.Ceiling(entity.Position.Y / 16) + y);
                    Vector2 gridPlace4 = new Vector2((float)Math.Floor(entity.Position.X / 16) + x, (float)Math.Floor(entity.Position.Y / 16) + y);
                    gridPlaces.Add(gridPlace);
                    gridPlaces.Add(gridPlace2);
                    gridPlaces.Add(gridPlace3);
                    gridPlaces.Add(gridPlace4);
                }
            }
            return gridPlaces;
        }

        private static HashSet<Vector2> GetPlace(IEntity entity,Vector2 originLoc)
        {
            HashSet<Vector2> gridPlaces = new HashSet<Vector2>();
            int xDistance = (int)Math.Ceiling((double)entity.CurrentSprite.FrameSize.X / (double)16);
            int yDistance = (int)Math.Ceiling((double)entity.CurrentSprite.FrameSize.Y / (double)16);
            for (int x = 0; x < xDistance; x++)
            {
                for (int y = 0; y < yDistance; y++)
                {
                    Vector2 gridPlace = new Vector2((float)Math.Ceiling(originLoc.X / 16) + x, (float)Math.Ceiling(originLoc.Y / 16) + y);
                    Vector2 gridPlace2 = new Vector2((float)Math.Ceiling(originLoc.X / 16) + x, (float)Math.Floor(originLoc.Y / 16) + y);
                    Vector2 gridPlace3 = new Vector2((float)Math.Floor(originLoc.X / 16) + x, (float)Math.Ceiling(originLoc.Y / 16) + y);
                    Vector2 gridPlace4 = new Vector2((float)Math.Floor(originLoc.X / 16) + x, (float)Math.Floor(originLoc.Y / 16) + y);
                    gridPlaces.Add(gridPlace);
                    gridPlaces.Add(gridPlace2);
                    gridPlaces.Add(gridPlace3);
                    gridPlaces.Add(gridPlace4);
                }
            }
            return gridPlaces;
        }
        //to increase performance could only call this once then update in entitymanager only entities that move as it is static
        public static void Create(ref Collection<IEntity> entities)
        {
            CollisionHandling.Grid = new Dictionary<Vector2, List<IEntity>>();
            foreach(IEntity entity in entities)
            {
                HashSet<Vector2> gridPlaces = GetPlace(entity);
                
                foreach (Vector2 gridPlacer in gridPlaces)
                {
                    List<IEntity> temp = new List<IEntity> { entity};
                    if (Grid.ContainsKey(gridPlacer))
                    {
                        temp.AddRange(Grid[gridPlacer]);
                        Grid.Remove(gridPlacer);
                    }
                    Grid.Add(gridPlacer, temp);
                }

            }
        }
        public static void Update(IEntity entity, Vector2 locFirst)
        {
            Remove(entity, locFirst);
            HashSet<Vector2> gridPlaces = GetPlace(entity);
            foreach (Vector2 gridPlacer in gridPlaces)
            {
                List<IEntity> temp = new List<IEntity> { entity };
                if (Grid.ContainsKey(gridPlacer))
                {
                    temp.AddRange(Grid[gridPlacer]);
                    Grid.Remove(gridPlacer);
                }
                Grid.Add(gridPlacer, temp);
            }
        }

        //When AABB created, add side hit, and what hit, to the return instead of string
        public static void DidCollide(IEntity entity, GameTime time)
        {
            HashSet<Vector2> gridPlaces = GetPlace(entity);
            HashSet<IEntity> possibleCollisions = new HashSet<IEntity>();
            foreach (Vector2 gridLocation in gridPlaces)    
            {         
                Vector2 checkHere = new Vector2(gridLocation.X/* - 1 + x*/, gridLocation.Y/* - 1 + y*/);
                if (Grid.ContainsKey(checkHere))        
                {
                    foreach(IEntity enti in Grid[checkHere])
                    {
                        possibleCollisions.Add(enti);
                    }
                }    
            }
            
            foreach (IEntity enti in possibleCollisions)
            {
                if (!ReferenceEquals(enti, entity))
                {
                    if (Collide(entity.HitBox, enti.HitBox))
                    {
                        //Probably a better way to do it but
                        Rectangle Intersaction = Rectangle.Intersect(new Rectangle(entity.HitBox.X,entity.HitBox.Y,entity.HitBox.Width,entity.HitBox.Height), new Rectangle(enti.HitBox.X, enti.HitBox.Y, enti.HitBox.Width, enti.HitBox.Height));
                        
                        if (Intersaction.Width < 5 || Intersaction.Height < 5){
                            if (Intersaction.Height <= Intersaction.Width)
                            {
                                if (entity.HitBox.Y < enti.HitBox.Y)
                                {
                                    entity.Collision.HitFromBot(enti, time);
                                }
                                else
                                {
                                    if(entity is AvatarMain && entity.Velocity.Y <= 0 )
                                    {
                                        enti.Collision.HitFromBot(entity, time); //Dont take this line off!!!! Blocks need it to move! Tianyang Zhang
                                    }
                                    entity.Collision.HitFromTop(enti, time);
                                }
                            }
                            else
                            {
                                entity.Collision.HitFromSide(enti, time);
                            }
                        }
                        entity.Collision.Response(enti, time);
                    }
                }
            }
        }

        //AABB detection is using the hitbox rectatngle to determine the collision (by the point and dx, dy)
        public static bool Collide(Rectangle originalEntity,Rectangle entityCollidedWith)
        {
            if (originalEntity.Bottom < entityCollidedWith.Top || originalEntity.Top > entityCollidedWith.Bottom) return false;
            if (originalEntity.Left > entityCollidedWith.Right || originalEntity.Right < entityCollidedWith.Left) return false;
            return true;
        }

        public static void Remove(IEntity entity,Vector2 loc)
        {
            HashSet<Vector2> gridPlaces = GetPlace(entity,loc);
            foreach (Vector2 gridPlacer in gridPlaces)
            {
                if (Grid.ContainsKey(gridPlacer))
                {
                    Grid[gridPlacer].Remove(entity);
                }
            }
        }
        public static void Remove(IEntity entity)
        {
            HashSet<Vector2> gridPlaces = GetPlace(entity);
            foreach (Vector2 gridPlacer in gridPlaces)
            {
                List<IEntity> temp = new List<IEntity> { };
                if (Grid.ContainsKey(gridPlacer))
                {
                    temp.AddRange(Grid[gridPlacer]);
                    temp.Remove(entity);
                    Grid.Remove(gridPlacer);
                    Grid.Add(gridPlacer, temp);
                }
            }
        }

        
    }
}
