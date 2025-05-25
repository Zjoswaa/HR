using System.ComponentModel.DataAnnotations.Schema;

public class Project {
    [Column(TypeName = "varchar(20)")] public string Name { get; set; }
    [Column(TypeName = "char(6)")] public string Number { get; set; }
    public string Location { get; set; }
    [Column(TypeName = "char(6)")] public string DepartmentNumber { get; set; }
    public Department Department { get; set; }
    public IEnumerable<WorksOn> Developers { get; set; }
}
