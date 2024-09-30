class Doctor {
    private static Dictionary<string, int> LastID = new() {
        {"CAR", 0},
        {"NEU", 0},
        {"ONC", 0},
        {"OTH", 0}
    };

    public const string DefaultSupervisorId = "-";
    public readonly string Id;
    public string Name;
    public string Department;
    public readonly List<Patient> AssignedPatients = [];
    public readonly List<Doctor> Supervisees = [];
    public string SupervisorId = DefaultSupervisorId;
    

    public Doctor(string Name, string Department) {
        switch (Department) {
            case "Cardiology":
                LastID["CAR"]++;
                this.Id = $"CAR{LastID["CAR"]:D3}";
                break;
            case "Neurology":
                LastID["NEU"]++;
                this.Id = $"NEU{LastID["NEU"]:D3}";
                break;
            case "Oncology":
                LastID["ONC"]++;
                this.Id = $"ONC{LastID["ONC"]:D3}";
                break;
            default:
                LastID["OTH"]++;
                this.Id = $"OTH{LastID["OTH"]:D3}";
                break;
        }
        this.Name = Name;
        this.Department = Department;
    }
}
