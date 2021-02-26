using FirstGame;
using Microsoft.Xna.Framework.Input;
using Sprint0.Game_Enities.Avatar;
using System.Collections.Generic;
using Sprint0.Game_Enities.Blocks;
using Sprint0.Game_Enities;

namespace Sprint0.Commands.Mapping
{
    public class CommandMap: ICommandMap
    {
        private Dictionary<int,ICommand> ControlsMap;
        private readonly Game1 Game;


        public CommandMap(Game1 game)
        {
            Game = game;

            ControlsMap = new Dictionary<int, ICommand>
            {
                //TODO add one more controller for another avatar

                #region Control Definitions

                #region Punch
                { (int)Keys.Space, new PunchCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.RightControl, new PunchCommand(Game.CurrentScene.PlayerAvatar2) },

                #endregion

                #region Skill
                { (int)Keys.D1, new SkillCommand(game,Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.D0, new SkillCommand(game,Game.CurrentScene.PlayerAvatar2) },
                #endregion

                #region MoveLeft
                { (int)Keys.Left, new MoveLeftCommand(Game.CurrentScene.PlayerAvatar2) },
                { (int)Keys.A, new MoveLeftCommand(Game.CurrentScene.PlayerAvatar) },


                { (int)Buttons.DPadLeft, new MoveLeftCommand(Game.CurrentScene.PlayerAvatar) },
                #endregion

                #region MoveRight
                { (int)Keys.Right, new MoveRightCommand(Game.CurrentScene.PlayerAvatar2) },
                { (int)Keys.D, new MoveRightCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Buttons.DPadRight, new MoveRightCommand(Game.CurrentScene.PlayerAvatar) },
                #endregion

                #region Jump
                { (int)Keys.Up, new JumpCommand(Game.CurrentScene.PlayerAvatar2) },
                { (int)Keys.W, new JumpCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Buttons.A, new JumpCommand(Game.CurrentScene.PlayerAvatar) },
                #endregion

                #region Crouch
                { (int)Keys.Down, new CrouchCommand(Game.CurrentScene.PlayerAvatar2) },
                { (int)Keys.S, new CrouchCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Buttons.DPadDown, new CrouchCommand(Game.CurrentScene.PlayerAvatar) },
                #endregion

                #region Dash/Throw Fireball
                { (int)Keys.LeftShift, new DashFireballCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.RightShift, new DashFireballCommand(Game.CurrentScene.PlayerAvatar2) },
                { (int)Buttons.B, new DashFireballCommand(Game.CurrentScene.PlayerAvatar) },
                #endregion

                #region Quit
                { (int)Keys.Q, new QuitCommand(Game) },
                #endregion

                #region Pause
                { (int)Keys.P, new PauseCommand(Game) },
                #endregion

                #region BecomeSmallMario
                { (int)Keys.Y, new PromoteSmallMarioCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.H, new PromoteSmallMarioCommand(Game.CurrentScene.PlayerAvatar2) },
                #endregion

                #region BecomeSuperMario
                { (int)Keys.U, new PromoteSuperMarioCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.J, new PromoteSuperMarioCommand(Game.CurrentScene.PlayerAvatar2) },
                #endregion

                #region BecomeFireMario
                { (int)Keys.I, new PromoteFireMarioCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.K, new PromoteFireMarioCommand(Game.CurrentScene.PlayerAvatar2) },
                #endregion
               
                #region ItemUse
                { (int)Keys.E, new UseItemCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.OemQuestion, new UseItemCommand(Game.CurrentScene.PlayerAvatar2) },
                #endregion

                #region HitMario
                { (int)Keys.O, new HitMarioCommand(Game.CurrentScene.PlayerAvatar) },
                { (int)Keys.L, new HitMarioCommand(Game.CurrentScene.PlayerAvatar2) },
                #endregion

                #region LevelReset

                 { (int)Keys.R, new LevelResetCommand(Game) },

                #endregion
                #region Mute
                {(int)Keys.M,new MuteCommand() },
                #endregion

                #region ToggleFullScreen
                {(int)Keys.F, new FullScreenCommand(game) },
                #endregion

                #endregion

                /*#region Block Definitions
                { (int)Keys.B, new BlockCommand(Brick) },
                { (int)Keys.X, new BlockCommand(CoinBox) },
                { (int)Keys.K, new BlockCommand(HiddenBrick) },
                #endregion*/

                { (int)Keys.C, new HitBoxCommand(Game) }
            };
        }

    public ICommand GetCommand(int id)
        {
            if (ControlsMap.ContainsKey(id)) return ControlsMap[id];

            else return new UndefinedCommand();
        }
    }
}
