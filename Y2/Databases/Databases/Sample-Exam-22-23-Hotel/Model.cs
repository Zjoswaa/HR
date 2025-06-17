using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

class HotelContext : DbContext {
    public DbSet<RoomType> roomType { get; set; } = null!;
    public DbSet<Room> rooms { get; set; } = null!;
    public DbSet<Guest> guests { get; set; } = null!;
    public DbSet<Booking> bookings { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=;Host=localhost;port=5432;Database=AnotherHotel;Pooling=true");
        //optionsBuilder.LogTo(System.Console.WriteLine, LogLevel.Critical);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        //Solution 7a 
        //Relation Boss(employee) - Employee (One To Many)
        //CASCADE behaviour

        //7b
        //Relation Employee - Bookings (One To Many)
        //CASCADE behaviour
    }

    //Solution 7a Table Employee:
    
}

class RoomType
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public int Occupancy { get; set; }
    public decimal Price { get; set; }

    //Collection navigation properties
    public virtual List<Room>? Rooms { get; set; }

}

class Room
{
    [Key]
    public int Number { get; set; }
    public int Floor { get; set; }

    //Reference navigation property
    [ForeignKey("RoomTypeId")]
    public RoomType roomType { get; set; } = null!;
    public int RoomTypeId { get; set; }

    //Collection navigation properties
    public virtual List<Booking>? Bookings { get; set; }
}

class Guest { 
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Country { get; set; } 

    //Collection navigation properties
    public virtual List<Booking>? Bookings { get; set; }
}

class Booking { 
    public int Id { get; set; }
    [Required]
    public DateOnly BookingDate { get; set; }
    [Required]
    public int Nights { get; set; }

    //Reference navigation property
    public Guest guest { get; set; } = null!;
    public int GuestID { get; set; }

    //Reference navigation property
    [ForeignKey("RoomNumber")]
    public Room room { get; set; } = null!;
    public int RoomNumber { get; set; }

    //7b: Modify booking table, add EmployeeID as foreign key 

}

// 7a Employee Class not yet complete 

class Employee { 
    public int ID { get; set; }
    [Required, DataType("varchar(50)")]
    public string Name { get; set; } = null!;
    
    public int? BossID { get; set; }

    public Employee(int iD, string name) {
        ID = iD;
        Name = name;
    }
    public Employee(int id, string name, int bossID) 
        : this(id, name) => BossID = bossID;
}
