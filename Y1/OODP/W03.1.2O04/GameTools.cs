static class GameTools {
    public static bool ReturnCount = true;
    private static Random rand = new();

    public static string CoinFlip(int Count) {
        int Heads = 0;
        int Tails = 0;
        string Result = "";
        for (int i = 0; i < Count; i++) {
            if (rand.Next(0, 2) == 0) {
                if (ReturnCount) {
                    Heads++;
                } else {
                    Result += "Heads\n";
                }
            } else {
                if (ReturnCount) {
                    Tails++;
                } else {
                    Result += "Tails\n";
                }
            }
        }
        if (ReturnCount) {
            return $"Heads: {Heads}\nTails: {Tails}";
        }
        // Remove last newline
        return Result.Substring(0, Result.LastIndexOf("\n"));
    }

    public static string DiceRoll(int DieSides, int Rolls) {
        if (DieSides < 3) {
            return "Invalid number of die sides.";
        }

        string Result = "";
        int[] DieRolls = new int[DieSides];
        for (int i = 0; i < DieSides; i++) {
            DieRolls[i] = 0;
        }

        for (int i = 0; i < Rolls; i++) {
            int r = rand.Next(1, DieSides + 1);
            if (ReturnCount) {
                DieRolls[r - 1]++;
            } else {
                Result += $"Roll {i + 1}: {r}\n";
            }
        }
        if (ReturnCount) {
            Result = "";
            for (int i = 0; i < DieSides; i++) {
                Result += $"{i + 1} was rolled {DieRolls[i]} times\n";
            }
        }
        // Remove last newline
        return Result.Substring(0, Result.LastIndexOf("\n"));
    }
}
