public static class Library {
    public static List<Book> Books = new();
    public static List<Customer> Customers = new();

    public static Customer CustomerByID(int id) {
        foreach (Customer customer in Customers) {
            if (customer.ID == id) {
                return customer;
            }
        }

        return null;
    }

    public static Book BookByID(int id) {
        foreach (Book book in Books) {
            if (book.ID == id) {
                return book;
            }
        }
        return null;
    }

    public static T FindByID<T>(int ID) {
        
    }
}
