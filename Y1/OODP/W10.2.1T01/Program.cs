public class Program {
    public static void Main() {
        List<Book> books = new() {
            new Book("Hitchhiker's Guide to the Galaxy", "Douglas Adams"),
            new Book("One Flew Over the Cuckoo's Nest", "Ken Kesey"),
            new Book("To Kill a Mockingbird", "Harper Lee"),
        };
        Library.Books.AddRange(books);

        List<Customer> customers = new() {
            new Customer("John Doe", "73 Rockland St. Massapequa, NY 11758"),
            new Customer("Jane Doe", "317 Schoolhouse Avenue Valley Stream, NY 11580"),
        };
        Library.Customers.AddRange(customers);

        Book bookwithID2 = Library.FindByID(books, 2);
        Book bookwithID4 = Library.FindByID(books, 4);
        Customer customerwithID1 = Library.FindByID(customers, 1);
        Customer customerwithID2 = Library.FindByID(customers, 2);
        Customer customerwithID3 = Library.FindByID(customers, 3);

        foreach (var found in new List<IHasID>() {
                     bookwithID2, bookwithID4,
                     customerwithID1, customerwithID2, customerwithID3
                 }) {
            if (found == null) {
                Type type = (found is Book) ? typeof(Book) : typeof(Customer);
                Console.WriteLine($"{type.Name} not found");
            }
            else {
                Console.WriteLine($"{found.ToString()} ID: {found.ID}");
            }
        }
    }
}
