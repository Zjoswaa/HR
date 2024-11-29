public class IDEFactory : IFactory<IDE> {
    public IDE CreateLightTheme() {
        return new IDE("White", "Black", "Light blue");
    }

    public IDE CreateDarkTheme() {
        return new IDE("Black", "White", "Light yellow");
    }
}
