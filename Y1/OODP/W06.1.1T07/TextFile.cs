class TextFile : File, IPrintable {
    public string Contents { get; set; }

    public TextFile(string FileName, string Contents) : base(FileName + ".txt") {
        this.Contents = Contents;
    }

    public void Print() {
        Console.WriteLine(this.Contents);
    }
}
