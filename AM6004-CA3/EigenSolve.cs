using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM6004_CA3
{
    class EigenSolve
    {
        static public void Householder(ref double[,] A, int n)
        {
            for (int k = 0; k < n - 2; k++)
            {
                double q = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    q += A[i, k] * A[i, k];
                }

                double alpha;
                if (A[k + 1, k] == 0)
                {
                    alpha = -Math.Sqrt(q);
                } else
                {
                    alpha = -((Math.Sqrt(q) * A[k + 1, k]) / Math.Abs(A[k + 1, k]));
                }

                double rsq = (alpha * alpha) - (alpha * A[k + 1, k]);
            }
        }
    }
}
