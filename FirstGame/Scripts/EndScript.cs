using FirstGame;
using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Game_Enities.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Scripts
{
    public class EndScript : AScript
    {
        public Game1 Game { get; set; }
        public AvatarMain PlayerAvatar { get; set; }
        float Endingtime;
        float pos;
        GameTime startTime;
        Random rand;

        Vector2 Fireworkplace;

        public EndScript(Game1 game, AvatarMain avatar, float endTime, GameTime time,float pos)
        {
            rand = new Random();
            this.startTime = time;
            this.pos = pos;
            this.Endingtime = endTime;
            this.PlayerAvatar = avatar;
            this.Game = game;
        }

        public void EndGame()
        {
            int gameTime = startTime.TotalGameTime.Minutes * 6000 + startTime.TotalGameTime.Seconds * 1000 + startTime.TotalGameTime.Milliseconds;
            
            if (gameTime - Endingtime < 3000)
            {
                if (PlayerAvatar.Position.Y < pos - 1)
                {
                    PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, PlayerAvatar.Position.Y + 1);
                }
                else if (PlayerAvatar.Position.Y >= pos)
                {
                    PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, pos - 1f);
                }
            }
            else if (gameTime - Endingtime < 4000 && this.Game.Once)
            {
                this.PlayerAvatar.FacingRight = !this.PlayerAvatar.FacingRight;
                this.Game.Once = false;
                if (PlayerAvatar.CurrentPowerState is SmallMarioPowerUpState)
                {
                    this.PlayerAvatar.CurrentSprite = MarioFactory.SmallMarioRunningLeftFactory(this.Game);
                    PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, pos + 15.5f);
                }
                else if (PlayerAvatar.CurrentPowerState is FireMarioPowerUpState)
                {
                    this.PlayerAvatar.CurrentSprite = MarioFactory.FireMarioRunningLeftFactory(this.Game);
                    PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, pos + 13.5f);
                }
                else
                {
                    this.PlayerAvatar.CurrentSprite = MarioFactory.SuperMarioRunningLeftFactory(this.Game);
                    PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X, pos + 13.5f);
                }
                PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X + 1, PlayerAvatar.Position.Y);
            }
            else if (gameTime - Endingtime < 5000)
            {
                PlayerAvatar.Position = new Vector2(PlayerAvatar.Position.X + 1, PlayerAvatar.Position.Y);
                if (startTime.TotalGameTime.Minutes * 6000 + startTime.TotalGameTime.Seconds * 1000 + startTime.TotalGameTime.Milliseconds - Endingtime > 4600)
                {
                    this.Game.Once = true;
                }
            }
            else if (gameTime - Endingtime >= 5000 && gameTime - Endingtime < 7000 && this.Game.Once)
            {
                PlayerAvatar.Visible = false;
                Fireworkplace = PlayerAvatar.Position;
                Game.EntityManager.AddEntity(new StarFlagEntit(new Vector2(Fireworkplace.X, Fireworkplace.Y - 94 + PlayerAvatar.CurrentSprite.FrameSize.Y), BlockFactory.AllBlockFactory(this.Game, "StarFlag"), this.Game));
                this.Game.Once = false;
            }
            else if (startTime.TotalGameTime.Seconds * 1000 + startTime.TotalGameTime.Milliseconds - Game.LastTime > 500 + rand.Next(0, 200) && gameTime - Endingtime < 10000)
            {
                Game.LastTime = startTime.TotalGameTime.Seconds * 1000 + startTime.TotalGameTime.Milliseconds;
                Game.EntityManager.AddEntity(new Firework(new Vector2(Fireworkplace.X + rand.Next(-50, 50), Fireworkplace.Y + rand.Next(-110, -80)), BlockFactory.AllBlockFactory(this.Game, "FireWorks"), this.Game));
            }
            else if (gameTime - Endingtime > 10000)
            {
                this.Game.CurrentScene.GameState = new WinState(this.Game);
                this.DoneFlag = true;
            }
        }

        public override void Update(GameTime time)
        {
            if (!DoneFlag)
            {
                this.EndGame();
            }
        }
    }
}
