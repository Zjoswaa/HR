using Microsoft.EntityFrameworkCore;

class ExamContext : DbContext {
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ShoppingCart>().HasKey(_ => new { _.OrderID, _.ProductID });

        //modelBuilder.Entity<Product>()
        //    .HasOne<Company>(_ => _._Company)
        //    .WithMany()
        //    .HasForeignKey(_ => _.CompanyID)
        //    .OnDelete(DeleteBehavior.SetNull);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql(
            "User ID = postgres; Host = localhost; port = 5432; Database = Retake-Exam-22-23; Pooling = true");
        //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
        //optionsBuilder.EnableSensitiveDataLogging();
    }

    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
}

class Company {
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Country { get; set; }
}

class Product {
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateOnly? Expiry { get; set; }

    public Company? _Company { get; set; }
    public int CompanyID { get; set; }
}

class Customer {
    public int ID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}


class Order {
    public int ID { get; set; }
    public Customer? _Customer { get; set; }
    public int? CustomerID { get; set; }
    public DateTime dateTime { get; set; }
    public bool isOnline { get; set; } //online offline orders
}

class ShoppingCart {
    public Order _Order { get; set; } = null!;
    public int OrderID { get; set; }
    public Product _Product { get; set; } = null!;
    public int ProductID { get; set; }

    public int Quantity { get; set; }
}


class Seed {
    public static void Clear(ExamContext context) {
        Console.WriteLine("Clearing database...");
        context.Companies.RemoveRange(context.Companies);
        context.Customers.RemoveRange(context.Customers);
        context.Products.RemoveRange(context.Products);
        context.Orders.RemoveRange(context.Orders);
        context.ShoppingCarts.RemoveRange(context.ShoppingCarts);
        context.SaveChanges();
        Console.WriteLine("Done!");
    }

    public static void SeedData(ExamContext db, bool flag) {
/*         if(flag) {
            Data.SeedData(db);
            return;
        } */

        if (db is null) {
            Console.WriteLine("ExamContext is null");
            return;
        }

        else {
            Seed.Clear(db);
            SeedCompanies(db);
            SeedCustomers(db);
            SeedProducts(db);
            SeedOrders(db);
        }
    }

    private static void SeedCompanies(ExamContext db) {
        db.Companies.AddRange(
            new Company[] {
                new Company() { ID = 1, Name = "Alpha", Country = "USA" },
                new Company() { ID = 2, Name = "Beta", Country = "NL" },
                new Company() { ID = 3, Name = "Gamma", Country = "nl" },
                new Company() { ID = 4, Name = "Delta", Country = "UK" },
                new Company() { ID = 5, Name = "Eta", Country = "Nl" },
                new Company() { ID = 6, Name = "Zeta", Country = "UK" },
                new Company() { ID = 7, Name = "Unknown" },
                new Company() { ID = 8, Name = "Another", Country = null }
            }
        );
        Console.WriteLine("{0} Companies got added", db.SaveChanges());
    }

    private static void SeedCustomers(ExamContext db) {
        db.Customers.AddRange(
            new Customer[] {
                new Customer() { ID = 1, FirstName = "Joep", LastName = "Johannes" },
                new Customer() { ID = 2, FirstName = "Edgar", LastName = "Joep" },
                new Customer() { ID = 3, FirstName = "Johannah", LastName = "Glenn" },
                new Customer() { ID = 4, FirstName = "Marjory", LastName = "Marjory" },
                new Customer() { ID = 5, FirstName = "Glenn", LastName = "Inez" },
                new Customer() { ID = 6, FirstName = "Tucky", LastName = "Naisby" },
                new Customer() { ID = 7, FirstName = "Sigvard", LastName = "Korney" },
                new Customer() { ID = 8, FirstName = "Korney", LastName = "Tucky" },
                new Customer() { ID = 9, FirstName = "Kathleen", LastName = "Casebourne" },
                new Customer() { ID = 10, FirstName = "Joep", LastName = "Edgar" }
            }
        );
        Console.WriteLine("{0} Customers got added", db.SaveChanges());
    }

