class ProgressPopup : Popup {
    private int _progress = 0;
    private string _progressBar = "";

    public ProgressPopup(string Message) : base(Message){
        this.Display();
    }

    public void IncreaseProgress(int Progress) {
        this._progress = Math.Min(100, this._progress + Progress);
        this._progressBar = "";
        for (int i = 0; i < this._progress / 10; i++) {
            this._progressBar += "|";
        }
        this.Display();
    }

    public override void Display() {
        base.Display();
        Console.WriteLine($"{this._progress}%{(this._progress == 100 ? "    " : "     ")}{this._progressBar}");
    }
}
