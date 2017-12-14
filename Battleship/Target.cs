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

        public int calc(int[,] grid, int i, int j, int shots)
        {
            prob[i,j]=-1;
            int h=1,n=grid[i,j];
            int tx=i,ty=j;
            sea[i, j] = n;
            while(h<n)
            {
                if (sea[i, j] == 1)
                { 
                    if (tx != i)
                    {
                        j = ty;
                        if (tx < i)
                        {
                            i = tx;
                            tx--;
                        }
                        else
                        {
                            i = tx;
                            tx++;
                        }
                    }
                    else
                    {
                        i = tx;
                        if (ty < j)
                        {
                            j = ty;
                            ty--; 
                        }
                        else if (ty > j)
                        {
                            j = ty;
                            ty++;
                        }
                    }
                }

                else
                {
                    calculateProbAround(i, j); //calculates probabilty around recently hit block
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

                    if (sea[i - 1, j] != -1 && sea[i + 1, j] != -1 && sea[i, j + 1] != -1 && sea[i, j - 1] != -1)
                    {
                        tx = i;
                        ty = j;
                        Console.WriteLine("tx = " + tx);
                        Console.WriteLine("ty = " + ty);
                        sea[i, j] = 1;
                        if (sea[i - 1, j] == 1)
                        {
                            while (sea[tx, ty] != -1)
                            {
                                tx--;
                            }
                        }
                        if (sea[i + 1, j] == 1)
                        {
                            while (sea[tx, ty] != -1)
                            {
                                tx++;
                            }
                        }
                        if (sea[i, j - 1] == -1)
                        {
                            while (sea[tx, ty] != 1)
                            {
                                ty--;
                            }
                        }
                        if (sea[i, j + 1] == -1)
                        {
                            while (sea[tx, ty] != 1)
                            {
                                ty++;
                            }
                        }
                    } 
                }

                if (grid[tx, ty] == n)
                {
                    Console.WriteLine("HIT!!!");
                    sea[tx, ty] = grid[tx, ty];
                    sea[i, j] = 1;
                    h++;
                    shots++;
                    Console.WriteLine("Shots = " + shots);
                }
                else if (sea[tx,ty] != -1)
                {
                }
                else
                {
                    Console.WriteLine("MISS!!!");
                    sea[tx, ty] = grid[tx, ty];
                    shots++;
                    tx = i;
                    ty = j;
                    Console.WriteLine("Shots = " + shots);
                }
                Console.WriteLine("tx = "+tx);
                Console.WriteLine("ty = "+ty);
            }
            sea[tx, ty] = 1;
            if (h == 2)
                Console.WriteLine("2 destroyed");
            else if (h == 3)
                Console.WriteLine("3 destroyed");
            else if (h == 4)
                Console.WriteLine("4 destroyed");
            else if (h == 5)
                Console.WriteLine("5 destroyed");
            return shots;
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

        }
    }
}
