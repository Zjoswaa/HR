using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project {
    public string Pname { get; set; }
    [Key]
    public int Pno { get; set; }
    public string Plocation { get; set; }
    [ForeignKey("Department")]
    public int Dno { get; set; }
    
    // Navigation Properties
    public Department Department { get; set; }
    public ICollection<WorksOn> WorksOn { get; set; }
}
