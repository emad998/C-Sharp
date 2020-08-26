using System;

namespace hungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet Emad = new Buffet();
            Ninja Don = new Ninja(1000);
            while(!Don.IsFull)
            {
                Don.Eat(Emad.Serve());
                Don.Eat(Emad.Serve());
            }
            
        }
    }
}
