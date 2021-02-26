using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators
{
    public class ScoreIndicator
    {
        private int score;

        public ScoreIndicator()
        {
            score = 0;
        }

        public void UpdateScore(int s)
        {
            score += s;
        }

        public int Value()
        {
            return score;
        }
    }
}
