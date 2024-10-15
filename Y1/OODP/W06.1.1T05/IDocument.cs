interface IDocument : IStorable {
    string Title { get; set; }
    string Content { get; set; }

    void Print();
}
