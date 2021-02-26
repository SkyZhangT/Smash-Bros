using Microsoft.Xna.Framework;
using Sprint0.Game_Enities.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Text.HUD.Indicators.Instants
{
    public class DamageIndicator
    {
        private int damage;
        AvatarMain player;
        private Vector2 position;
        private Random r;
        bool isBumping = false;
        private int diff;
        double moveAmount = 0.7d;
        bool isMovingOut = false;
        bool isMovingIn = false;
        private Vector2 BasePos;
        private double distMoved=0;
        private bool isRebounding = false;
        private float ypos;
        private float xMove;

        public Vector2 Position { get => position; set => position = value; }

        public DamageIndicator(AvatarMain avatar, Vector2 pos)
        {
            this.player = avatar;
            damage = 0;
            BasePos = pos;
            Position = BasePos;
            r = new Random();         
        }

        public void Update()
        {
            if (this.player.Damage > this.damage && !isBumping)
            {
                isBumping = true;
                isMovingOut = true;
                
                diff = this.player.Damage - this.damage;
                this.moveAmount = diff * .5;
                float x = r.Next(-diff/2,  (diff/2)+1);
                int n = r.Next(0, 2);
                float y = (float)Math.Sqrt((Math.Pow(diff,2)) - Math.Pow(x,2));
                if (n == 0)
                {
                    y = -y;
                    moveAmount = -Math.Abs(moveAmount);
                } else
                {
                    moveAmount = Math.Abs(moveAmount);
                }

                xMove = (float)((x / y) * moveAmount);
                ypos = y;
            }
            if (isBumping)
            {
                if (isMovingOut)
                {
                    if (distMoved > Math.Abs(ypos))
                    {
                        isMovingOut = false;
                        isRebounding = true;
                        distMoved = 0;
                        
                    } else
                    {
                        distMoved += Math.Abs(moveAmount);
                        this.Position = new Vector2((float)(this.Position.X + xMove), (float)(this.Position.Y + moveAmount));
                    }
                }

                else if (isRebounding)
                {
                    if (distMoved > Math.Abs(2 * ypos))
                    {
                        isRebounding = false;
                        distMoved = 0;
                        isMovingIn = true;
                    }
                    else
                    {
                        distMoved += Math.Abs(moveAmount);
                        this.Position = new Vector2((float)(this.Position.X - xMove), (float)(this.Position.Y - moveAmount));
                    }
                }

                else if (isMovingIn)
                {
                    if (distMoved > Math.Abs(ypos))
                    {
                        isMovingIn = false;
                        distMoved = 0;
                        isBumping = false;
                        this.Position = BasePos;
                    }
                    else
                    {
                        distMoved += Math.Abs(moveAmount);
                        this.Position = new Vector2((float)(this.Position.X +xMove), (float)(this.Position.Y +moveAmount));
                    }
                }
            }
            damage = this.player.Damage;     
        }

        public void ResetDamage()
        {
            damage = 0;
        }

        public int Value()
        {
            return damage;
        }

        //This variable should not be able to be changed outside this class, but it can be read
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public Vector2 GetBasePos()
        {
            return BasePos;
        }
    }
}
