using System;

namespace HelloNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
        //    for (int i = 1; i <= 5; i++)
        //     {
        //         Console.WriteLine(i);
        //     }
        string[] myCars = new string[] { "Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
// The 'Length' property tells us how many values are in the Array (4 in our example here). 
// We can use this to determine where the loop ends: Length-1 is the index of the last value. 
foreach (string car in myCars)
{
    // We no longer need the index, because variable 'car' already represents each indexed value
    Console.WriteLine($"I own a {car}");
}

        }
        
    }
}
