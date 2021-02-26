using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators
{
    public class ChargeBarIndicator
    {
        private int energy;
        private int limit = 50;

        public ChargeBarIndicator()
        {
            energy = 0;
        }

        public void UpdateCharger(int e)
        {
            if (energy + e > limit)
            {
                energy = limit;
            }
            else
            {
                energy += e;
            }
        }

        public void ResetCharger()
        {
            energy = 0;
        }

        public int Value()
        {
            return energy;
        }
    }
}
