using System.ComponentModel.DataAnnotations.Schema;

public class WorksOn {
    [ForeignKey("Employee")]
    public int Essn { get; set; }
    [ForeignKey("Project")]
    public int Pno { get; set; }
    public int Hours { get; set; }
    
    // Navigation Properties
    public Employee Employee { get; set; }
    public Project Project { get; set; }
}
