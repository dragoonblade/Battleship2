using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    public class Target
    {
        public int[,] sea = new int[10,10];
        public int[,] prob = new int[10,10];
        
        public Target()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sea[i, j] = -1;
                    prob[i, j] = 0;
                }
            }
        }

        public void calc(int[,] grid, int i, int j)
        {
            //create prob array with all zeroes somewhere bro
            prob[i,j]=-1;
            int h=1,n=grid[i,j];
            int tx=i,ty=j;
            sea[i, j] = n;
            Console.WriteLine("Sea Matrix");
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    Console.Write(sea[a, b] + " ");
                }
                Console.WriteLine();
            }
            while(h<n){
                i = tx;
                j = ty;
                calculateProbAround(i,j); //calculates probabilty around recently hit block
                //select next target based on largest probability around recent target
                if ((i > 1 && i < 8 && prob[i - 1, j] > prob[i + 1, j]) || i == 8)
                {
                    if ((j > 1 && j < 8 && prob[i, j - 1] > prob[i, j + 1]) || j == 8)
                    {
                        if (prob[i - 1, j] > prob[i, j - 1])
                        {
                            tx = i - 1;
                            ty = j;
                        }
                        else
                        {
                            tx = i;
                            ty = j - 1;
                        }
                    }
                    else
                    {
                        if (prob[i - 1, j] > prob[i, j + 1])
                        {
                            tx = i - 1;
                            ty = j;
                        }
                        else
                        {
                            tx = i;
                            ty = j + 1;
                        }
                    }
                }
                else
                {
                    if ((j > 1 && j < 8 && prob[i, j - 1] > prob[i, j + 1]) || j == 8)
                    {
                        if (prob[i + 1, j] > prob[i, j - 1])
                        {
                            tx = i + 1;
                            ty = j;
                        }
                        else
                        {
                            tx = i;
                            ty = j - 1;
                        }
                    }
                    else
                    {
                        if (prob[i + 1, j] > prob[i, j + 1])
                        {
                            tx = i + 1;
                            ty = j;
                        }
                        else
                        {
                            tx = i;
                            ty = j + 1;
                        }
                    }
                }


                Console.WriteLine("tx= " + tx);
                Console.WriteLine("ty= " + ty);

                if (grid[tx, ty] == n)
                {
                    sea[tx, ty] = grid[tx, ty];
                    h++;
                    Console.WriteLine("Hits = " + h);
                }
                else
                {
                    sea[tx, ty] = grid[tx, ty];

                    tx = i;
                    ty = j;
                }
                Console.WriteLine("Sea Matrix");
                for (int a = 0; a < 10; a++)
                {
                    for (int b = 0; b < 10; b++)
                    {
                        Console.Write(sea[a, b] + " ");
                    }
                    Console.WriteLine();
                }
            }
            if (h == 2)
                Console.WriteLine("2 destroyed");
            else if (h == 3)
                Console.WriteLine("3 destroyed");
            else if (h == 4)
                Console.WriteLine("4 destroyed");
            else if (h == 5)
                Console.WriteLine("5 destroyed");
        }

        public void calculateProbAround(int i,int j)
        {
            if (i  > 1)
            {
                if(sea[i-2,j]==-1 && sea[i-1,j]==-1) //no blocks have been targeted above 
                {
                    prob[i - 2, j] = 1;
                    prob[i - 1, j] = 2;
                }
                else if (sea[i - 2, j] != -1 && sea[i - 1, j] == -1) //block 2 rows above has been targeted
                {
                    prob[i - 1, j] = 1;
                }
                else if (sea[i - 1, j] != -1) //block above has been targeted
                {
                    prob[i - 1, j] = 0;
                }
                else if(sea[i-2,j]!=-1 && sea[i-1,j]!=-1) //both blocks above have been targeted
                {
                    prob[i+1,j]=1;
                }
            }
            else if (i == 1) //target is in 2nd row
            {
                if (sea[i - 1, j] == -1) //no blocks have been targeted above 
                    prob[i - 1, j] = 1;
                else //1 block has been targeted above 
                    prob[i + 1, j] = 1;
            }
            else
            {
                prob[i + 2, j] = 1;
                prob[i + 1, j] = 1;
            }

            if (i < 8)
            {
                if(sea[i+2,j]==-1 && sea[i+1,j]==-1) 
                {
                    prob[i + 2, j] = 1;
                    prob[i + 1, j] = 2;
                }
                else if (sea[i + 2, j] != -1 && sea[i + 1, j] == -1)
                {
                    prob[i + 1, j] = 1;
                }
                else if (sea[i + 1, j] != -1)
                {
                    prob[i + 1, j] = 0;
                }    
                else if(sea[i+2,j]!=-1 && sea[i+1,j]!=-1)
                {
                    prob[i-1,j]=1;
                }
            }
            else if(i == 8)
            {
                if(sea[i+1,j]==-1)
                    prob[i + 1, j] = 1;
                else
                    prob[i-1,j]=1;
            }
            else
            {
                prob[i - 2, j] = 1;
                prob[i - 1, j] = 1;
            }

            if (j > 1)
            {
                if(sea[i,j-1]==-1 && sea[i,j-2]==-1)
                {
                    prob[i, j - 2] = 1;
                    prob[i, j - 1] = 2;
                }
                else if (sea[i, j - 2] != -1 && sea[i, j - 1] == -1)
                {
                    prob[i, j - 1] = 1;
                }
                else if (sea[i, j - 1] != -1)
                {
                    prob[i, j - 1] = 0;
                }
                else if(sea[i,j-2]!=-1 && sea[i,j-1]!=-1)
                {
                    prob[i, j+1] = 1;
                }
            }
            else if (j == 1)
            {
                if(sea[i,j-1]==-1)
                {
                    prob[i, j-1] = 1;
                }
                else
                    prob[i, j+1] = 1;
            }
            else
            {
                prob[i, j + 1] = 1;
                prob[i, j + 2] = 1;
            }

            if (j < 8)
            {
                if(sea[i,j+1]==-1 && sea[i,j+2]==-1)
                {
                    prob[i, j + 2] = 1;
                    prob[i, j + 1] = 2;
                }
                else if (sea[i, j + 2] != -1 && sea[i, j + 1] == -1)
                {
                    prob[i, j + 1] = 1;
                }
                else if (sea[i, j + 1] != -1)
                {
                    prob[i, j + 1] = 0;
                }
                else if(sea[i,j+2]!=-1 && sea[i,j+1]!=-1)
                {
                    prob[i, j-1] = 1;
                }
            }
            else if (j == 8)
            {
                if(sea[i,j+1]==-1)
                {
                    prob[i, j+1] = 1;
                }
                else
                {
                    prob[i, j-1] = 1;
                }
            }

            if (j == 9)
            {
                prob[i, j - 1] = 1;
                prob[i, j - 2] = 1;
            }
            else if (j == 0)
            {
                prob[i, j + 1] = 1;
                prob[i, j + 2] = 1;
            }

            if (i == 9)
            {
                prob[i - 1, j] = 1;
                prob[i - 2, j] = 1;
            }
            else if (i == 0)
            {
                prob[i + 1, j] = 1;
                prob[i + 2, j] = 1;
            }

            Console.WriteLine("Hit Probability");
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    Console.Write(prob[a, b] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
