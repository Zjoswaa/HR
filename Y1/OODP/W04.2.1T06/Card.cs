class Card {
    public readonly string Suit;
    public readonly string Rank;

    public Card(string Suit, string Rank) {
        this.Suit = Suit;
        this.Rank = Rank;
    }

    public string GetName() {
        if (this.Suit == "Joker") {
            return $"{this.Rank} {this.Suit}";
        }
        return $"{this.Rank} of {this.Suit}";
    }
}
