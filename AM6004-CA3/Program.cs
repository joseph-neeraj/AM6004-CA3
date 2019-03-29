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

            EigenSolve.Householder(ref inputMatrix, 3);

            string houseHolderOutput = MatrixOps.PrettyString(inputMatrix);
            File.WriteAllText("output.txt", houseHolderOutput);


            Console.WriteLine("Done !!   Output in bin\\debug\\output.txt");
            Console.ReadLine();
        }
    }
}
