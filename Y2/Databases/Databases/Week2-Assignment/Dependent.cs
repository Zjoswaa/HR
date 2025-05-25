using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Dependent {
    [Column(TypeName = "char(9)")]
    public string EmployeeSSN { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string DependentName { get; set; }
    public Gender Gender { get; set; }
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }
    public string Relationship { get; set; }
    public Employee Employee { get; set; }
}
