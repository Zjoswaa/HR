using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Dno), nameof(Dlocation))]
public class DeptLocations {
    [ForeignKey("Department")]
    public int Dno { get; set; }
    public string Dlocation { get; set; }
    
    // Navigation Properties
    public Department Department { get; set; }
}
