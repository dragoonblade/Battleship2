using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{

    public class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = {{2,2,0,0,0,0,0,4,0,0},
                           {0,0,0,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,5,5,5,5,5,0,0,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,3,3,3,0},
                           {0,0,0,0,0,0,0,0,0,0}};

            Probability s = new Probability();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(s.prob[i, j] + " ");
                }
                Console.WriteLine();
            }

            if (grid[4, 5] == 0)6
                s.miss(i, j);
            else
            {

            }
            
            Console.WriteLine("After Miss");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(s.prob[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
