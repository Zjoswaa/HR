public class SevenElevenVariant {
    private Die[] _dice;
    private static int[] _gameEndSumArr = new int[] { 2, 3, 7, 11, 12 };

    public SevenElevenVariant(int seed) {
        _dice = new Die[] { new Die(6, seed), new Die(6, seed) };
    }

    public void PlayGame() {
        int result;
        do {
            result = SumDiceRoll();
            Console.WriteLine($"The sum of the {_dice.Length} dice rolls is {result}.");
        } while (!(DoesArrayContain(_gameEndSumArr, result)));

        Console.WriteLine(result != 7 ? $"{result} means you win!" : $"{result} means you lose!");
    }

    private int SumDiceRoll() {
        int sum = 0;
        foreach (var die in _dice)
            sum += die.Roll();
        return sum;
    }

    private bool DoesArrayContain(int[] array, int elem) {
        foreach (int i in array) {
            if (i == elem) return true;
        }
        return false;
    }
}
