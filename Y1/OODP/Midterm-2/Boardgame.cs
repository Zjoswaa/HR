using System.Diagnostics;
using System.Xml.Linq;

class Boardgame : Product {
    public int NumberOfPlayers { get; }
    private BoardgameExpansion _expansion;
    public BoardgameExpansion Expansion {
        get {
            return _expansion;
        }

        set {
            if (value is not null) {
                _expansion = value;
            }
        }
    }

    public Boardgame(string name, int price, int numberOfPlayers) : base(name, price) {
        NumberOfPlayers = numberOfPlayers;
    }

    public override void ApplyDiscount() {
        if (Expansion is not null) {
            base.ApplyDiscount(0.2);
        } else {
            base.ApplyDiscount();
        }
    }

    public override string ToString() {
        return $"{Name}\nPlayers: {NumberOfPlayers}\nPrice: {Price}";
    }
}
