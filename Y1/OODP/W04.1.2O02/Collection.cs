using Newtonsoft.Json;

public class Collection {
    public List<Book> Books = [];

    public Collection(string FilePath) {
        StreamReader? reader = null;
        try {
            reader = new(FilePath);
            this.Books = JsonConvert.DeserializeObject<List<Book>>(reader.ReadToEnd())!;
        } catch (FileNotFoundException e) {
            Console.WriteLine($"Missing JSON file. {e.Message}");
            this.Books = [];
        } catch (JsonReaderException e) {
            Console.WriteLine($"Invalid JSON. {e.Message}");
            this.Books = [];
        } finally {
            reader?.Close();
        }
    }

    public Collection() { }

    public void PrintCollection() {
        Console.WriteLine("Book Collection:");
        for (int i = 0; i < this.Books.Count; i++) {
            Console.WriteLine($"{i + 1}. {this.Books[i]}");
        }
    }

    public void AddBook(string Title, string Author, int PublicationYear) {
        this.Books.Add(new Book(Title, Author, PublicationYear));
    }

    public void RemoveBook(int Index) {
        this.Books.RemoveAt(Index);
    }

    public void SetBooks(List<Book> Books) {
        this.Books = Books;
    }

    public void PrintBookInfo(int Index) {
        Console.WriteLine($"Title: {this.Books[Index].Title}");
        Console.WriteLine($"Author: {this.Books[Index].Author}");
        Console.WriteLine($"Publication Year: {this.Books[Index].PublicationYear}");
    }

    public void WriteToJson(string FilePath) {
        StreamWriter? writer = null;
        try {
            writer = new(FilePath);
            string List2Json = JsonConvert.SerializeObject(this.Books);
            writer.Write(List2Json);
        } catch (FileNotFoundException e) {
            Console.WriteLine($"Missing JSON file. {e.Message}");
        } catch (FormatException e) {
            Console.WriteLine($"Invalid JSON. {e.Message}");
        } catch (JsonWriterException e) {
            Console.WriteLine($"Invalid JSON. {e.Message}");
        } finally {
            writer?.Close();
        }
    }
}
