static class Program {
    static void Main() {
        List<File> files = new()
        {
            new File("Project Presentation.pptx"),
            new File("Project Data.xlsx"),
            new TextFile("Lecture notes", "Interfaces are super useful"),
            new TextFile("ToDo", "OODP assignments\nPay teachers compliment\n"),
        };

        foreach (File file in files) {
            Console.WriteLine(file.FileName);
            if (file is TextFile)
                Console.WriteLine((file as TextFile).Contents);
            if (file is IPrintable)
                (file as IPrintable).Print();
        }
    }
}
