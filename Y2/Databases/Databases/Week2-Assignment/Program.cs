using Microsoft.EntityFrameworkCore;

public class Program {
    public static void Main(string[] args) {
        
    }
}

public class Context : DbContext {
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Dependent> Dependent { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<WorksOn> WorksOn { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string dbName = "Week2-DB";
        optionsBuilder.UseNpgsql($"User ID=postgres;Host=127.0.0.1;Port=5432;Database={dbName};Pooling=true;");
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
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
