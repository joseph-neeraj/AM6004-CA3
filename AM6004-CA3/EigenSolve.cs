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
                // Step 2
                double q = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    q += A[i, k] * A[i, k];
                }


                // Step 3
                double alpha;
                if (A[k + 1, k] == 0)
                {
                    alpha = -Math.Sqrt(q);
                } else
                {
                    alpha = -((Math.Sqrt(q) * A[k + 1, k]) / Math.Abs(A[k + 1, k]));
                }

                // Step 4
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

                // Step 9
                for (int l = k + 1; l < n; l++)
                {
                    // Step 10
                    for (int i = l + 1; i < n; i++)
                    {
                        A[i, l] = A[i, l] - (v[l] * z[i]) - (v[i] * z[l]);
                        A[l, i] = A[i, l];
                    }

                    // Step 11
                    A[l, l] = A[l, l] - (2 * v[l] * z[l]);
                }

                // Step 12
                A[n - 1, n - 1] = A[n - 1, n - 1] - (2 * v[n - 1] * z[n - 1]);

                // Step 13
                for (int j = k + 2; j <= n; j++)
                {
                    A[k, j] = A[j, k] = 0;
                }

                // Step 14
                A[k + 1, k] = A[k + 1, k] - (v[k + 1] * z[k]);
                A[k, k + 1] = A[k + 1, k];
            }

            MatrixOps.PrettyPrint(A);
        }

        static public double[] QR(double[] a, double[] b, int n, int MaxIt)
        {
            double[,] P = MatrixOps.IdentityMatrix(n);
            for (int k = 1; k <= n; k++)
            {
                double denominator = Math.Sqrt(b[k + 1] * b[k + 1] + a[k] * a[k]);
                double s = b[k + 1] / denominator;
                double c = a[k] / denominator;

                P[k]
            }
            
        }
    }
}
