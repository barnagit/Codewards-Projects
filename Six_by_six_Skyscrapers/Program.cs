using System;
using System.Collections.Generic;
using System.Linq;

namespace Six_by_six_Skyscrapers
{
    class Skyscrapers
    {
        public static int[][] SolvePuzzle(int[] clues)
        {
            var c = new Clues(clues);
            var m = new Matrix();

            for (int i = 0; i < 6; i++) {

                // iterate on columns
                int vTop = c.Get(i,-1).Val;
                int vBottom = c.Get(i,6).Val;

                if (vTop == 6) 
                    for (int j = 0; j < 6; j++) 
                        m.Get(i,j).Values.RemoveAll(s => s != j + 1);
                else if (vTop < 6 && vTop > 1)
                    for (int j = 0; j < 6; j++)
                        m.Get(i,j).Values.RemoveAll(s => s > 7-vTop + j);
                else if (vTop == 1) {
                    m.Get(i,0).Values.RemoveAll(s => s != 6);
                    for (int j = 1; j < 6; j++)
                        m.Get(i,j).Values.Remove(6);
                }

                if (vBottom == 6)
                    for (int j = 0; j < 6; j++)
                        m.Get(i,5-j).Values.RemoveAll(s => s != j + 1);
                else if (vBottom < 6 && vBottom > 1)
                    for (int j = 0; j < 6; j++)
                       m.Get(i,5-j).Values.RemoveAll(s => s > 7-vBottom + j);
                else if (vBottom == 1) {
                    m.Get(i,5).Values.RemoveAll(s => s != 6);
                    for (int j = 1; j < 6; j++)
                        m.Get(i,5-j).Values.Remove(6);
                }

                // iterate on rows.
                int vRight = c.Get(6,i).Val;
                int vLeft = c.Get(-1,i).Val;

                if (vRight == 6)
                    for (int j=0; j<6; j++)
                        m.Get(5-j,i).Values.RemoveAll(s => s != j + 1);
                else if (vRight < 6 && vRight > 1) 
                    for (int j = 0; j < 6; j++)
                        m.Get(5-j,i).Values.RemoveAll(s => s > 7-vRight + j);
                else if (vRight == 1) {
                    m.Get(5,i).Values.RemoveAll(s => s != 6);
                    for (int j = 1; j < 6; j++)
                        m.Get(5-j,i).Values.Remove(6);
                }

                if (vLeft == 6)
                    for (int j = 0; j < 6; j ++)
                        m.Get(j,i).Values.RemoveAll(s => s != j + 1);
                else if (vLeft <6 && vLeft > 1)
                    for (int j = 0; j < 6;j++)
                        m.Get(j,i).Values.RemoveAll(s => s > 7-vLeft + j);
                else if (vLeft == 1) {
                    m.Get(i,0).Values.RemoveAll(s => s != 6);
                    for (int j = 1; j <6; j++) 
                        m.Get(j,i).Values.Remove(6);
                }

            }
            return null;
        }
    }

    class Clues
    {
        Clue[] _clues = new Clue[24];
        public Clues(int[] clues) 
        {
            int i = 0;

            // top row
            for (; i < 6; i++) {
                _clues[i] = new Clue() {Col = i, Row = -1, Val = clues[i]};
            }

            // right col i: 6,7,8,9,10,11
            for(; i<12;i++) {
                _clues[i] = new Clue() {Col = 6, Row = i % 6, Val = clues[i]};
            }

            // bottom row i: 12,13,14,15,16,17
            for (; i<18;i++) {
                _clues[i] = new Clue() {Col = 5 - i % 6, Row = 6, Val = clues[i]};
            }

            // left col, i: 18,19,20,21,22,23
            for (; i<24;i++) {
                _clues[i] = new Clue() {Col = -1, Row = 5 - i % 6, Val = clues[i]};
            }
        }

        public Clue Get(int col, int row) {
            return _clues.First(c => c.Col == col && c.Row == row);
        }

    }

    class Matrix 
    {
        Cell[] _cells = new Cell[36];

        public Matrix() 
        {
            for (int i = 0; i < _cells.Length; i++)
                _cells[i] = new Cell();
        }

        public Cell Get(int col, int row) {
            return _cells[row*6+col];
        }
    }

    class Cell
    {
   
        private List<int> _values = new List<int> {1,2,3,4,5,6};
        public List<int> Values {get {return _values;}}

    }

    class Clue
    {
        public int Col {get; internal set;}
        public int Row {get; internal set;}
        public int Val {get; internal set;}
    }
}
