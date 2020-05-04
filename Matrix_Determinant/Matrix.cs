using System;

namespace Matrix_Determinant
{
    public class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length == 0) return 0;
            else if (matrix.Length == 1) return matrix[0][0];
            else if (matrix.Length == 2) return matrix[0][0]*matrix[1][1]-matrix[0][1]*matrix[1][0];
            
            int det = 0;
            int operand = 1;
            for(int i = 0; i < matrix.Length; i++)
            {
                det += operand * matrix[0][i] * Determinant(minor(matrix,0,i));
                operand *= -1;
            }

            return det;
        }

        public static int[][] minor(int[][] matrix, int i, int j)
        {
            int[][] minor = new int[matrix.Length-1][];
            for (int m = 0; m < minor.Length; m++) minor[m]=new int[minor.Length];

            int a = 0, b = 0, aa = 0, bb = 0;
            while (a < minor.Length) {
                if (aa == i) {
                    aa++;
                }
                b=0; bb=0;
                while (b < minor.Length) {
                    if (bb == j) {
                        bb++;
                    }

                    minor [a][b] = matrix[aa][bb];
                    b++;bb++;
                }
                a++;aa++;
            }

            return minor;
        }
    }
}