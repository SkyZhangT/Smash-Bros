using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators
{
    public class CoinsIndicator
    {
        private int coins;

        public CoinsIndicator()
        {
            coins = 0;
        }

        public void UpdateCoin()
        {
            coins ++;
        }

        public void ResetCoin()
        {
            coins = 0;
        }

        public int Value()
        {
            return coins;
        }
    }
}

