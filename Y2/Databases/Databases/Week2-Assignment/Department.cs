using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Department {
    public string Dname { get; set; }
    [Key]
    public int Dnumber { get; set; }
    [ForeignKey("Employee")]
    public int Mgr_ssn { get; set; }
    public DateTime Mgr_start_date { get; set; }
    
    // Navigation Properties
    public Employee Manager { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<DeptLocations> Locations { get; set; }
    public ICollection<Project> Projects { get; set; }
}
