using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Essn), nameof(Dependent_name))]
public class Dependent {
    [ForeignKey("Employee")]
    public int Essn { get; set; }
    public string Dependent_name { get; set; }
    public char Sex { get; set; }
    public DateTime Bdate { get; set; }
    public string Relationship { get; set; }
    
    // Navigation Properties
    public Employee Employee { get; set; }
}
