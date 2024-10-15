public class TextDocument : IDocument {
    public string Title { get; set; }
    public string Content { get; set; }
    public string FileName { get; set; }

    public TextDocument(string title, string content) {
        Title = title;
        Content = content;
    }

    public void Print() {
        Console.WriteLine(Content);
    }

    public void Save() {
        //Implementation of IStorable.Save
    }

    public void Load() {
        //Implementation of IStorable.Load
    }
}
