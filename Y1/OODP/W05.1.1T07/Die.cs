public class Die {
    private readonly Random _rnd;
    private readonly int _sides;

    public Die(int sides, int seed) {
        _sides = sides <= 0 ? 0 : sides;
        _rnd = new Random(seed);
    }

    public int Roll() => _rnd.Next(1, _sides + 1);
}
