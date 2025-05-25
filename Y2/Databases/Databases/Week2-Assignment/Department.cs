using System.ComponentModel.DataAnnotations.Schema;

public class Department {
    [Column(TypeName = "varchar(20)")]
    public string Name { get; set; }
    [Column(TypeName = "char(6)")]
    public string Number { get; set; }
    [Column(TypeName = "char(9)")]
    public string ManagerSSN { get; set; }
    [Column(TypeName = "date")]
    public DateTime ManagerStartDate { get; set; }
    public Employee Manager { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<DepartmentLocation> Locations { get; set; }
    public IEnumerable<Project> Projects { get; set; }
}
