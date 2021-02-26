using Sprint0.Game_Enities.Avatar;

namespace FirstGame
{
    public interface IPowerUpState
    {
        
        Game1 Game { get; set; }
        IPowerUpState PromoteMario();
        IPowerUpState PromoteSuperMario();
        IPowerUpState PromoteFireMario();
        IState PromoteStarMario();
        IPowerUpState Hit();

    }
}
