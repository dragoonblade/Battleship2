using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{

    public class Program
    {
        static int shots;
        static void Main(string[] args)
        {
            int[,] grid = {{0,0,0,0,0,0,0,0,0,0},
                           {0,2,2,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,3,0,0,0,0,4,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,5,5,5,5,5,0,0,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,3,3,3,0},
                           {0,0,0,0,0,0,0,0,0,0}};
            
            float[] pd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] number = new int[100];
            int[] value = new int[2];    
            int ships = 0;
            int c = 0;
            int count = 0;
            while (count < 100)
            {
                Probability p = new Probability();
                Finder f = new Finder();
                Target t = new Target();
                Random rnd = new Random();
                shots = 0;
                ships = 0;
                while (ships != 5)
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
                    Console.WriteLine("x = " + x);
                    Console.WriteLine("y = " + y);

                    if (c > 3)
                    {
                        c = 0;
                        x = rnd.Next(0, 9);
                        y = rnd.Next(0, 9);
                    }

                    if (t.sea[x, y] != -1)
                    {
                        c++; 
                    }

                    else if (grid[x, y] == 0)
                    {
                        c = 0;
                        Console.WriteLine("MISS!!!");
                        p.miss(x, y, t.sea);
                        t.sea[x, y] = 0;
                        shots++;
                        Console.WriteLine("Shots = " + shots);
                    }
                    else
                    {
                        c = 0;
                        shots = t.calc(grid, x, y, shots);
                        ships++;
                    }
                }
                Console.WriteLine("Shots = " + shots);
                Console.WriteLine("Ships = " + ships);
                number[count] = shots;
                count++;
            }
            Console.WriteLine("Number");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(number[i]);
            }
            Console.WriteLine("Number");
        }
    }
}
