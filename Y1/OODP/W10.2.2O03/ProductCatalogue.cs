using System.Collections;

class ProductCatalogue : IEnumerable<Product> {
    private List<Product> _products = new();

    public void Add(Product Product) {
        _products.Add(Product);
    }

    public IEnumerator<Product> GetEnumerator() {
        return _products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return this.GetEnumerator();
    }

    public void SortProducts() {
        _products.Sort();
    }
}
