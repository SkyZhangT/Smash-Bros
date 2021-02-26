using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Indicators
{
    public class LivesIndicator
    {
        public int lives { get; set; }

        public LivesIndicator()
        {
            lives = 3;
        }

        public void UpdateLives()
        {
            lives++;
        }


        public int Value()
        {
            return lives;
        }
        
    }
}
