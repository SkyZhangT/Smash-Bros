using Sprint0.Game_Enities.Avatar;

namespace FirstGame
{
    public interface IActionState : IState
    {

        /*
         * Type corresponds to the kind of event that wants to change the avatar's state
         * 0 = normal command (button pressed)
         * 1 = undo command ()
         * 2 = environment event (such as collision)
         */

        void Punch(int type);    
        void GoRight(int type);
        void GoLeft(int type);
        void GoDown(int type);
        void GoUp(int type);
        void Stun();
    }
}
