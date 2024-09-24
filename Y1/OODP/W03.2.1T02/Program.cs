using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "ReadOnly": TestReadOnly(); return;
            case "Card": TestCard(); return;
            case "CreateDeck": TestCreateDeck(args[2] == "Jokers"); return;
            case "DeckMethods": TestDeckMethods(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        };
    }

    public static void TestReadOnly() {
        Type clsType = typeof(Card);
        PrintIsFieldReadOnly(clsType, "Suit");
        PrintIsFieldReadOnly(clsType, "Rank");

        clsType = typeof(Deck);
        PrintIsFieldReadOnly(clsType, "Cards");
    }

    public static void TestCard() {
        Card card = new("Spades", "Ace");
        Console.WriteLine(card.GetName());

        card = new("Hearts", "10");
        Console.WriteLine(card.GetName());

        card = new("Diamonds", "Queen");
        Console.WriteLine(card.GetName());
    }

    public static void TestCreateDeck(bool areJokersIncluded) {
        Deck deck = new(areJokersIncluded);
        foreach (var card in deck.Cards) {
            Console.WriteLine(card.GetName());
        }
    }

    public static void TestDeckMethods() {
        Console.WriteLine("=== Shuffling decks ===");
        // It is virtually impossible for two shuffled decks
        // to be the same, let alone three of them.

        Deck deck1 = new(true);
        string allCards1 = GetAllCardsAsString(deck1);

        Deck deck2 = new(true);
        string allCards2 = GetAllCardsAsString(deck2);

        Deck deck3 = new(true);
        string allCards3 = GetAllCardsAsString(deck3);

        Console.WriteLine($"Cards have been shuffled: {allCards1 != allCards2 && allCards1 != allCards3}");

        Console.WriteLine("\n=== Drawing cards ===");
        while (deck1.Cards.Count != 0) {
            deck1.Draw();
        }
        PrintCardsLeft(deck1);

        Console.WriteLine($"Deck is empty; any attempted card draw will be null: {deck1.Draw() is null}");
    }

    private static string GetAllCardsAsString(Deck deck) {
        string allCards = "";
        foreach (var card in deck.Cards) {
            allCards += card.GetName() + "\n";
        }
        return allCards;
    }

    private static void PrintCardsLeft(Deck deck) {
        Console.WriteLine($"{deck.Cards.Count} cards left");
    }

    private static void PrintIsFieldReadOnly(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"Field {info.Name} is read-only: " +
                info.IsInitOnly);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }
}
