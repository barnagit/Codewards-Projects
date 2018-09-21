using System;
using System.Text;

namespace Path_Finder_1.Src
{
    public enum Cardinals
    {
        Null, South, East, North, West
    }
    public struct Pos {
        public int sor;
        public int oszlop;
    }

    public class Maze {
        StringBuilder m;
        public Maze(string maze) {
            m = new StringBuilder(maze);

            while (N != maze.Length && maze[N] != Environment.NewLine.ToCharArray()[0])
            N++;

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {

                    // is wall, continue
                    if (isWall(i,j)) continue;
                    else Set(i,j,'0');

                    // look North
                    if (i > 0 && !isWall(i-1,j))
                        Set(i,j,(Char.GetNumericValue(At(i,j))+1).ToString().ToCharArray()[0]);
                    
                    // look South
                    if (i < N-1 && !isWall(i+1,j))
                        Set(i,j,(Char.GetNumericValue(At(i,j))+1).ToString().ToCharArray()[0]);
                    
                    // look East
                    if (j < N-1 && !isWall(i,j+1))
                        Set(i,j,(Char.GetNumericValue(At(i,j))+1).ToString().ToCharArray()[0]);

                    // look West
                    if (j > 0 && !isWall(i,j-1))
                        Set(i,j,(Char.GetNumericValue(At(i,j))+1).ToString().ToCharArray()[0]);
                }
            } 
        }
        
        public int N {get;private set;}
        public char At(int sor , int oszlop) {
            return m[sor*(N+1)+oszlop];
        }
        public void Set(int sor, int oszlop, char v) {
            m[sor*(N+1)+oszlop] = v;
        }
        public void Dec(int sor, int oszlop) {
            int val = (int)Char.GetNumericValue(At(sor,oszlop))-1;
            char c = val==0?'W':(val).ToString().ToCharArray()[0];
            Set(sor,oszlop,c);
        }
        public bool isWall(int sor, int oszlop) {
            return m[sor*(N+1)+oszlop] == 'W';
        }

        public override string ToString() {
            return m.ToString();
        }
    }

    public class Finder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static Maze maze;
        
        // maze is NxN, your startpoint is [0,0] and your Lookal is [N-1,N-1]
        // '.' means empty, 'W' means wall, start and endpoint are always empty, never walls.
        public static bool PathFinder(string m) {
            Console.WriteLine();
            Console.WriteLine();

            // Your code here!!
            maze = new Maze(m);
            // I need to know how big is my maze. for knowing if I am at the end pos.
            // Check if I am in the right position
            // I need to recursively Look in one direction of the four if possible, then check.
            //Console.WriteLine(maze.N);
            Console.WriteLine(maze);
            Console.WriteLine();

            Pos pos = new Pos{sor =0, oszlop=0};
            try {
                Step(Cardinals.Null, pos);
            } catch (ArgumentNullException) {
                return false;
            } catch (ArgumentOutOfRangeException) { 
                return true;
            } catch (StackOverflowException) {
                return false;
            } finally {
                Console.WriteLine(maze);
            }

            return false;
        }

        public static void Step(Cardinals from, Pos pos) {
            if (pos.sor == maze.N-1 && pos.oszlop == maze.N-1)
                throw new ArgumentOutOfRangeException();

            // go south
            if (from!=Cardinals.South && Look(Cardinals.South, pos)) {
                //Console.WriteLine(Cardinals.South);
                maze.Dec(pos.sor, pos.oszlop);
                pos.sor++;
                Step(Cardinals.North, pos);
            }

            //go east
            else if (from!=Cardinals.East && Look(Cardinals.East, pos)) {
                //Console.WriteLine(Cardinals.East);
                maze.Dec(pos.sor, pos.oszlop);
                pos.oszlop++;
                Step(Cardinals.West, pos);
            }

            // go north
            else if (from!=Cardinals.North && Look(Cardinals.North, pos)) {
                //Console.WriteLine(Cardinals.North);
                maze.Dec(pos.sor, pos.oszlop);
                pos.sor--;
                Step(Cardinals.South, pos);
            }

            // go west
            else if (from!=Cardinals.West && Look(Cardinals.West, pos)) {
                //Console.WriteLine(Cardinals.West);
                maze.Dec(pos.sor, pos.oszlop);
                pos.oszlop--;
                Step(Cardinals.East, pos);
            }

            if (from == Cardinals.Null)
                throw new ArgumentNullException();

            
        }

        public static bool Look(Cardinals direction, Pos pos) {
            switch (direction)
            {
                case Cardinals.North:
                    if (pos.sor == 0 || maze.isWall(pos.sor-1,pos.oszlop)) return false;
                    else return true;
                break;

                case Cardinals.West:
                    if (pos.oszlop == 0 || maze.isWall(pos.sor,pos.oszlop-1)) return false;
                    else return true;
                break;

                case Cardinals.South:
                    if (pos.sor == maze.N-1 || maze.isWall(pos.sor+1,pos.oszlop)) return false;
                    else return true;
                break;

                case Cardinals.East:
                    if (pos.oszlop == maze.N-1 || maze.isWall(pos.sor,pos.oszlop+1)) return false;
                    else return true;
                break;
            }
            return true;
        }
    }
}
