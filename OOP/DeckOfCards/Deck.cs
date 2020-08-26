using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards {get; set; } = new List<Card>();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            Dictionary<int, string> faceCardLookup = new Dictionary<int, string>()
            {
                {1, "Ace"},
                {11, "Jack"},
                {12, "Queen"},
                {13, "King"},
            }
            string[] suites = new string[]
            {
                "Hears", "Diamonds", "Clubs", "Spades"
            };

            foreach(string suit in suites)
            {
                for (int i = 1; i < 13; i++)
                {
                    string stringVal = i.ToString();
                   if (faceCardLookup.ContainsKey(i))
                   {
                       stringVal = faceCardLookup[i];
                   }
                   


                    Card card = new Card(stringVal, i, suit);
                    Cards.Add(card);
                }
            }
        }

        public void Print()
        {
            foreach(Card card in Cards)
            {
                Console.WriteLine($"{card.StrVal} of {card.Suit} | Worth: {card.Val}");
            }
        }

        public Card Deal()
        {
            if (Cards.Count > 0)
            {
                int lastIdx = Cards.Count - 1;
                Card card = Cards[lastIdx];
                Cards.RemoveAt(lastIdx);
                return card;
            }
            return null;
        }

        public List<Card> DealHand(int howManyCards = 5)
        {
            List<Card> hand = new List<Card>();
            for (int i = 0; i < howManyCards; i++)
            {
                hand.Add(this.Deal());
            }
            return hand;
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int randIdx = rand.Next(Cards.Count);

                Card currCard = Cards[i];
                Card randCard = Cards[randIdx];

                Cards[i] = randCard;
                Cards[randIdx] = currCard;
            }
        }
    }
}