//NOTE: don't do overloads like this. It is begging for apocalypse.

static class Factory {
    public static List<Product> Produce(string productName, double price, int howMany) {
        List<Product> products = new();
        for (int i = 0; i < howMany; i++)
            products.Add(new Product(productName, price));
        return products;
    }
    public static List<Product> Produce(string productName, int howMany, double price)
        => Produce(productName, price, howMany);
}
