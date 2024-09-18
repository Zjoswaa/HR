class DNA {
    public string Seq;

    public DNA(string Seq) {
        this.Seq = Seq;
    }

    public DNA Replicate1() {
        return new DNA(this.Seq);
    }

    public DNA Replicate2() {
        return this;
    }

    public void Mutate(string Seq) {
        this.Seq = Seq;
    }
}
