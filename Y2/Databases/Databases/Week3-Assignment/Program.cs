using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

public class Program {
    public static void Main(string[] args) {
        using (var db = new Context()) {
            // db.Employees.Add(new Employee() { FirstName = "Jane", MiddleInitials = "J.", LastName = "Doe", Gender = Gender.Female, SSN = "987654321", Salary = 24.14, Address = "Foo Lane 3, Barcity", BirthDate = new DateTime(2001, 7, 28), DepartmentNumber = "111111"});
            // Console.WriteLine($"{db.SaveChanges()} writes saved");
            List<Employee> employees = db.Employees.ToList();
            foreach (Employee employee in employees) {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} ({employee.SSN})");
            }
        }
    }
}

public class Context : DbContext {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Dependent> Dependents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentLocation> DepartmentLocations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<WorksOn> WorksOn { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string dbName = "Week3-DB";
        optionsBuilder.UseNpgsql($"User ID=postgres;Host=127.0.0.1;Port=5432;Database={dbName};Pooling=true;");
        // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.SSN);

        modelBuilder.Entity<Dependent>()
            .HasKey(d => new { d.EmployeeSSN, d.DependentName });

        modelBuilder.Entity<Department>()
            .HasKey(d => d.Number);

        modelBuilder.Entity<DepartmentLocation>()
            .HasKey(l => new { l.DepartmentNumber, l.Location });

        modelBuilder.Entity<Project>()
            .HasKey(p => p.Number);

        modelBuilder.Entity<WorksOn>()
            .HasKey(wo => new { wo.EmployeeSSN, wo.ProjectNumber });

        modelBuilder.Entity<Dependent>()
            .HasOne(d => d.Employee)
            .WithMany(e => e.Dependents)
            .HasForeignKey(d => d.EmployeeSSN);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithMany(e => e.ManagedDepartments)
            .HasForeignKey(d => d.ManagerSSN);

        modelBuilder.Entity<DepartmentLocation>()
            .HasOne(l => l.Department)
            .WithMany(d => d.Locations)
            .HasForeignKey(l => l.DepartmentNumber);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Department)
            .WithMany(d => d.Projects)
            .HasForeignKey(p => p.DepartmentNumber);

        modelBuilder.Entity<WorksOn>()
            .HasOne(wo => wo.Employee)
            .WithMany(e => e.Schedule)
            .HasForeignKey(wo => wo.EmployeeSSN);

        modelBuilder.Entity<WorksOn>()
            .HasOne(wo => wo.Project)
            .WithMany(e => e.Developers)
            .HasForeignKey(wo => wo.ProjectNumber);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentNumber);
    }
}
