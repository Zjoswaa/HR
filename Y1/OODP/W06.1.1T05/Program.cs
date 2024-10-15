public class Program {
    public static void Main() {
        List<IDocument> documents = new()
        {
            new TextDocument("Book report.docx", "The butler did it"),
            new TextDocument("C# assignment.docx", "Create a minigame"),
        };

        List<IStorable> storables = new()
        {
            new File("Background.jpg"),
            new File("RecordedMessage.mp3"),
        };
        storables.AddRange(documents);

        foreach (var storable in storables) {
            Console.WriteLine(storable.FileName);
            storable.Load();
            storable.Save();
            if (storable is IDocument) {
                Console.WriteLine((storable as IDocument).Title);
                Console.WriteLine((storable as IDocument).Content);
            }
        }
    }
}