    private static void SeedProducts(ExamContext db) {
        db.Products.AddRange(
            new Product[] {
                new Product() {
                    ID = 1, Name = "Coffee - Irish Cream", Price = 74.6m, Expiry = new DateOnly(2022, 10, 26),
                    CompanyID = 3
                },
                new Product() {
                    ID = 2, Name = "Pomegranates", Price = 57.7m, Expiry = new DateOnly(2022, 01, 28), CompanyID = 3
                },
                new Product() {
                    ID = 3, Name = "Fruit Salad Deluxe", Price = 61.2m, Expiry = new DateOnly(2022, 01, 19),
                    CompanyID = 3
                },
                new Product() {
                    ID = 4, Name = "Bread - Roll, Calabrese", Price = 3.9m, Expiry = new DateOnly(2022, 11, 09),
                    CompanyID = 3
                },
                new Product() {
                    ID = 5, Name = "Truffle Cups - White Paper", Price = 13.3m, Expiry = new DateOnly(2022, 10, 26),
                    CompanyID = 2
                },
                new Product() {
                    ID = 6, Name = "Sauce Bbq Smokey", Price = 35.2m, Expiry = new DateOnly(2022, 03, 01), CompanyID = 6
                },
                new Product() {
                    ID = 7, Name = "Chocolate - Chips Compound", Price = 34.9m, Expiry = new DateOnly(2022, 11, 19),
                    CompanyID = 1
                },
                new Product() {
                    ID = 8, Name = "Apple - Custard", Price = 39.0m, Expiry = new DateOnly(2022, 09, 25), CompanyID = 3
                },
                new Product() {
                    ID = 9, Name = "Chicken Breast Wing On", Price = 24.3m, Expiry = new DateOnly(2022, 09, 20),
                    CompanyID = 1
                },
                new Product() {
                    ID = 10, Name = "Chinese Foods - Pepper Beef", Price = 38.8m, Expiry = new DateOnly(2022, 04, 23),
                    CompanyID = 2
                },
                new Product() {
                    ID = 11, Name = "Juice - Pineapple", Price = 10.1m, Expiry = new DateOnly(2022, 11, 30),
                    CompanyID = 4
                },
                new Product() {
                    ID = 12, Name = "Oil - Truffle, White", Price = 13.2m, Expiry = new DateOnly(2022, 02, 17),
                    CompanyID = 4
                },
                new Product() {
                    ID = 13, Name = "Cinnamon - Ground", Price = 16.1m, Expiry = new DateOnly(2022, 09, 06),
                    CompanyID = 1
                },
                new Product() {
                    ID = 14, Name = "Pasta - Gnocchi, Potato", Price = 78.3m, Expiry = new DateOnly(2022, 10, 05),
                    CompanyID = 1
                },
                new Product() {
                    ID = 15, Name = "Cheese - Swiss", Price = 75.7m, Expiry = new DateOnly(2021, 12, 12), CompanyID = 2
                },
                new Product() {
                    ID = 16, Name = "Bagels Poppyseed", Price = 56.3m, Expiry = new DateOnly(2022, 06, 13),
                    CompanyID = 6
                },
                new Product() {
                    ID = 17, Name = "Spice - Onion Powder Granulated", Price = 72.0m,
                    Expiry = new DateOnly(2022, 10, 28), CompanyID = 4
                },
                new Product() {
                    ID = 18, Name = "Beans - Fava, Canned", Price = 54.3m, Expiry = new DateOnly(2022, 08, 19),
                    CompanyID = 2
                },
                new Product() {
                    ID = 19, Name = "Nut - Cashews, Whole, Raw", Price = 88.6m, Expiry = new DateOnly(2022, 03, 29),
                    CompanyID = 5
                },
                new Product() {
                    ID = 20, Name = "Yogurt - Plain", Price = 82.7m, Expiry = new DateOnly(2021, 12, 06), CompanyID = 5
                }
            });
        Console.WriteLine("{0} Products got added", db.SaveChanges());
    }

    private static void SeedOrders(ExamContext db) {
        // for each customer, add random orders, for each order add random products, random quantity.
        //Random rand = new Random();
        //rand.Next(0, 10);
        int randOrders;
        int randProducts;
        int orderSequecne = 0;

        List<Order> OrderList = new List<Order>();
        List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

        db.Customers.ToList().ForEach(c => {
                randOrders = 3; //rand.Next(1, 4);
                //Console.WriteLine($"+{c.ID}======{randOrders} number of orders");
                for (int i = 0; i < randOrders; i++) {
                    OrderList.Add(new Order() {
                        ID = ++orderSequecne,
                        CustomerID = c.ID,
                        dateTime = DateTime.UtcNow,
                        isOnline = true //rand.Next() % 2 == 0
                    });

                    randProducts = 3; //rand.Next(1, 4);
                    //Console.WriteLine($"\t---{orderSequecne} --- {randProducts} number of products");
                    for (int j = 0; j < randProducts;) {
                        var cartItem = new ShoppingCart() {
                            OrderID = orderSequecne,
                            ProductID = 12 + j, //rand.Next(2, 20),
                            Quantity = 1 + 2 * j //and.Next(1, 6)
                        };
                        if (shoppingCartList.FirstOrDefault(_ =>
                                _.OrderID == cartItem.OrderID && _.ProductID == cartItem.ProductID) == null) {
                            try {
                                shoppingCartList.Add(cartItem);
                                //Console.WriteLine($"\t\t---- Oid: {cartItem.OrderID},Pid:{cartItem.ProductID}, Q:{cartItem.Quantity}");
                                j++;
                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine($"ex {cartItem.ProductID}, {cartItem.OrderID}");
                            }
                        }
                    }
                }
            }
        );

        db.Orders.AddRange(OrderList);
        db.ShoppingCarts.AddRange(shoppingCartList);
        Console.WriteLine(
            $"{OrderList.Count()} Orders and {shoppingCartList.Count()} Shoppingcarts Total {db.SaveChanges()} records saved in db ");
    }
}