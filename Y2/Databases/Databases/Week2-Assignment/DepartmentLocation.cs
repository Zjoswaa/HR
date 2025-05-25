using System.ComponentModel.DataAnnotations.Schema;

public class DepartmentLocation {
    [Column(TypeName = "char(6)")]
    public string DepartmentNumber { get; set; }
    [Column(TypeName = "varchar(20)")]
    public string Location { get; set; }
    public Department Department { get; set; }
}
