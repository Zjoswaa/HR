class Pair<T1, T2> {
    public T1 Fst { get; private set; }
    public T2 Snd { get; private set; }

    public Pair(T1 Fst, T2 Snd) {
        this.Fst = Fst;
        this.Snd = Snd;
    }
}
