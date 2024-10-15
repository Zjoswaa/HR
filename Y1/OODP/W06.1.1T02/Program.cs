public class Program {
    public static void Main() {
        List<Square> squares = new()
        {
            new Square(6),
            new Square(5),
        };

        foreach (Square square in squares) {
            (square as IResizable).Resize(0.5);
            (square as IDrawable).Draw();
        }
    }
}
