using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Six_by_six_Skyscrapers
{
    class Skyscrapers
    {
        private static Clues c;
        private static Matrix m;

        public static int[][] SolvePuzzle(int[] clues)
        {
            c = new Clues(clues);
            m = new Matrix();

            #region remove the obvious
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
                    m.Get(0,i).Values.RemoveAll(s => s != 6);
                    for (int j = 1; j <6; j++) 
                        m.Get(j,i).Values.Remove(6); 
                }

            }
            #endregion
            
            CleanUp(m);

            //Console.WriteLine(m);
            
            int k = 0;
            if (m.Cells.Count(c => c.Values.Count() > 1) > 0) 
                while (m.Cells.Aggregate(0,(i,c) => i+c.Values.Count()) > k
                    && Solution == null)
                {
                    Guess(m,k++);
                }

            Console.WriteLine(Solution);

            return null;
        }

        static Matrix Solution;

        static bool Guess(Matrix origin, int skip, int level = 0) {

/*             string[] spaces = new string[skip];
            for (int spacesIndex = 0; spacesIndex < spaces.Length; spacesIndex++) spaces[spacesIndex] = "-";
            Console.WriteLine("{0}{1}",String.Join("",spaces), level); */

            // make a copy
            Matrix matrix = origin.Copy();
            // make the most obvious guess (less possibilities)
            var cells = matrix.Cells.Where(cc => cc.Values.Count > 1).OrderBy(c => c.Values.Count);
            Cell cell = cells.First();
            int next = 0;
            int skipped = 0;
            for (int i = 0; i < skip; i++) {
                cell = cells.Skip(next).First();
                if (cell.Values.Count() > skipped) {
                    skipped ++;
                } else {
                    next++;
                    skipped = 0;
                }
            }
            int myValue = cell.Values.ElementAt(Math.Max(skipped-1,0));
            cell.Values.RemoveAll(v => v != myValue);

            // calculate until possible
            CleanUp(matrix);

            //Console.WriteLine(matrix.ToString());

            // false if there is 0 number anywhere
            if (matrix.Cells.Where(ccc => ccc.Values.Count == 0).Count() > 0 || !matrix.IsValid() || !matrix.IsCorrect(c)) return false;
            // make a next guess if needed.
            // if there are cells with more than 1 value in it, next Guess is needed
            else if (matrix.Cells.Where(cccc => cccc.Values.Count()>1).Count() > 0) {
                int j = 0;
                // while we have more items to reduce than skip, make a next guess and if that is false, increase skip
                while (matrix.Cells.Where(w => w.Values.Count()>1).Aggregate(0,(i,c) => i+c.Values.Count()) > j && Solution == null)
                    if (!Guess(matrix,j, level+1)) j++;
            } else {
                Solution = matrix;
                Solution.IsCorrect(c);
                return true;
            }

            return false;
        }

        static void CleanUp(Matrix m) 
        {
            #region find single present items
                // in every row find the number which is present only in one cell of that row

                // take every row
                for (int i = 0; i < 6; i++) {
                    // for every number take..
                    for (int n = 1; n < 7; n++) {
                        int c = 0;
                        int col = -1;
                        // count them through columns
                        for (int j = 0; j < 6; j++) {
                            if(m.Get(j,i).Values.Contains(n)) {
                                c++;
                                col = j;
                            }
                        }

                        // and if it is present only once
                        if (c == 1) {
                            // remove every other number from that cell.
                            m.Get(col, i).Values.RemoveAll(s => s != n);
                        }
                    }
                }


                // in every col find the number which is present only in one cell of that col

                // take every col
                for (int j = 0; j < 6; j++) {
                    // for every number take...
                    for (int n = 1; n <7; n++) {
                        int c = 0;
                        int row = -1;
                        // count them through the rows
                        for (int i = 0; i < 6; i++) {
                            if (m.Get(j,i).Values.Contains(n)) {
                                c++;
                                row = i;
                            }
                        }

                        // and if it is present only once
                        if (c == 1) {
                            // remove every other number from that cell.
                            m.Get(j, row).Values.RemoveAll(s => s != n);
                        }
                    }
                }

            #endregion

            #region find lone items

            // after removal find thos cells have only one item in it
            // and remove that number from the row and col the cell is sitting in

            bool didWeRemoveAnything = false;
            for (int col = 0; col < 6; col++) 
                for (int row = 0; row < 6; row++)
                    if (m.Get(col,row).Values.Count == 1) {
                        for (int i = 0; i < 6; i++) {
                            if (i != col) if (m.Get(i,row).Values.Remove(m.Get(col,row).Values.First())) didWeRemoveAnything = true;
                            if (i != row) if(m.Get(col,i).Values.Remove(m.Get(col,row).Values.First())) didWeRemoveAnything = true;;
                        }
                    }
                         
            if (didWeRemoveAnything) CleanUp(m);

            #endregion
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
        public IEnumerable<Cell> Cells
        {
            get {return _cells;}
        }

        public Matrix() 
        {
            for (int i = 0; i < _cells.Length; i++)
                _cells[i] = new Cell();
        }

        public Cell Get(int col, int row)
        {
            return _cells[row*6+col];
        }

        public override string ToString() 
        {
              return  String.Join(' ',_cells.Take(6).Select(c => c.ToString()))
               + Environment.NewLine + String.Join(' ',_cells.Skip(6).Take(6).Select(c => c.ToString()))
               + Environment.NewLine + String.Join(' ',_cells.Skip(12).Take(6).Select(c => c.ToString()))
               + Environment.NewLine + String.Join(' ',_cells.Skip(18).Take(6).Select(c => c.ToString()))
               + Environment.NewLine + String.Join(' ',_cells.Skip(24).Take(6).Select(c => c.ToString()))
               + Environment.NewLine + String.Join(' ',_cells.Skip(30).Take(6).Select(c => c.ToString()));
        }

        public Matrix Copy() {
            Matrix n = new Matrix();
            
            for (int i = 0; i < n._cells.Length; i++) {
                 n._cells[i].Values.Clear();
                 n._cells[i].Values.AddRange(this._cells[i].Values);
            }

            return n;
        }

        public bool IsValid()
        {
            for (int i = 0; i < 6; i++) {
                int [] rowVals = new int[6];
                int [] colVals = new int[6];
                for (int j = 0; j < 6; j ++) {
                    if (Get(j,i).Values.Count() == 1) rowVals[j] = Get(j,i).Values.First();
                    if (Get(i,j).Values.Count() == 1) colVals[j] = Get(i,j).Values.First();
                }
                if (rowVals.Where(v => v > 0).GroupBy(key => key).Count(g => g.Count()>1) > 1)
                    return false;
                if (colVals.Where(v => v > 0).GroupBy(key => key).Count(g => g.Count()>1) > 1)
                    return false;

                rowVals = new int[0];
                colVals = new int[0];

                for (int j = 0; j < 6; j ++) {
                    rowVals = rowVals.Concat(Get(j,i).Values).ToArray();
                    colVals = colVals.Concat(Get(i,j).Values).ToArray();
                }

                if (!rowVals.Distinct().OrderBy(a=>a).SequenceEqual(new int[]{1,2,3,4,5,6}) 
                    || !colVals.Distinct().OrderBy(a=>a).SequenceEqual(new int[]{1,2,3,4,5,6}))
                    return false;
            }

            return true;
        }

        public bool IsCorrect(Clues clues) 
        {
            // top row
            for (int i = 0; i < 6; i++) {

                int toSee = clues.Get(i,-1).Val;
                if (toSee == 0) continue;

                int canSee = 0;
                int maxSeen = 0;
                for (int j = 0; j < 6; j++) {

                    if (Get(i,j).Values.Count() > 1) {
                        //canSee++;
                        continue;
                    }

                    int val = Get(i,j).Values.First();
                    if (val > maxSeen) {
                        maxSeen = val;
                        canSee++;
                    }
                }
                if (canSee > toSee) return false;
            }

            //  bottom row
            for (int i = 0; i < 6; i++) {

                int toSee = clues.Get(i,6).Val;
                if (toSee == 0) continue;

                int canSee = 0;
                int maxSeen = 0;
                for (int j = 5; j >= 0; j--) {

                    if (Get(i,j).Values.Count() > 1) {
                        //canSee++;
                        continue;
                    }

                    int val = Get(i,j).Values.First();
                    if (val > maxSeen) {
                        maxSeen = val;
                        canSee++;
                    }
                }
                if (canSee > toSee) return false;
            }

            // left col
            for (int i = 0; i < 6; i++) {

                int toSee = clues.Get(-1,i).Val;
                if (toSee == 0) continue;

                int canSee = 0;
                int maxSeen = 0;
                for (int j = 0; j < 6; j++) {

                    if (Get(j,i).Values.Count() > 1) {
                        //canSee++;
                        continue;
                    }

                    int val = Get(j,i).Values.First();
                    if (val > maxSeen) {
                        maxSeen = val;
                        canSee++;
                    }
                }
                if (canSee > toSee) return false;
            }

            //right col
            for (int i = 0; i < 6; i++) {

                int toSee = clues.Get(6,i).Val;
                if (toSee == 0) continue;

                int canSee = 0;
                int maxSeen = 0;
                for (int j = 5; j >= 0; j--) {

                    if (Get(j,i).Values.Count() > 1) {
                        //canSee++;
                        continue;
                    }

                    int val = Get(j,i).Values.First();
                    if (val > maxSeen) {
                        maxSeen = val;
                        canSee++;
                    }
                }
                if (canSee > toSee) return false;
            }


            return true;
        }
    }

    class Cell
    {
   
        private List<int> _values = new List<int> {1,2,3,4,5,6};
        public List<int> Values {get {return _values;}}

        public override string ToString() {
            return new StringBuilder("|").Append(String.Join(",",Values).PadRight(13)).Append("|").ToString();
        }

    }

    class Clue
    {
        public int Col {get; internal set;}
        public int Row {get; internal set;}
        public int Val {get; internal set;}
    }
}
