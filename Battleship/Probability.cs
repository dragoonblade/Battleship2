using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    class Probability
    {

        public int[,] prob = new int[10, 10];
        float[] p = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public Probability()
        {
            int[,] probo = {{2,3,4,4,4,4,4,4,3,2},
                          {3,4,5,5,5,5,5,5,4,3},
                          {4,5,6,6,6,6,6,6,5,4},
                          {4,5,6,6,6,6,6,6,5,4},
                          {4,5,6,6,6,6,6,6,5,4},
                          {4,5,6,6,6,6,6,6,5,4},
                          {4,5,6,6,6,6,6,6,5,4},
                          {4,5,6,6,6,6,6,6,5,4},
                          {3,4,5,5,5,5,5,5,4,3},
                          {2,3,4,4,4,4,4,4,3,2}};
            prob = probo;
        }

        public void miss(int i, int j, int[,] sea)
        {
            prob[i, j] = 0;

            if (i != 9)
            {
                if (i > 1)
                {
                    prob[i - 2, j] -= 1;
                    prob[i - 1, j] -= 2;
                }
                else if (i > 0)
                {
                    prob[i - 1, j] -= 1;
                }
                else
                {
                    prob[i + 1, j] -= 1;
                    prob[i + 2, j] -= 1;
                }
            }

            if (i != 0)
            {
                if (i < 8)
                {
                    prob[i + 2, j] -= 1;
                    prob[i + 1, j] -= 2;
                }
                else if (i < 9)
                {
                    prob[i + 1, j] -= 1;
                }
                else
                {
                    prob[i - 1, j] -= 1;
                    prob[i - 2, j] -= 1;
                }
            }

            if (j != 9)
            {
                if (j > 1)
                {
                    prob[i, j - 2] -= 1;
                    prob[i, j - 1] -= 2;
                }
                else if (j > 0)
                {
                    prob[i, j - 1] -= 1;
                }
                else
                {
                    prob[i, j + 1] -= 1;
                    prob[i, j + 2] -= 1;
                }
            }

            if (j != 0)
            {
                if (j < 8)
                {
                    prob[i, j + 2] -= 1;
                    prob[i, j + 1] -= 2;
                }
                else if (j < 9)
                {
                    prob[i, j + 1] -= 1;
                }
                else
                {
                    prob[i, j - 1] -= 1;
                    prob[i, j - 2] -= 1;
                }
            }
        }

        public float[] density()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    p[0] += prob[i, j];
                }
            }
            p[0] = p[0] / 4;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    p[1] += prob[i, j];
                }
            }
            p[1] = p[1] / 6;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    p[2] += prob[i, j];
                }
            }
            p[2] = p[2] / 6;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 8; j < 10; j++)
                {
                    p[3] += prob[i, j];
                }
            }
            p[3] = p[3] / 4;
            for (int i = 2; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    p[4] += prob[i, j];
                }
            }
            p[4] = p[4] / 6;
            for (int i = 2; i < 5; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    p[5] += prob[i, j];
                }
            }
            p[5] = p[5] / 9;
            for (int i = 2; i < 5; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    p[6] += prob[i, j];
                }
            }
            p[6] = p[6] / 9;
            for (int i = 2; i < 5; i++)
            {
                for (int j = 8; j < 10; j++)
                {
                    p[7] += prob[i, j];
                }
            }
            p[7] = p[7] / 6;
            for (int i = 5; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    p[8] += prob[i, j];
                }
            }
            p[8] = p[8] / 6;
            for (int i = 5; i < 8; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    p[9] += prob[i, j];
                }
            }
            p[9] = p[9] / 9;
            for (int i = 5; i < 8; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    p[10] += prob[i, j];
                }
            }
            p[10] = p[10] / 9;
            for (int i = 5; i < 8; i++)
            {
                for (int j = 8; j < 10; j++)
                {
                    p[11] += prob[i, j];
                }
            }
            p[11] = p[11] / 6;
            for (int i = 8; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    p[12] += prob[i, j];
                }
            }
            p[12] = p[12] / 4;
            for (int i = 8; i < 10; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    p[13] += prob[i, j];
                }
            }
            p[13] = p[13] / 6;
            for (int i = 8; i < 10; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    p[14] += prob[i, j];
                }
            }
            p[14] = p[14] / 6;
            for (int i = 8; i < 10; i++)
            {
                for (int j = 8; j < 10; j++)
                {
                    p[15] += prob[i, j];
                }
            }
            p[15] = p[15] / 4;
            return p;

        }
    }
}
