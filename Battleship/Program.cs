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

            Probability p = new Probability();
            Target t = new Target();
            Console.Write("Enter the x Coordinate: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter the y Coordinate: ");
            int y = int.Parse(Console.ReadLine());

            if (grid[x, y] == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(p.prob[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                p.miss(x, y);
                t.sea[x, y] = 0;
                Console.WriteLine("After Miss");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(p.prob[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                t.calc(grid, x, y);
            }
        }
    }
}
