using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Emad = new Human("Emad");
            Human Donald = new Human("Donald");
            Console.WriteLine(Emad.Attack(Donald));
        }
    }
}
