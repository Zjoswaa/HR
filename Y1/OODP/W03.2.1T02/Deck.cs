class Deck {
    public readonly List<Card> Cards = new();

    public Deck(bool areJokersIncluded) {
        List<string> Suits = new() { "Diamonds", "Clubs", "Hearts", "Spades" };
        List<string> Ranks = new() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        
        foreach(string suit in Suits) {
            foreach (string rank in Ranks) {
                this.Cards.Add(new Card(suit, rank));
            }
        }

        if (areJokersIncluded) {
            this.Cards.Add(new Card("Joker", "Red"));
            this.Cards.Add(new Card("Joker", "Black"));
        }

        this.Shuffle();
    }

    public void Shuffle() {
        Random rand = new Random();
        int n = Cards.Count;
        while (n > 1) {
            n--;
            int k = rand.Next(n + 1);
            Card Card = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = Card;
        }
    }

    public Card Draw() {
        if (this.Cards.Count == 0) {
            return null;
        }

        Card toRemove = this.Cards[^1];
        this.Cards.RemoveAt(this.Cards.Count - 1);
        return toRemove;
    }
}
