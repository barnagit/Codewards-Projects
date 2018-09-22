using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Twice_linear.Src
{

    public class DoubleLinear 
    {
        public static ulong[] collector;

        public static int DblLinear(int n) {
            
            if (collector != null) {
                int rr = (int)collector[n];
                Console.WriteLine(rr);
                return rr;
            }

            int number = 60000;
            Console.WriteLine("n:"+number);

            // what is that level which has the min value greater than the number we are looking for
            int base_level = (int) Math.Log(number,2) + 1;
            
            // what is the highest value in the base level?
            int top_of_base_level = 0;
            top_of_base_level += (int)Math.Pow(3,base_level);
            for (int level_index=0; level_index < base_level; level_index++)
                top_of_base_level+=(int)Math.Pow(3,level_index);
            
            // what is that level lastly changes the sort order of the last level
            int max_level = base_level;
            max_level++;

            ulong[] level_old, level_new;
            level_old = new ulong[1];
            level_old[0] = 1;

            ulong b,j,l,c;
            c=0;

            collector = new ulong[(int)Math.Pow(2,max_level+2)];

            for (int level_index = 0; level_index <= max_level; level_index++) {
                
                level_new = new ulong[(int)Math.Pow(2,level_index+1)];
                l = 0;

                for(int i=0; i < level_old.Length; i++) {
                    b = 2*level_old[i]+1;
                    j = 3*level_old[i]+1;

                    level_new[l++] = b;
                    level_new[l++] = j;

                    collector[c++] = b;
                    collector[c++] = j;
                }

                level_old = level_new;
            }

            Array.Sort(collector);
            collector = collector.Distinct().ToArray();
            ulong r = collector[n];
            Console.WriteLine(r);
            return (int)r;
        }
    }
}
