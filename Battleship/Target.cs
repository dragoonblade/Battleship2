using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    public class Target
    {
        public int[,] prob = new int[10,10];
        
        Target()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    prob[i, j] = -1;
                }
            }
        }

        public void calc(int[,] grid, int x, int y)
        {
            
        }
    }
}
