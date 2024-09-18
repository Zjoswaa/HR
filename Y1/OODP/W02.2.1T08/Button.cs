class Button {
    public bool IsPressed = false;
    public int TimesPressed = 0;

    public Button() { }

    public void Press() {
        this.IsPressed = !this.IsPressed;
        ++this.TimesPressed;
    }

    public string Info() {
        return this.IsPressed ?
            $"Button is pressed.\nPressed {this.TimesPressed} times." :
            $"Button is not pressed.\nPressed {this.TimesPressed} times.";
    }
}
