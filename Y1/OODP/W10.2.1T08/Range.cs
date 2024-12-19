class Range {
    public int Start { get; }
    public int End { get; }
    public int Step { get; }

    public Range(int Start, int End, int Step) {
        this.Start = Start;
        this.End = End;
        this.Step = Step;
    }

    public IEnumerable<int> Next() {
        for (int i = Start; i < End; i += Step) {
            yield return i;
        }
    }
}
