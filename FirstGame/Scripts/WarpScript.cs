using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Avatar;
using Sprint0.InputControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Scripts
{
    class WarpScript : AScript
    {
        Game1 Game { get; set; }
        AvatarMain PlayerAvatar { get; set; }

        private Vector2 FinalTeleportPosition;
        //private float WarpAmount;

        private bool Descending;
        private bool Ascending;

        public WarpScript(AvatarMain avatar, Game1 game, Vector2 tpos)
        {
            this.Ascending = false;
            this.FinalTeleportPosition = tpos;
            Descending = true;
            this.Game = game;
            this.PlayerAvatar = avatar;
            //this.WarpAmount = PlayerAvatar.Position.Y + PlayerAvatar.CurrentSprite.FrameSize.Y;
            this.PlayerAvatar.AccelX = 0;
            this.PlayerAvatar.Velocity = Vector2.Zero;
            Game.CurrentScene.Controller = new Controller(new Sprint0.Commands.Mapping.PauseCommandMap(Game));
        }

        public void Descend()
        {
            if (PlayerAvatar.Position.Y < this.FinalTeleportPosition.Y + PlayerAvatar.CurrentSprite.FrameSize.Y)
            {
                PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, PlayerAvatar.Position.Y + 0.8f);
            }
            else
            {
                this.Descending = false;
                TP();
                this.Ascending = true;
            }

        }

        public void Ascend()
        {
            if (PlayerAvatar.Position.Y > this.FinalTeleportPosition.Y - PlayerAvatar.CurrentSprite.FrameSize.Y)
            {
                PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, PlayerAvatar.Position.Y - 0.8f);
            }
            else
            {
                this.Ascending = false;
                this.PlayerAvatar.Gravity = 0.08f;
                this.PlayerAvatar.PhysicsEnabled = true;
                Game.CurrentScene.Controller = new Controller(new Sprint0.Commands.Mapping.CommandMap(Game));
                this.DoneFlag = true;
            }
        }
        public void TP()
        {

           // if (FinalTeleportPosition.X > 3200)
            {
               // this.Game.Camera = this.Game.Camera2;
            }
            //else
            {
                //this.Game.Camera = this.Game.Camera1;
            }
            this.PlayerAvatar.Position = FinalTeleportPosition;
            Ascend();
        }

        public override void Update(GameTime time)
        {
            if (Descending)
            {
                this.Descend();
            } else if (Ascending)
            {
                this.Ascend();
            }

        }
    }
}
