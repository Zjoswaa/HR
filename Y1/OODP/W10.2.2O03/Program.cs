static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Interface": TestInterfaces(); return;
            case "Equals": TestProductEquals(); return;
            case "IComparable": TestProductIComparable(); return;
            case "IEnumerable": TestCatalogue(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestInterfaces()
    {
        Type typeOfProduct = typeof(Product);
        bool isIComparable = typeOfProduct.GetInterfaces().Contains(typeof(IComparable<>).MakeGenericType(typeOfProduct));
        bool isIEquatable = typeOfProduct.GetInterfaces().Contains(typeof(IEquatable<>).MakeGenericType(typeOfProduct));
        Console.WriteLine($"{typeOfProduct.Name} has implemented IEquatable and IComparable: "
            + (isIComparable && isIEquatable));

        Type typeOfCatalogue = typeof(ProductCatalogue);
        bool isIEnumerable = typeOfCatalogue.GetInterfaces().Contains(typeof(IEnumerable<>).MakeGenericType(typeOfProduct));
        Console.WriteLine($"{typeOfCatalogue.Name} has implemented IEnumerable: "
            + isIEnumerable);
    }

    public static void TestProductEquals()
    {
        Product p1 = new("Smartphone", 500, 5);
        Product p2 = new("Smartphone", 600, 5);
        Product p3 = new("T-Shirt", 12, 10);
        Product p4 = new("Book", 12, 7);
        Product p5 = new("Book", 16, 7);
        Product p6 = new("EBook", 16, 7);
        Product p7 = new DigitalProduct("EBook", 20, 8, "ebooks.com/downloads/1984.pdf");
        Product p8 = null;
        object o1 = new Product("Smartphone", 500, 5);
        Car c1 = new();

        Console.WriteLine("Testing Equals:");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}"); // true
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}"); // false
        Console.WriteLine($"p4.Equals(p5): {p4.Equals(p5)}"); // true
        Console.WriteLine($"p5.Equals(p6): {p5.Equals(p6)}"); // false
        Console.WriteLine($"p6.Equals(p7): {p6.Equals(p7)}"); // true
        Console.WriteLine($"p1.Equals(p8): {p1.Equals(p8)}"); // false
        Console.WriteLine($"o1.Equals(p1): {o1.Equals(p1)}"); // true
        Console.WriteLine($"p1.Equals(c1): {p1.Equals(c1)}"); // false

        Console.WriteLine("\nTesting == and != operators:");
        Console.WriteLine($"p1 == p2: {p1 == p2}"); // true
        Console.WriteLine($"p1 != p2: {p1 != p2}"); // false
        Console.WriteLine($"p1 == p3: {p1 == p3}"); // false
        Console.WriteLine($"p4 == p5: {p4 == p5}"); // true
        Console.WriteLine($"p5 == p6: {p5 == p6}"); // false
        Console.WriteLine($"p6 == p7: {p6 == p7}"); // true
        Console.WriteLine($"p1 == p8: {p1 == p8}"); // false
        Console.WriteLine($"o1 == p1: {o1 == p1}"); // false
    }

    public static void TestProductIComparable()
    {
        List<Product> products = new()
        {
            new Product("T-Shirt", 10, 10),
            new Product("Smartphone", 500, 5),
            new Product("Smartphone", 600, 5),
            new Product("Book2", 12, 7),
            new Product("Book1", 12, 7),
            new Product("Book3", 11, 8),
            new DigitalProduct("EBook2", 20, 8, "ebooks.com/downloads/1984.pdf"),
            new DigitalProduct("EBook1", 20, 4, "ebooks.com/downloads/hamlet.pdf"),
            null,
        };

        products.Sort();
        foreach (Product prod in products)
        {
            Console.WriteLine($"{prod ?? (object)"null"}");
        }
    }

    public static void TestCatalogue()
    {
        ProductCatalogue catalogue = new()
        {
            new Product("T-Shirt", 10, 10),
            new Product("Smartphone", 500, 5),
            new Product("Book", 20, 7),
            new DigitalProduct("EBook", 20, 7, "ebooks.com/downloads/1984.pdf"),
        };

        catalogue.SortProducts();
        foreach (Product p in catalogue)
        {
            Console.WriteLine($"{p.Name}: {p.Price}");
        }
    }
}
