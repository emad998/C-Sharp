using System;
using System.Collections.Generic;

namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> types = new List<object>();
            types.Add(7);
            types.Add(28);
            types.Add(-1);
            types.Add(true);
            types.Add("Chair");

            // for (var idx=0; idx<types.Count; idx++){
            //     Console.WriteLine(types[idx]);
            // }

            int sum =0;

            for (var idx=0; idx<types.Count; idx++){
                if (types[idx] is int){
                     sum += (int)types[idx];
                    
                }
               
                
            }
            Console.WriteLine(sum);
            
        }
    }
}
