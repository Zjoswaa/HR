using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee {
    public string Fname { get; set; }
    public char Minit { get; set; }
    public string Lname { get; set; }
    [Key]
    public int Ssn { get; set; }
    public DateTime Bdate { get; set; }
    public string Address { get; set; }
    public char Sex { get; set; }
    public int Salary { get; set; }
    [ForeignKey("Employee")]
    public int Super_ssn { get; set; }
    [ForeignKey("Department")]
    public int Dno { get; set; }
    
    // Navigation Properties
    public Department Department { get; set; }
    public Employee Supervisor { get; set; }
    public ICollection<Employee> Subordinates { get; set; }
    public ICollection<Dependent> Dependents { get; set; }
    public ICollection<WorksOn> WorksOn { get; set; }
}
