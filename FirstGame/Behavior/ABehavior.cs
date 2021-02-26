using Microsoft.Xna.Framework;
using Sprint0.Game_Enities;


namespace Sprint0.Behavior
{
    public abstract class ABehavior
    {

        internal static readonly int MILLIS_PER_UPDATE = 10;
        private static readonly int DEFAULT_MOVE_AMOUNT = 1;
        private int moveAmount;
        private IEntity entity;

        //Properties because of code analysis warnings
        protected int MillisSinceLastUpdate { get; set; }
        protected int MoveAmount { get => moveAmount; set => moveAmount = value; }
        protected IEntity Entity { get => entity; set => entity = value; }

        protected ABehavior(IEntity entity)
        {
            this.MoveAmount = DEFAULT_MOVE_AMOUNT;
            this.MillisSinceLastUpdate = 0;
            this.Entity = entity;
        }

        protected ABehavior(IEntity entity, int moveAmount)
        {
            this.MoveAmount = moveAmount;
            this.MillisSinceLastUpdate = 0;
            this.Entity = entity;
        }

        public abstract void Update(GameTime time);
    }
}
