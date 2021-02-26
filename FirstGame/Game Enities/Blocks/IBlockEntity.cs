using Sprint0.State.BlockStates;

namespace Sprint0.Game_Enities.Blocks
{
    public interface IBlockEntity : IEntity
    {
        int CoinLeft { get; set; }
        string ItemType { get; set; }
    }
}
