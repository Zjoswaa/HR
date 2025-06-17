class Solution {
    public static void Q1(ExamContext db, string Name) {
        var customers = db.Customers
            .Where(c => c.FirstName.Contains(Name) || c.LastName.Contains(Name));

        foreach (var customer in customers) {
            Console.WriteLine($"ID: {customer.ID}, FirstName: {customer.FirstName}, LastName: {customer.LastName}");
        }
    }

    public static void Q2(ExamContext db, int ProductID) {
        var product = db.Products
            .Single(p => p.ID == ProductID);

        var company = db.Companies
            .Single(c => c.ID == product.CompanyID);

        Console.WriteLine($"Company: {company.Name}, Prodcut: {product.Name}, Price: {product.Price}");
    }

    public static void Q3(ExamContext db) {
        var res = db.Companies
            .GroupBy(
                c => string.IsNullOrEmpty(c.Country) ? "NULL" : c.Country.ToUpper(),
                (key, companies) => new {
                    CountryName = key,
                    CompanyCount = companies.Count(),
                    Companies = companies.Select(c => new { c.ID, c.Name, c.Country })
                }
            );

        foreach (var group in res) {
            Console.WriteLine($"{group.CountryName}, {group.CompanyCount}");
            foreach (var company in group.Companies) {
                Console.WriteLine($"{company.ID}, {company.Name}, {company.Country}");
            }
        }
    }

    public static void Q4(ExamContext db, int OrderID) {
        var order = db.Orders
            .Where(o => o.ID == OrderID)
            .Select(o => new
            {
                o.ID,
                o.CustomerID,
                o.dateTime,
                o.isOnline
            })
            .SingleOrDefault();
        
        var customer = db.Customers
            .Where(c => c.ID == order.CustomerID)
            .Select(c => new
            {
                c.FirstName,
                c.LastName
            })
            .SingleOrDefault();

        var shoppingCartItems = db.ShoppingCarts
            .Where(sc => sc.OrderID == order.ID)
            .Join(db.Products,
                sc => sc.ProductID,
                p => p.ID,
                (sc, p) => new
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price,
                    ProductQuantity = sc.Quantity
                });

        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
        Console.WriteLine($"OrderID: {order.ID}");

        decimal grandTotal = 0;
        foreach (var shoppingCartItem in shoppingCartItems) {
            grandTotal += shoppingCartItem.ProductPrice * shoppingCartItem.ProductQuantity;
            Console.WriteLine($"{shoppingCartItem.ProductName}, {shoppingCartItem.ProductPrice} x {shoppingCartItem.ProductQuantity} = {shoppingCartItem.ProductPrice * shoppingCartItem.ProductQuantity}");
        }

        Console.WriteLine($"Grand total: {grandTotal}");
    }

    public static void Q5(ExamContext db) {
        var productsNotInCarts = db.Products
            .Where(p => !db.ShoppingCarts.Any(sc => sc.ProductID == p.ID))
            .Select(p => new {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price
            });
        
        foreach (var product in productsNotInCarts) {
            Console.WriteLine($"Product: {product.ID}, {product.Name}, {product.Price}");
        }
    }

    public static void Q6(ExamContext db) {
        db.Customers.Add(new Customer { ID = 99, FirstName = "John", LastName = "Doe" });
        db.Orders.Add(new Order { ID = 99, CustomerID = 99, isOnline = true });
        db.ShoppingCarts.Add(new ShoppingCart { OrderID = 99, ProductID = 2, Quantity = 5 });
        db.ShoppingCarts.Add(new ShoppingCart { OrderID = 99, ProductID = 15, Quantity = 1 });
        
        Console.WriteLine($"{db.SaveChanges()} records got created");
    }

    public static void Q7(ExamContext db, string Country, decimal fraction) {
        var results = db.Products
            .Join(db.Companies,
                p => p.CompanyID,
                c => c.ID,
                (p, c) => new {
                    Product = p,
                    CountryName = c.Country
                })
            .Where(r => (string.IsNullOrEmpty(r.CountryName) ? "NULL" : r.CountryName.ToUpper()).Equals(Country))
            .Select(r => r.Product);
        
        foreach (var product in results) {
            product.Price *= 1 + fraction;
        }
        
        Console.WriteLine($"{db.SaveChanges()} records got updated");
    }

    public static void Q8(ExamContext db, int OrderID) {
        var order = db.Orders
            .SingleOrDefault(o => o.ID == OrderID);

        if (order is null) {
            Console.WriteLine($"Order {OrderID} not found");
            return;
        }
        
        db.ShoppingCarts.RemoveRange(
            db.ShoppingCarts
                .Where(sc => sc.OrderID == OrderID)
        );

        db.Orders.Remove(order);

        Console.WriteLine($"{db.SaveChanges()} records got deleted");
        Console.WriteLine($"Order {order.ID}, from Customer {order.CustomerID} at {order.dateTime} deleted");
    }
}
