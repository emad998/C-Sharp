namespace DeckOfCards
{
    public class Card
    {
        public string StrVal {get; set;}

        public int Val {get; set; }

        public string Suit {get; set;}

        public Card(string strVal, int val, string suit)
        {
            StrVal = strVal;
            Val = val;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{StrVal} of {Suit}";
        }


    }
}