using System.Collections.Generic;

namespace DeckOfCards

{
    public class Player
    {
        public string Name {get; set;}
        public List<Card> Hand {get; set;} = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public Card Draw(Deck deck)
        {
            Card drawnCard = deck.Deal();
            Hand.Add(drawnCard);
            return drawnCard;
        }

        public Card Discard(int i)
        {
            if (i < 0 || i > Hand.Count - 1)
            {
                return null;
            }
            Card removedCard = Hand[i];
            Hand.RemoveAt(i);
            return removedCard;
        }
    }
}