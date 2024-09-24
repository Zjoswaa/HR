public class Die {
    public string Color;
    public int Sides;
    public int Value;

    public Die(int sides, string color) {
        this.Sides = sides;
        this.Color = color;
        this.Roll();
    }

    public void Roll() {
        Random ran = new();
        this.Value = ran.Next(1, this.Sides + 1);
    }

    public override string ToString() {
        return $"sides: {this.Sides}, color: {this.Color}, value: {this.Value}";
    }
}
