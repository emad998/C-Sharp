using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Deck deck1 = new Deck();
            deck1.Shuffle();
            deck1.Print();
            List<Card> hand = deck1.DealHand();
            

        }

    }
}
