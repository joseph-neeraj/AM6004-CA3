using System;

namespace AM6004_CA3
{
    class MatrixOps
    {
        // Multiplies a Matrix A and a vector x. 
        static public double[] MatrixVectProd(double[,] A, double[] x, int n)
        {
            double[] y = new double[n];
            int j = 0;
            while (j < n)
            {
                int i = 0;
                while (i < n)
                {
                    y[j] = y[j] + (A[j, i] * x[i]);
                    i++;
                }
                j++;
            }
            return y;
        }
        // returns the the smallest index of x whose absolute value is equal to the supremum norm.
        static public int SupNormInd(double[] x, int n)
        {
            int p = 0;
            double check = Math.Abs(x[0]);
            for(int i = 0; i< n; i++)
            {
                if (check < Math.Abs(x[i]))
                {
                    check = Math.Abs(x[i]);
                    p = i;
                }
            }
            return p;
        }
        // Multiples a Vector x by a scalar lambda
        static public double[] VectScalMult(double[] x, double lambda, int n)
        {
            double[] z = new double[n];
            Array.Copy(x, z, n);
            int j = 0;
            while (j < n)
            {
                z[j] = z[j] * lambda;
                j++;
            }
            return z;
        }
        // Adds vectors x and y
        static public double[] VectAdd(double[] x, double[] y, int n)
        {
            double[] z = new double[n];
            int j = 0;
            while (j < n)
            {
                z[j] = x[j] + y[j];
                j++;
            }
            return z;
        }
        // Appends x to A to return the augmented matrix B.
        static public double[,] MatrixVectApp(double[,] A, double[] x, int n)
        {
            double[,] B = new double[n, n + 1];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    B[i, j] = A[i, j];
                }
            }
            for (int i = 0; i < n;i++)
            {
                B[i, n] = x[i];
            }
            return B;
            
        }
        // Returns A - qI
        static public double[,] MatrixLessQ(double[,] A, double q, int n)
        {
            double[,] B = new double[n, n];
            B = A.Clone() as double[,];
            for (int i = 0; i < n; i++)
            {
                B[i, i] = A[i,i]-q;
            }
            return B;
        }

        static public double DotProduct(double[] x, double[] y, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += x[i] * y[i];
            }

            return sum;
        }

        public static void PrettyPrint(double[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("{0:0.00}" + "    ", A[i, j]);
                }

                Console.WriteLine();
            }
        }

        internal static double[,] IdentityMatrix(int n)
        {
            double[,] identity = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                identity[i, i] = 1;
            }

            return identity;
        }
    }
}