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
        
        Target()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sea[i, j] = -1;
                }
            }
        }

        public void calc(int[,] grid, int i, int j)
        {
            //create prob array with all zeroes somewhere bro
            prob[i][j]=0;
            int n=grid[i,j];
            while(n>0){
                calculateProbAround(i,j); //calculates probabilty around recently hit block
                //select next target based on largest probability around recent target
                if(i>0 && j>0 && i<9 && j<9){
                    int nextTarget=Math.max(Math.max(prob[i][j-1],prob[i][j+1]),Math.max(prob[i-1][j],prob[i+1][j]));
                }   
                else if(j==0){
                    if(i==0)
                        int nextTarget=Math.max(prob[i][j+1],prob[i+1][j]);
                    else if(i==9)
                        int nextTarget=Math.max(prob[i][j+1],prob[i-1][j]);
                    else
                        int nextTarget=Math.max(Math.max(prob[i][j+1],prob[i-1][j]),prob[i+1][j]);
                }
                else if(j==9){
                    if(i==0)
                        int nextTarget=Math.max(prob[i][j-1],prob[i+1][j]);
                    else if(i==9)
                        int nextTarget=Math.max(prob[i][j-1],prob[i-1][j]);
                    else
                        int nextTarget=Math.max(Math.max(prob[i][j-1],prob[i-1][j]),prob[i+1][j]);
                }
                else if(j>0 && j<9){
                    if(i==0)
                        int nextTarget=Math.max(Math.max(prob[i][j-1],prob[i+1][j]),prob[i][j+1]);
                    else if(i==9)
                        int nextTarget=Math.max(Math.max(prob[i][j-1],prob[i-1][j]),prob[i][j+1]);
                }
                //get indices of nextTarget in prob[], say x and y, then:
                //if(grid[x][y]==n) { n--; continue; }
                //else { break; }
            }
        }

        public void calculateProbAround(int i,int j)
        {
            if (i  > 1)
                {
                    if(sea[i-2,j]==sea[i-1,j]==-1) //no blocks have been targeted above 
                    {
                        prob[i - 2, j] = 1;
                        prob[i - 1, j] = 2;
                    }
                    else if(sea[i-2,j]!=-1 && sea[i-1,j]==-1) //block 2 rows above has been targeted
                    {
                        prob[i - 1, j] = 1;
                    }
                    else if(sea[i-2,j]!=-1 && sea[i-1,j]!=-1) //both blocks above have been targeted
                    {
                        prob[i+1,j]=1;
                    }
                }
                else if(i  == 1) //target is in 2nd row
                {
                    if(sea[i-1,j]==-1) //no blocks have been targeted above 
                        prob[i - 1, j] = 1;
                    else //1 block has been targeted above 
                        prob[i + 1, j] = 1;    
                }

                if (i < 8)
                {
                    if(sea[i+2,j]==sea[i+1,j]==-1) 
                    {
                        prob[i + 2, j] = 1;
                        prob[i + 1, j] = 2;
                    }
                    else if(sea[i+2,j]!=-1 && sea[i+1,j]==-1) 
                    {
                        prob[i + 1, j] = 1;
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

                if (j > 1)
                {
                    if(sea[i,j-1]==sea[i,j-2]==-1)
                    {
                        prob[i, j - 2] = 1;
                        prob[i, j - 1] = 2;
                    }
                    else if(sea[i,j-2]!=-1 && sea[i,j-1]==-1)
                    {
                        prob[i, j-1] = 1;
                    }
                    else if(sea[i,j-2]!=-1 && sea[i,j-1]!=-1)
                    {
                        prob[i, j+1] = 1;
                    }
                }
                else (j == 1)
                {
                    if(sea[i,j-1]==-1)
                    {
                        prob[i, j-1] = 1;
                    }
                    else
                        prob[i, j+1] = 1;
                }

                if (j < 8)
                {
                    if(sea[i,j+1]==sea[i,j+2]==-1)
                    {
                        prob[i, j + 2] = 1;
                        prob[i, j + 1] = 2;
                    }
                    else if(sea[i,j+2]!=-1 && sea[i,j+1]==-1)
                    {
                        prob[i, j+1] = 1;
                    }
                    else if(sea[i,j+2]!=-1 && sea[i,j+1]!=-1)
                    {
                        prob[i, j-1] = 1;
                    }
                }
                else (j == 8)
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
        }

    }
}
