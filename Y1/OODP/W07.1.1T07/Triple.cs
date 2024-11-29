class Triple<T1, T2, T3> : Pair<T1, T2> {
    public T3 Trd { get; private set; }
    
    public Triple(T1 Fst, T2 Snd, T3 Trd) : base(Fst, Snd) {
        this.Trd = Trd;
    }
}
