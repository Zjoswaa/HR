class Present {
    private object _contents;
    public bool IsWrapped { get; private set; }
    public string Hint {
        get {
            if (!IsWrapped) {
                return "It is already unwrapped.";
            }
            if (_contents is Lego) {
                return "It is a Lego set!";
            } else if (_contents is BoardGame) {
                return $"It is a board game by {(_contents as BoardGame)?.Publisher}!";
            } else if (_contents is Movie) {
                return "It is a movie!";
            } else if (_contents is Toy) {
                return "It is a toy!";
            }
            return "It is a surprise!";
        }
    }

    public Present(object contents) {
        _contents = contents;
        IsWrapped = true;
    }

    public void Unwrap() => IsWrapped = false;

    public object? GetContents() {
        if (IsWrapped)
            return null;
        return _contents;
    }
}
