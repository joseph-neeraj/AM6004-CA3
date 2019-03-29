using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AM6004_CA3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] inputMatrix = new double[3, 3]
            {
                {12, 10, 4},
                {10, 8, -5},
                {4, -5, 3}
            };

            int n = inputMatrix.GetLength(0);

            EigenSolve.Householder(ref inputMatrix, 3);

            double[] a = MatrixOps.GetMainDiagonal(inputMatrix);
            double[] b = MatrixOps.GetSubDiagonal(inputMatrix);

            int maxIt = 20;
            double[] output = EigenSolve.QR(a, b, n, maxIt);

            // Build the output
            double[] resultA = new double[n];
            double[] resultB = new double[n - 1];
            Array.Copy(output, resultA, n);
            Array.Copy(output, n, resultB, 0, n - 1);

            // Build a matrix from the output values 
            // so that a proper string representation can be built
            double[,] outMatrix = new double[n, n];
            for (int i = 0; i < resultA.Length; i++)
            {
                outMatrix[i, i] = resultA[i];
                if (i != (n - 1))
                {
                    outMatrix[i, i + 1] = resultB[i];
                }
            }

            string outString = MatrixOps.PrettyString(outMatrix);
            File.WriteAllText("output.txt", outString);



            Console.WriteLine("Done !!   Output in bin\\debug\\output.txt");
            Console.ReadLine();
        }
    }
}
