using System;
using System.Linq;

namespace Pyramid_Slide_Down
{
    class PyramidSlideDown
    {

        public static int LongestSlideDown(int[][] pyramid)
        {
            for (int row = 1; row < pyramid.Length; row++) {
                for (int col = 0; col < pyramid[row].Length; col++) {
                    int left =  col == 0 ? 0 : pyramid[row-1][col-1];
                    int right = pyramid[row-1].Length == col ? 0 : pyramid[row-1][col];

                    pyramid[row][col] += left > right ? left : right;
                }
            }

            return pyramid[pyramid.Length-1].Max();
        }
    }
}
