using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    public class Finder
    {
        static int max = 0;
        public void block(float[] d)
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                if (d[i] > d[max])
                    max = i;
                if (d[i] == d[max])
                {
                    if (rnd.Next(0, 1) ==  1)
                        max = i;
                }
            }
        }

        public int[] select(int[,] sea)
        {
            Random rnd = new Random();
            Random rad = new Random();
            int i, j, k;
            int[] value = new int[2];
            if (max == 0)
            {
                i = rad.Next(0, 2);
                j = rnd.Next(0, 2);
                if (i > 0 && j > 0)
                {
                    if (sea[i - 1, j] == -1 && sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (i > 0)
                {
                    if (sea[i + 1, j] == -1 && sea[i - 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (j > 0)
                {
                    if (sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else
                {
                    if (sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 1)
            {

                j = rad.Next(2, 5);
                i = rnd.Next(0, 2);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        if (i > 0)
                        {
                            if (sea[i - 1, j] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 2)
            {

                j = rad.Next(5, 8);
                i = rnd.Next(0, 2);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        if (i > 0)
                        {
                            if (sea[i - 1, j] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 3)
            {

                j = rad.Next(8, 10);
                i = rnd.Next(0, 2);
                if (i > 0 && j < 9)
                {
                    if (sea[i - 1, j] == -1 && sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (i > 0)
                {
                    if (sea[i + 1, j] == -1 && sea[i - 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (j < 9)
                {
                    if (sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else
                {
                    if (sea[i + 1, j] == -1 && sea[i + 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 4)
            {

                i = rad.Next(2, 5);
                j = rnd.Next(0, 2);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i - k, j] == -1 && sea[i, j + k] == -1)
                    {
                        if (j > 0)
                        {
                            if (sea[i, j - 1] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 5)
            {

                i = rad.Next(2, 5);
                j = rnd.Next(2, 5);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 6)
            {

                i = rad.Next(2, 5);
                j = rnd.Next(5, 8);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 7)
            {

                i = rad.Next(2, 5);
                j = rnd.Next(8, 10);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i - k, j] == -1 && sea[i, j - k] == -1)
                    {
                        if (j < 9)
                        {
                            if (sea[i, j + 1] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 8)
            {
                i = rad.Next(5, 8);
                j = rnd.Next(0, 2);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i - k, j] == -1 && sea[i, j + k] == -1)
                    {
                        if (j > 0)
                        {
                            if (sea[i, j - 1] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 9)
            {
                i = rad.Next(5, 8);
                j = rnd.Next(2, 5);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 10)
            {
                i = rad.Next(5, 8);
                j = rnd.Next(5, 8);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i + k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 11)
            {
                i = rad.Next(5, 8);
                j = rnd.Next(8, 10);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i + k, j] == -1 && sea[i - k, j] == -1 && sea[i, j - k] == -1)
                    {
                        if (j < 9)
                        {
                            if (sea[i, j + 1] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 12)
            {
                i = rad.Next(8, 10);
                j = rnd.Next(0, 2);
                if (i < 9 && j > 0)
                {
                    if (sea[i - 1, j] == -1 && sea[i + 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (i < 9)
                {
                    if (sea[i + 1, j] == -1 && sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (j > 0)
                {
                    if (sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else
                {
                    if (sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j + 1] == -1 && sea[i, j + 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }
            else if (max == 13)
            {
                i = rad.Next(8, 10);
                j = rnd.Next(2, 5);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        if (i < 9)
                        {
                            if (sea[i + 1, j] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else if (max == 14)
            {
                j = rad.Next(5, 8);
                i = rnd.Next(8, 10);
                for (k = 0; k < 3; k++)
                {
                    if (sea[i - k, j] == -1 && sea[i, j - k] == -1 && sea[i, j + k] == -1)
                    {
                        if (i < 9)
                        {
                            if (sea[i + 1, j] == -1)
                            {
                                value[0] = i;
                                value[1] = j;
                            }
                        }
                        else
                        {
                            value[0] = i;
                            value[1] = j;
                        }
                    }
                }
            }
            else
            {
                i = rad.Next(8, 10);
                j = rnd.Next(9, 10);
                if (i < 9 && j < 9)
                {
                    if (sea[i - 1, j] == -1 && sea[i + 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (i < 9)
                {
                    if (sea[i + 1, j] == -1 && sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else if (j < 9)
                {
                    if (sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j + 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
                else
                {
                    if (sea[i - 1, j] == -1 && sea[i - 2, j] == -1 && sea[i, j - 1] == -1 && sea[i, j - 2] == -1)
                    {
                        value[0] = i;
                        value[1] = j;
                    }
                }
            }

            return value;
        }
    }
}
