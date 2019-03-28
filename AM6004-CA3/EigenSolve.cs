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
            double[] v = new double[n - 1];
            double[] u = new double[n];
            double[] z = new double[n];

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

                // Step 5 
                v[k] = 0;
                v[k + 1] = A[k + 1, k] - alpha;

                for (int i = k + 2; i < n; i++)
                {
                    v[i] = A[i, k];
                }

                // Step 6
                for (int i = k; k < n; i++)
                {
                    double sum = 0;
                    for (int j = k + 1; j < n; j++)
                    {
                        sum += A[i, j] * v[j];
                    }

                    u[i] = sum;
                }

                // Step 7
                double prod = 0;
                for (int i = k + 1; i < n; i++)
                {
                    prod += v[i] * u[i];
                }

                // Step 8 
                for (int i = k; i < n; i++)
                {
                    z[i] = u[i] - (prod / (2 * rsq)) * v[i];
                }
                
            }
        }
    }
}
