using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{

    public class Program
    {
        static int shots = 0;
        static void Main(string[] args)
        {
            int[,] grid = {{0,0,0,0,0,0,0,4,0,0},
                           {0,2,2,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,5,5,5,5,5,0,0,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,3,3,3,0},
                           {0,0,0,0,0,0,0,0,0,0}};

            float[] pd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] value = new int[2];        
            Probability p = new Probability();
            Finder f = new Finder();
            Target t = new Target();
            int ships = 0;
            while (ships != 1)
            {
                pd = p.density();
                Console.WriteLine("Density");
                for (int i = 0; i < 16; i++)
                {
                    Console.Write(pd[i] + " ");
                } 
                Console.WriteLine();
                f.block(pd);
                value = f.select(t.sea);
                int x = value[0];
                int y = value[1];

                if( t.sea[x,y] != -1)
                {
                    Console.WriteLine("x = " + x);
                    Console.WriteLine("y = " + y);
                }

                else if (grid[x, y] == 0)
                {
                    Console.WriteLine("MISS!!!");
                    p.miss(x, y,t.sea);
                    t.sea[x, y] = 0;
                    shots++;
                }
                else
                {
                    shots++;
                    t.calc(grid, x, y, shots);
                    ships++;
                }
            }
            Console.WriteLine("Shots = " + shots);
            Console.WriteLine("Ships = " + ships);
        }
    }
}
