using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Twice_linear.Src
{

    public class DoubleLinear 
    {
        static SortedSet<ulong> L;
        public static ulong DblLinear (ulong n) 
        {
            Console.WriteLine("n:"+n);
            L = new SortedSet<ulong>();

            List<ulong> level_old = new List<ulong>();
            level_old.Add(1);
            List<ulong> level_new = new List<ulong>();

            ulong b;
            ulong j;

            ulong s = 0;
            ulong p = 0;
            while (s < n) s+=(ulong)Math.Pow(2,p++);
            s+=(ulong)Math.Pow(2,p++);

            ulong base_level = (ulong) Math.Log(n,2) + 1;
            ulong level = base_level;
            ulong top_of_base_level = (ulong)Math.Pow(3,base_level);
            for (ulong lc = 0; lc < base_level; lc++) top_of_base_level+=(ulong)Math.Pow(3,lc);

            while (Math.Pow(2,level+1)-1<top_of_base_level) level++;

            //while (L.Count < s) {
            for (ulong ll= 0; ll <= level; ll++) {

                level_new = new List<ulong>();
                foreach(ulong l in level_old) {
                    b = 2*l+1;
                    j = 3*l+1;
                    level_new.Add(b);
                    level_new.Add(j);
                    L.Add(b);
                    L.Add(j);
                }

                level_old = level_new;
            }

            IEnumerator<ulong> e = L.GetEnumerator();
            ulong k = 0;
            while (k++ < n) e.MoveNext();
            Console.WriteLine("current:"+e.Current);
            return e.Current;
        }

    }
}
