using FirstGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Game_Enities.Avatar;
using Sprint0.Indicators.Instants;
using Sprint0.Sounds;
using Sprint0.Text.HUD.Indicators.Instants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Indicators
{
    public class IndicatorManager
    {
        // Indicator Rule:
        // Coin: coin++
        // OnUpMushroom: Live++
        // SuperMushroom: Score+=500
        // FireFlower: Score+=1000
        // BreakBrick: Score+=100
        // Kill enemy: Score+=100
        // Tianyang Zhang

        #region Score defs
        public static readonly string COIN = "coin";
        public static readonly string SUPERMUSHROOM = "supermushroom";
        public static readonly string FIREFLOWER = "fireflower";
        public static readonly string SUPERSTAR = "superstar";
        public static readonly string ONEUPMUSHROOM = "1up";
        public static readonly string GOOMBA = "goomba";
        public static readonly string GREENKOOPA = "greenkoopa";
        public static readonly string FLAG1 = "flag1";
        public static readonly string FLAG2 = "flag2";
        public static readonly string FLAG3 = "flag3";
        public static readonly string FLAG4 = "flag4";
        public static readonly string FLAG5 = "flag5";



        public static readonly int COIN_SCORE = 200;
        public static readonly int SUPERMUSHROOM_SCORE = 1000;
        public static readonly int FIREFLOWER_SCORE = 1000;
        public static readonly int SUPERSTAR_SCORE = 1000;
        public static readonly int ONEUPMUSHROOM_SCORE = 0;
        public static readonly int GOOMBA_SCORE = 100;
        public static readonly int GREENKOOPA_SCORE = 100;

        public static readonly int FLAG1_SCORE = 100;
        public static readonly int FLAG2_SCORE = 400;
        public static readonly int FLAG3_SCORE = 800;
        public static readonly int FLAG4_SCORE = 2000;
        public static readonly int FLAG5_SCORE = 4000;

        #endregion

        private bool startscoreanim = false;


        private static readonly Dictionary<string, int> SCORES = new Dictionary<string, int>
        {
            {COIN , COIN_SCORE},
            {SUPERMUSHROOM, SUPERMUSHROOM_SCORE },
            {FIREFLOWER, FIREFLOWER_SCORE },
            {SUPERSTAR, SUPERSTAR_SCORE },
            {ONEUPMUSHROOM, ONEUPMUSHROOM_SCORE },
            {GOOMBA, GOOMBA_SCORE },
            {GREENKOOPA, GREENKOOPA_SCORE },
            {FLAG1,FLAG1_SCORE },
            {FLAG2,FLAG2_SCORE },
            {FLAG3,FLAG3_SCORE },
            {FLAG4,FLAG4_SCORE },
            {FLAG5,FLAG5_SCORE }

        };
        /* these are a workaround for mushrooms being consumed twice bug - michael */
       // bool superSecondCol = false;
       // bool oneupSecondCol = false;


        private int TimeElapsed;
        private readonly Game1 Game;
        private TimeIndicator time;
        private ScoreIndicator Score;
        private CoinsIndicator Coins;
        public ChargeBarIndicator Charger { get; set; }
        public LivesIndicator Lives { get; set; }
        public DamageIndicator Damage { get; set; }

        public TimeIndicator Time { get => time; set => time = value; }

        public IndicatorManager(Game1 game, AvatarMain avatar, Vector2 Position)
        {
            Game = game;
            Damage = new DamageIndicator(avatar,Position);
            Time = new TimeIndicator();
            Score = new ScoreIndicator();
            Coins = new CoinsIndicator();
            Lives = new LivesIndicator();
            Charger = new ChargeBarIndicator();
        }

        public int Value(string s)
        {
            switch (s)
            {
                case "coins":
                    return Coins.Value();
                case "lives":
                    return Lives.Value();
                case "score":
                    return Score.Value();
                case "time":
                    return Time.Value();
                case "charger":
                    return Charger.Value();
                default:
                    return -1;
            }
        }


        public void UpdateIndicators(string type, Vector2 pos, GameTime Time)
        {
            if (type.CompareTo(SUPERMUSHROOM) == 0)
            {
                //superSecondCol = !superSecondCol;
                //if (superSecondCol == false)
               // {
                this.Score.UpdateScore(SUPERMUSHROOM_SCORE);
                this.Game.DisplayedScoreList.Add(new Game1.ScoreList(SUPERMUSHROOM_SCORE.ToString(), pos, Time.TotalGameTime.Minutes * 6000 + Time.TotalGameTime.Seconds * 1000 + Time.TotalGameTime.Milliseconds));
                // }
                //add energy
                Charger.UpdateCharger(25);
            }

            else if (SCORES.ContainsKey(type))
            {
                this.Score.UpdateScore(SCORES[type] * (int)Math.Pow(2, Game.FloatingScoreManager.Multiplier - 1));
                this.Game.DisplayedScoreList.Add(new Game1.ScoreList(SCORES[type].ToString(), pos, Time.TotalGameTime.Minutes * 6000 + Time.TotalGameTime.Seconds*1000+Time.TotalGameTime.Milliseconds));
            }

            if (type.CompareTo(COIN) == 0)
            {
                this.Coins.UpdateCoin();
                
                this.Game.DisplayedScoreList.Add(new Game1.ScoreList(COIN_SCORE.ToString(), pos, Time.TotalGameTime.Minutes * 6000 + Time.TotalGameTime.Seconds * 1000 + Time.TotalGameTime.Milliseconds));
                if (this.Coins.Value() >= 100)
                {
                    this.Coins.ResetCoin();
                    this.Lives.UpdateLives();
                }
                //add energy
                Charger.UpdateCharger(25);
            }
            if (type.CompareTo(ONEUPMUSHROOM) == 0)
            {
                // oneupSecondCol = !oneupSecondCol;
                this.Game.DisplayedScoreList.Add(new Game1.ScoreList(ONEUPMUSHROOM_SCORE.ToString(), pos, Time.TotalGameTime.Minutes * 6000 + Time.TotalGameTime.Seconds * 1000 + Time.TotalGameTime.Milliseconds));

                // if (oneupSecondCol == false)
                // {
                this.Lives.UpdateLives();
                //add energy
                Charger.UpdateCharger(25);

               // }
            }
        }

        
        private void StopTime()
        {
            this.Time.StopTime();
        }

        public void AddTimeScore()
        {
            this.StopTime();
            this.startscoreanim = true;
            //this.Time.SetTime(0);
        }


        public void Update(GameTime gametime)
        {
            //This doesnt follow the updating of the other indicators, but its much easier to do it this way
            this.Damage.Update();
            
                TimeElapsed += gametime.ElapsedGameTime.Milliseconds;
            if (TimeElapsed >= 100&&startscoreanim&&(Time.Value()>0))
            {
                //Time.SetTime(Time.Value()-1);
                this.Score.UpdateScore(2);
            }

                if (TimeElapsed >= 1000)
                {
                    Time.UpdateTime();
                    TimeElapsed = 0;
                }
                if (Time.Value() == 0)
                {
                startscoreanim = false;

                }

        }
    }
}
