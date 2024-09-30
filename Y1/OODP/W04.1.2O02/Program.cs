class Program {
    public static void Main() {
        Collection Collection = new("books.json");

        while (true) {
            Collection.PrintCollection();
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("+: Add a new book");
            Console.WriteLine("-: Remove a book");
            Console.WriteLine("A number: see information on this book");
            Console.WriteLine("q: quit");

            string input = Console.ReadLine();
            if (input.ToUpper() == "Q") {
                Collection.WriteToJson("books.json");
                break;
            } else if (input == "+") {
                Console.Write("Enter the title of the new book: ");
                string Title = Console.ReadLine();
                Console.Write("Enter the author of the new book: ");
                string Author = Console.ReadLine();
                Console.Write("Enter the publication year of the new book: ");
                try {
                    int PublicationYear = int.Parse(Console.ReadLine());
                    Collection.AddBook(Title, Author, PublicationYear);
                    Collection.WriteToJson("books.json");
                } catch (FormatException) {
                    Console.WriteLine("Year is not in a valid format.");
                    Console.WriteLine();
                }
            } else if (input == "-") {
                Console.Write("Enter the number of the book to remove: ");
                try {
                    int NumToRemove = int.Parse(Console.ReadLine());
                    Collection.RemoveBook(NumToRemove - 1);
                    Collection.WriteToJson("books.json");
                } catch (FormatException) {
                    Console.WriteLine("Not an index.");
                    Console.WriteLine();
                } catch (ArgumentOutOfRangeException) {
                    Console.WriteLine("Book does not exist.");
                    Console.WriteLine();
                }
            } else {
                if (!int.TryParse(input, out int inputInt)) {
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine();
                    continue;
                }
                try {
                    Collection.PrintBookInfo(inputInt - 1);
                    Console.WriteLine();
                } catch (ArgumentOutOfRangeException) {
                    Console.WriteLine("Book does not exist.");
                    Console.WriteLine();
                }
            }
        }
    }
}
