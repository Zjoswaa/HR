using System.ComponentModel.DataAnnotations.Schema;

public class WorksOn {
    [Column(TypeName = "char(9)")] public string EmployeeSSN { get; set; }
    [Column(TypeName = "char(6)")] public string ProjectNumber { get; set; }
    public int Hours { get; set; }
    public Employee Employee { get; set; }
    public Project Project { get; set; }
}
