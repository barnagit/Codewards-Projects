using System;
using System.Text;

namespace Path_Finder_1.Src
{
 /*
    public enum Cardinals
    {
        Null, South, East, North, West
    }
*/

/*
    public struct Pos {
        public int sor;
        public int oszlop;
    }
*/

    public enum Típus {
        Fal = 0, Út = 1
    }

    public static class Irányít {
        public static (int, int) jobbra((int,int) irány) {
            var s = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item1)));
            var o = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item2)));
            int szorzó = irány.Item2 !=0?1:-1;

            return (s*szorzó,o*szorzó);
        }

        public static (int, int) balra((int,int) irány) {
            var s = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item1)));
            var o = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item2)));
            int szorzó = irány.Item2 ==0?1:-1;

            return (s*szorzó,o*szorzó);
        }
    }

    public class Poz {
        public int sor {get;set;}
        public int oszlop {get;set;}
        public Típus típus {get;set;}
    }

    public class Terep {
        protected StringBuilder _terep;
        public int Méret {get;private set;}
        public Típus Itt(int sor , int oszlop) {
            if (sor>=Méret || oszlop >=Méret || sor<0 || oszlop <0) return Típus.Fal;
            else return _terep[sor*(Méret+1)+oszlop]=='W'?Típus.Fal:Típus.Út;
        }
        public Terep (string terep) {
           _terep = new StringBuilder(terep);

            while (Méret != terep.Length && terep[Méret] != Environment.NewLine.ToCharArray()[1]) // windows = 1, linux = 0
            Méret++;

            voltamItt = new bool[Méret, Méret];
        }

        public bool[,] voltamItt {get;private set;}
    }

    public class Hely {

        
        public Poz poz {get;set;}
        public Hely balra {get;set;}
        public Hely előre {get;set;}
        public Hely jobbra {get;set;}

        public (int, int) irány {get;set;}

    }
    
    public class Finder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static Terep terep;
        
        public static bool PathFinder(string t) {

            terep = new Terep(t);
            
            Hely start = new Hely{poz = new Poz{sor=0,oszlop=0}, irány = (1,0)};
            terep.voltamItt[start.poz.sor, start.poz.oszlop] = true;

            try {
                Menj(start);
            } catch (ArgumentException) {
                return true;
            }

            return false;
        }

        public static void Menj(Hely innen) {
            if (innen == null) return;
            else if (innen.poz.sor == terep.Méret-1 && innen.poz.oszlop == terep.Méret-1)
                throw new ArgumentException();

            NézzKörül(innen);
            Menj(innen.előre);
            Menj(innen.jobbra);
            Menj(innen.balra);
        }

        public static void NézzKörül(Hely itt) {
            if (itt == null) return;

            //jobbra            
            (int,int) jobbra = Irányít.jobbra(itt.irány);
            if (terep.Itt(itt.poz.sor+jobbra.Item1,itt.poz.oszlop+jobbra.Item2) == Típus.Út
                && !terep.voltamItt[itt.poz.sor+jobbra.Item1,itt.poz.oszlop+jobbra.Item2])
            {
                itt.jobbra = new Hely{poz=new Poz {sor=itt.poz.sor+jobbra.Item1, oszlop = itt.poz.oszlop+jobbra.Item2}, irány = jobbra};
                terep.voltamItt[itt.jobbra.poz.sor, itt.jobbra.poz.oszlop] = true;
            }
            

            //balra
            (int, int) balra = Irányít.balra(itt.irány);
            if (terep.Itt(itt.poz.sor+balra.Item1,itt.poz.oszlop+balra.Item2)==Típus.Út
                && !terep.voltamItt[itt.poz.sor+balra.Item1,itt.poz.oszlop+balra.Item2])
            {
                itt.balra = new Hely{poz = new Poz {sor=itt.poz.sor+balra.Item1, oszlop = itt.poz.oszlop+balra.Item2}, irány = balra};
                terep.voltamItt[itt.balra.poz.sor, itt.balra.poz.oszlop] = true;
            }

            //előre
            if (terep.Itt(itt.poz.sor+itt.irány.Item1, itt.poz.oszlop+itt.irány.Item2)==Típus.Út
                && !terep.voltamItt[itt.poz.sor+itt.irány.Item1, itt.poz.oszlop+itt.irány.Item2])
            {
                itt.előre = new Hely{poz = new Poz {sor=itt.poz.sor+itt.irány.Item1, oszlop = itt.poz.oszlop+itt.irány.Item2}, irány= itt.irány};
                terep.voltamItt[itt.előre.poz.sor, itt.előre.poz.oszlop] = true;
            }
        }
    }


/*
    public class Terep {
        StringBuilder m;
        public Terep(string terep) {
            m = new StringBuilder(terep);

            while (N != terep.Length && terep[N] != Environment.NewLine.ToCharArray()[0])
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
*/

/*
    public class Finder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static Terep(m);
            // I need to know how big is my terep. for knowing if I am at the end pos.
            // Check if I am in the right position
            // I need to recursively Look in one direction of the four if possible, then check.
            //Console.WriteLine(terep.N);
            Console.WriteLine(terep);
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
                Console.WriteLine(terep);
            }

            return false;
        }

        public static void Step(Cardinals from, Pos pos) {
            if (pos.sor == terep.N-1 && pos.oszlop == terep.N-1)
                throw new ArgumentOutOfRangeException();

            // go south
            if (from!=Cardinals.South && Look(Cardinals.South, pos)) {
                //Console.WriteLine(Cardinals.South);
                terep.Dec(pos.sor, pos.oszlop);
                pos.sor++;
                Step(Cardinals.North, pos);
            }

            //go east
            else if (from!=Cardinals.East && Look(Cardinals.East, pos)) {
                //Console.WriteLine(Cardinals.East);
                terep.Dec(pos.sor, pos.oszlop);
                pos.oszlop++;
                Step(Cardinals.West, pos);
            }

            // go north
            else if (from!=Cardinals.North && Look(Cardinals.North, pos)) {
                //Console.WriteLine(Cardinals.North);
                terep.Dec(pos.sor, pos.oszlop);
                pos.sor--;
                Step(Cardinals.South, pos);
            }

            // go west
            else if (from!=Cardinals.West && Look(Cardinals.West, pos)) {
                //Console.WriteLine(Cardinals.West);
                terep.Dec(pos.sor, pos.oszlop);
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
                    if (pos.sor == 0 || terep.isWall(pos.sor,pos.oszlop+1)) return false;
                    else return true;
                break;
            }
            return true;
        }
    }
*/

}
