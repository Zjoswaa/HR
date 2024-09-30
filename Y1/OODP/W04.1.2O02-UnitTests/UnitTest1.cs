namespace BookCollection.Test;

[TestClass]
public class BookCollectionTest {
    /*
        This methods runs before every test. Optionally use this to make sure every test starts with an empty state.
    */
    [TestInitialize]
    public void RemoveAllBooks() {
        // Remove all books
    }

    [TestMethod]
    public void Add_Book() {
        Collection Collection = new();
        // Assert.IsTrue: assert that the count of books equals zero
        Assert.IsTrue(Collection.Books.Count == 0);
        // Add a book
        Collection.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        // Assert.IsTrue: assert that the count of books equals one
        Assert.IsTrue(Collection.Books.Count == 1);
    }

    [TestMethod]
    public void Remove_Book() {
        Collection Collection = new();
        // Add a book
        Collection.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        // Remove the book
        Collection.RemoveBook(0);
        // Assert.IsTrue: assert that the count of books equals zero
        Assert.IsTrue(Collection.Books.Count == 0);
    }

    [TestMethod]
    public void Remove_AllBooks() {
        Collection Collection = new();
        // Remove all books
        Collection.Books.Clear();
        // Assert.IsTrue: assert that the count of books equals zero
        Assert.IsTrue(Collection.Books.Count == 0);
    }

    [TestMethod]
    public void Get_Books() {
        Collection Collection = new();
        // Add three books
        Collection.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        Collection.AddBook("To Kill a Mockingbird", "Harper Lee", 1960);
        Collection.AddBook("1984", "George Orwell", 1949);
        // Assert.IsTrue: assert that the count of books equals three    
        Assert.IsTrue(Collection.Books.Count == 3);
    }

    [TestMethod]
    public void Get_Book() {
        Collection Collection = new();
        // Add three books
        Collection.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        Collection.AddBook("To Kill a Mockingbird", "Harper Lee", 1960);
        Collection.AddBook("1984", "George Orwell", 1949);
        // Assert.AreEqual: assert (twice) that the title of an added book matches the expected title)
        Assert.AreEqual(Collection.Books[0].Title, "The Great Gatsby");
        Assert.AreEqual(Collection.Books[1].Title, "To Kill a Mockingbird");
    }

    [TestMethod]
    public void Set_Books() {
        Collection Collection = new();
        // Create a list with three books
        List<Book> Books = new() {
            new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925),
            new Book("To Kill a Mockingbird", "Harper Lee", 1960),
            new Book("1984", "George Orwell", 1949)
        };
        // Set the books
        Collection.SetBooks(Books);
        // Assert.IsTrue: assert that the count of books equals three    
        Assert.IsTrue(Collection.Books.Count == 3);
        // Assert.AreEqual: assert (twice) that the title of an added book matches the expected title)
        Assert.AreEqual(Collection.Books[0].Title, "The Great Gatsby");
        Assert.AreEqual(Collection.Books[1].Title, "To Kill a Mockingbird");
    }
}
