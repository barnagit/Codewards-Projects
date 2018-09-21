using System;
using System.Text;

namespace Path_Finder_1.Src
{
    public enum Típus {
        Fal = 0, Út = 1
    }

    public struct Irány
    {
        public Irány(int i1, int i2)
        {
            Item1 = i1;
            Item2 = i2;
        }
        public int Item1;
        public int Item2;
    }

    public static class Irányít {
        public static Irány jobbra(Irány irány) {
            var s = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item1)));
            var o = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item2)));
            int szorzó = irány.Item2 !=0?1:-1;

            return new Irány {Item1=s*szorzó,Item2=o*szorzó};
        }

        public static Irány balra(Irány irány) {
            var s = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item1)));
            var o = Convert.ToInt32(!Convert.ToBoolean(Math.Abs(irány.Item2)));
            int szorzó = irány.Item2 ==0?1:-1;

            return new Irány {Item1=s*szorzó,Item2=o*szorzó};
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

        public Irány irány {get;set;}

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
            
            Hely start = new Hely{poz = new Poz{sor=0,oszlop=0}, irány = new Irány(1,0)};
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
            Irány jobbra = Irányít.jobbra(itt.irány);
            if (terep.Itt(itt.poz.sor+jobbra.Item1,itt.poz.oszlop+jobbra.Item2) == Típus.Út
                && !terep.voltamItt[itt.poz.sor+jobbra.Item1,itt.poz.oszlop+jobbra.Item2])
            {
                itt.jobbra = new Hely{poz=new Poz {sor=itt.poz.sor+jobbra.Item1, oszlop = itt.poz.oszlop+jobbra.Item2}, irány = jobbra};
                terep.voltamItt[itt.jobbra.poz.sor, itt.jobbra.poz.oszlop] = true;
            }
            

            //balra
            Irány balra = Irányít.balra(itt.irány);
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
}
