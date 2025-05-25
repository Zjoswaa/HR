using System.ComponentModel.DataAnnotations.Schema;

public enum Gender {
    Male = 0,
    Female = 1,
    Other = 2
}

public class Employee {
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Column(TypeName = "varchar(5)")]
    public string MiddleInitials { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; }
    [Column(TypeName = "char(9)")]
    public string SSN { get; set; }
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
    public double Salary { get; set; }
    [Column(TypeName = "char(6)")]
    public string DepartmentNumber { get; set; }
    public Department Department { get; set; }
    public IEnumerable<Dependent> Dependents { get; set; }
    public IEnumerable<Department> ManagedDepartments { get; set; }
    public IEnumerable<WorksOn> Schedule { get; set; }
}
