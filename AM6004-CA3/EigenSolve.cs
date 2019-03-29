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
            double[] v = new double[n];
            double[] u = new double[n];
            double[] z = new double[n];
            
            // Step 1
            for (int k = 0; k < n - 2; k++)
            {
                // Step 2
                double q = 0;
                for (int i = k + 1; i < n; i++)
                {
                    q += (A[i, k] * A[i, k]);
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
                for (int i = k; i < n; i++)
                {
                    double sum = 0;
                    for (int j = k + 1; j < n; j++)
                    {
                        sum += (A[i, j] * v[j]);
                    }

                    u[i] = sum / rsq;
                }

                // Step 7
                double prod = 0;
                for (int i = k + 1; i < n; i++)
                {
                    prod += (v[i] * u[i]);
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
                for (int j = k + 2; j < n; j++)
                {
                    A[k, j] = A[j, k] = 0;
                }

                // Step 14
                A[k + 1, k] = A[k + 1, k] - (v[k + 1] * z[k]);
                A[k, k + 1] = A[k + 1, k];
            }
        }

        static public double[] QR(double[] a, double[] b, int n, int MaxIt)
        {
            int k = 0;
            double[] dVect = (double[])a.Clone();
            double[] zVect = new double[n - 1];
            double[] xVect = new double[n];
            double[] cVect = new double[n];
            double[] sigmaVect = new double[n];
            double[] qVect = new double[n];
            double[] yVect = new double[n];
            double[] rVect = new double[n - 2];


            while (k++ < MaxIt)
            {
                // Step 8
                double b2 = -(a[n - 2] + a[n - 1]);
                double c = (a[n - 1] * a[n - 2]) - (b[n - 1] * b[n - 1]);
                double d = Math.Sqrt((b2 * b2) - (4 * c));

                // Step 9
                double mu1;
                double mu2;
                if (b2 > 0)
                {
                    mu1 = -(2 * c) / (b2 + d);
                    mu2 = -(b2 + d) / 2;
                } else
                {
                    mu1 = (d - b2) / 2;
                    mu2 = (2 * c) / (d - b2);
                }

                double sigma = (Math.Abs(mu1 - a[n - 1]) < Math.Abs(mu2 - a[n - 1]))
                    ? mu1
                    : mu2;

                for (int i = 0; i < dVect.Length; i++)
                {
                    dVect[i] = a[i] - sigma;
                }

                // Step 14
                xVect[0] = dVect[0];
                yVect[0] = b[0];

                // Step 15
                for (int i = 1; i < n; i++)
                {
                    zVect[i - 1] = Math.Sqrt((xVect[i - 1] * xVect[i - 1]) + (b[i] * b[i]));
                    cVect[i] = xVect[i - 1] / zVect[i - 1];
                    sigmaVect[i] = b[i] / zVect[i - 1];

                    double denominator = Math.Sqrt((b[i] * b[i]) + (xVect[i - 1] * xVect[i - 1]);
                    double si = b[i] / denominator;
                    qVect[i - 1] = (cVect[i] * yVect[i - 1]) + (si * dVect[i]);

                    double ci = xVect[i - 1] / denominator;
                    xVect[i] = -(sigma * yVect[i - 1]) + (ci * dVect[i]);

                    if (i != (n - 1))
                    {
                        rVect[i - 1] = sigmaVect[i] * b[i + 1];
                        yVect[i] = cVect[i] * b[i + 1]; 
                    }
                }

                // Step 16
                zVect[n - 1] = xVect[n - 1];
                a[0] = (sigmaVect[1] * qVect[0]) + cVect[1] * zVect[0];
                b[0] = sigmaVect[1] * zVect[1];

                //Step 17
                for (int i = 1; i < n; i++)
                {
                    a[i] = (sigmaVect[i + 1] * qVect[i]) + (cVect[i] * cVect[i + 1] * zVect[i]);
                    b[i] = sigmaVect[i + 1] * zVect[i + 1];
                }

                // Step 18
                a[n - 1] = cVect[n - 1] * zVect[n - 1];
            }

            // Copy a and b to the outputVector
            double[] outPutVect = new double[2*n - 1];
            for (int i = 0; i < n; i++)
            {
                outPutVect[i] = a[i];
            }

            for (int i = 0; i < b.Length; i++)
            {
                outPutVect[i + n] = b[i];
            }

            return outPutVect;
            
        }
    }
}
