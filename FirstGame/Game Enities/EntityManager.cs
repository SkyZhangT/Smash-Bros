using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities.Enemies;
using Sprint0.State.BlockStates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FirstGame
{
    public sealed class EntityManager : IDisposable
    {
        //This is used as an out parameter, so it cannot be a property
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Collection<IEntity> entities;
        private SpriteBatch SpriteBatch { get; set; }

        private Texture2D RecTex;
        private Game1 Game { get; set; }
        public EntityManager(SpriteBatch batch, Game1 game)
        {
            this.SpriteBatch = batch;
            entities = new Collection<IEntity>();
            RecTex = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            RecTex.SetData(new[] { Color.White });
            Game = game;
        }

        public void AddEntity(IEntity entity)
        {
            entities.Add(entity);
        }
        public void AddEntity(IEntity entity, int index)
        {
            entities.Insert(index,entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            entities.Remove(entity);
            CollisionHandling.Remove(entity);
        }

        public void RemoveAllEntity()
        {
            foreach (IEntity entity in this.entities)
            {
                CollisionHandling.Remove(entity);
            }
            entities = new Collection<IEntity>(); 
        }

        public void DrawEntities()
        {
            for(int i = 0;i < this.entities.Count; i++)
            {
                IEntity entity = this.entities[i];
                if (entity.Visible)
                {
                    if (entity is Castle || entity is PiranhaPlantEntity)
                    {
                        SpriteBatch.Draw(entity.CurrentSprite.Texture, new Vector2(entity.Position.X, entity.Position.Y),
                        new Rectangle((int)entity.CurrentSprite.CurrentFrame.X * entity.CurrentSprite.FrameSize.X, (int)entity.CurrentSprite.CurrentFrame.Y * entity.CurrentSprite.FrameSize.Y, entity.CurrentSprite.FrameSize.X, entity.CurrentSprite.FrameSize.Y), entity.Indicator, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, .1f);
                    }
                    else if (entity.FacingRight)
                    {
                        SpriteBatch.Draw(entity.CurrentSprite.Texture, new Vector2(entity.Position.X, entity.Position.Y),
                        new Rectangle((int)entity.CurrentSprite.CurrentFrame.X * entity.CurrentSprite.FrameSize.X, (int)entity.CurrentSprite.CurrentFrame.Y * entity.CurrentSprite.FrameSize.Y, entity.CurrentSprite.FrameSize.X, entity.CurrentSprite.FrameSize.Y), entity.Indicator, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
                    }
                    else
                    {
                        SpriteBatch.Draw(entity.CurrentSprite.Texture, new Vector2(entity.Position.X, entity.Position.Y),
                        new Rectangle((int)entity.CurrentSprite.CurrentFrame.X * entity.CurrentSprite.FrameSize.X, (int)entity.CurrentSprite.CurrentFrame.Y * entity.CurrentSprite.FrameSize.Y, entity.CurrentSprite.FrameSize.X, entity.CurrentSprite.FrameSize.Y), entity.Indicator, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                    }
                }
                if (Game.VisibleHitBox)
                {
                    DrawHitBox(entity.HitBox, 2, entity.HitBoxColor);
                }
            }        
        }

        public void UpdateEntities(GameTime gameTime)
        {
            List<IEntity> deadEntity=new List<IEntity>();
            for (int i = 0; i < this.entities.Count; i++)
            {
                IEntity entity = this.entities[i];
                entity.UpdateEntity(gameTime);
                if (!entity.Visible)
                {
                    // when the hidden block is in hidden state, dont add into list
                    if(entity is HiddenBlockEntity)
                    {
                        IBlockEntity temp = (IBlockEntity)entity;
                        if(!(temp.CurrentState is HiddenBoxState))
                        {
                            deadEntity.Add(entity);
                        }
                        //else dont add into list
                    }
                    else
                    {
                        deadEntity.Add(entity);
                    }
                }
            }
            foreach(IEntity entity in deadEntity)
            {
                RemoveEntity(entity);
            }
        }

        public void DrawHitBox(Rectangle BoxToDraw, int BorderThickness, Color BoxColor)
        {
            SpriteBatch.Draw(RecTex, new Rectangle(BoxToDraw.X, BoxToDraw.Y, BoxToDraw.Width, BorderThickness), BoxColor);
            SpriteBatch.Draw(RecTex, new Rectangle(BoxToDraw.X, BoxToDraw.Y, BorderThickness, BoxToDraw.Height), BoxColor);
            SpriteBatch.Draw(RecTex, new Rectangle(BoxToDraw.X + BoxToDraw.Width - BorderThickness, BoxToDraw.Y, BorderThickness, BoxToDraw.Height), BoxColor);
            SpriteBatch.Draw(RecTex, new Rectangle(BoxToDraw.X, BoxToDraw.Y + BoxToDraw.Height - BorderThickness, BoxToDraw.Width, BorderThickness), BoxColor);
        }

        //Here to fix warning
        public void Dispose()
        {
            RecTex.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
