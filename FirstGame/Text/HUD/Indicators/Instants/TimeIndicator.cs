using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators
{
    public class TimeIndicator
    {
        private int time;
        private static readonly int TIME = 400;
        private bool active;

        public TimeIndicator()
        {
            active = true;
            time = TIME;
        }

        public void UpdateTime()
        {
            if (time > 0 && active) {
                time--;
            }
        }

        public void SetTime(int t)
        {
            time = t;
        }

        public void ResetTime()
        {
            time = TIME;
        }

        public int Value()
        {
            return time;
        }

        public void StopTime()
        {
            active = false;
        }
    }
}
