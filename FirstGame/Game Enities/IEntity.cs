using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.State.BlockStates;

namespace Sprint0.Game_Enities
{
    public interface IEntity
    {
        //Basic properties
        IEntity Master { get; set; }
        Vector2 Position { get; set; }
        bool FacingRight { get; set; } //facing left is false  right is true
        bool Visible { get; set; }
        Vector2 Velocity { get; set; }
        float Gravity { get; set; }
        int LifeLeft { get; set; }
        string Name { get; set; }
        bool PhysicsEnabled { get; set; }

        //Collision related
        ISprite CurrentSprite { get; set; }
        Rectangle HitBox { get; set; }
        Color HitBoxColor { get; set; }

        //Functional methods
        void UpdateEntity(GameTime gameTime);
        void Initialize();

        Game1 Game { get; set; }

        Color Indicator { get; set; }
        ICollision Collision {get;set;}

        IState ActionState { get; set; }
        IActionState CurrentActionState { get; set; }
        IPowerUpState CurrentPowerState { get; set; }
        IBlockState CurrentState { get; set; }
        Vector2 TPosition { get; set; }
    }
}
