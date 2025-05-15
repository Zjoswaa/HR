using Microsoft.EntityFrameworkCore;

public class Context : DbContext {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DeptLocations> DeptLocations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<WorksOn> WorksOn { get; set; }
    public DbSet<Dependent> Dependents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string dbName = "Week2-DB";
        optionsBuilder.UseNpgsql($"User ID=postgres;Host=127.0.0.1;Port=5432;Database={dbName};Pooling=true;");
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Employee -> Supervisor
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Supervisor)
            .WithMany(e => e.Subordinates)
            .HasForeignKey(e => e.Super_ssn)
            .OnDelete(DeleteBehavior.Restrict);

        // Employee -> Department
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.Dno);

        // Department -> Manager
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.Mgr_ssn);

        // Department -> DeptLocation
        modelBuilder.Entity<DeptLocations>()
            .HasKey(dl => new { dl.Dno, dl.Dlocation });

        modelBuilder.Entity<DeptLocations>()
            .HasOne(dl => dl.Department)
            .WithMany(d => d.Locations)
            .HasForeignKey(dl => dl.Dno);

        // WorksOn Composite Key
        modelBuilder.Entity<WorksOn>()
            .HasKey(wo => new { wo.Essn, wo.Pno });

        // Dependent Composite Key
        modelBuilder.Entity<Dependent>()
            .HasKey(d => new { d.Essn, d.Dependent_name });
    }
}
