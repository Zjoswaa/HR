using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "ReadOnly": TestReadOnly(); return;
            case "Constant": TestConstant(); return;
            case "PatientID": TestPatientId(); return;
            case "DoctorID": TestDoctorId(Convert.ToInt32(args[2])); return;
            case "Hospital": TestHospital(); return;
            case "RemovePatient": TestRemovePatient(); return;
            case "RemoveDoctor": TestRemoveDoctor(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        };
    }

    public static void TestReadOnly() {
        Console.WriteLine("=== Patient ===");
        Type clsType = typeof(Patient);
        PrintIsFieldReadOnly(clsType, "Id");

        Console.WriteLine("\n=== Doctor ===");
        clsType = typeof(Doctor);
        PrintIsFieldReadOnly(clsType, "Id");
        PrintIsFieldReadOnly(clsType, "AssignedPatients");
        PrintIsFieldReadOnly(clsType, "Supervisees");

        Console.WriteLine("\n=== Hospital ===");
        clsType = typeof(Hospital);
        PrintIsFieldReadOnly(clsType, "Doctors");
        PrintIsFieldReadOnly(clsType, "UnassignedPatients");
        PrintIsFieldReadOnly(clsType, "Departments");
    }

    public static void TestConstant() {
        Type clsType = typeof(Doctor);
        PrintIsFieldConstant(clsType, "DefaultSupervisorId");

        clsType = typeof(Hospital);
        PrintIsFieldConstant(clsType, "Name");
    }

    public static void TestPatientId() {
        List<Patient> patients = [];
        for (int i = 0; i < 100; i++) {
            patients.Add(new Patient("John Doe", 25));
        }

        Console.WriteLine($"Patient ID of patient #1: {patients[0].Id}");
        Console.WriteLine($"Patient ID of patient #5: {patients[4].Id}");
        Console.WriteLine($"Patient ID of patient #10: {patients[9].Id}");
        Console.WriteLine($"Patient ID of patient #100: {patients[99].Id}");
    }

    public static void TestDoctorId(int seed) {
        Random rand = new(seed);
        List<string> departments = [];
        departments.AddRange(Hospital.Departments);
        departments.Add("Anesthetics");

        List<Doctor> doctors = [];
        for (int i = 0; i < 999; i++) {
            doctors.Add(new("John Doe", departments[rand.Next(0, departments.Count)]));
        }
        for (int i = doctors.Count - 5; i < doctors.Count; i++) {
            Console.WriteLine(doctors[i].Id);
        }
    }

    public static void TestHospital() {
        Console.WriteLine("=== Name ===");
        Console.WriteLine(Hospital.Name);

        Console.WriteLine("\n=== Departments ===");
        foreach (string department in Hospital.Departments) {
            Console.WriteLine(department);
        }

        Console.WriteLine("\n=== Adding doctors and patients ===");
        Doctor doctor = new("Harleen Quinzel", "Psychiatry");
        Hospital.AddDoctor(doctor);
        // Why take the last doctor? It's a remnant of a previous version
        // of this assignment with pre-existing doctors in a JSON file.
        Doctor lastAddedDoctor = Hospital.Doctors[^1]; // Take last doctor in list
        Console.WriteLine($"Doctor's name: {lastAddedDoctor.Name}");
        Console.WriteLine("\nAdding doctor again");
        Hospital.AddDoctor(doctor);

        Console.WriteLine();
        Patient patient = new("Joseph Kerr", 44);
        Hospital.AddPatient(patient);
        Patient lastAddedPatient = Hospital.UnassignedPatients[^1];
        Console.WriteLine($"Patient's name: {lastAddedPatient.Name}");

        Console.WriteLine("\nAdding patient again");
        Hospital.AddPatient(patient);

        Console.WriteLine("\n=== Assigning doctors to patients ===");
        List<Patient> patients = [
            new("Pamela Lillian Isley", 28),
            new("Harvey Dent", 26),
            new("Jonathan Crane", 35),
            new("Edward Nygma", 37),
        ];

        Console.WriteLine("Attempting to assign to a non-existing doctor...");
        foreach (var pat in patients) {
            Hospital.AssignDoctorToPatient(doctor.Id, pat.Id);
        }

        Hospital.AddDoctor(doctor);
        Console.WriteLine("\nAttempting to add non-registered patients...");
        foreach (var pat in patients) {
            Hospital.AssignDoctorToPatient(doctor.Id, patient.Id);
        }

        Console.WriteLine("\nAdding and assigning patients...");
        foreach (var pat in patients) {
            Hospital.AddPatient(pat);
            Hospital.AssignDoctorToPatient(doctor.Id, pat.Id);
        }

        Console.WriteLine("\nAttempting to add the patients to the same doctor...");
        foreach (var pat in patients) {
            Hospital.AssignDoctorToPatient(doctor.Id, pat.Id);
        }

        Console.WriteLine();
        Doctor anotherDoc = new("Thomas Alan Wayne", "Misc");
        Hospital.AddDoctor(anotherDoc);
        Console.WriteLine("Attempting to assign already assigned patient to another doctor...");
        foreach (var pat in patients) {
            Hospital.AssignDoctorToPatient(anotherDoc.Id, pat.Id);
        }

        Console.WriteLine("\nAttempting to assign patients to doctors when either or both don't exist...");
        Hospital.AssignDoctorToPatient(anotherDoc.Id, "PAT---");
        Console.WriteLine();
        Hospital.AssignDoctorToPatient("CAR---", patient.Id);
        Console.WriteLine();
        Hospital.AssignDoctorToPatient("CAR---", "PAT---");

        Console.WriteLine("\nAssigning supervisees to supervisor...");
        Console.WriteLine($"{doctor.Name} has {doctor.Supervisees.Count} supervisees");

        Doctor yetAnotherDoc = new("Leslie Maurin Thompkins", "Emergency");
        Hospital.AddDoctor(yetAnotherDoc);
        Hospital.AssignSuperviseeToSupervisor(anotherDoc.Id, doctor.Id);
        Hospital.AssignSuperviseeToSupervisor(yetAnotherDoc.Id, doctor.Id);

        Console.WriteLine($"{doctor.Name} has {doctor.Supervisees.Count} supervisees:");
        foreach (var supervisee in doctor.Supervisees) {
            Console.WriteLine($" - {supervisee.Name}");
        }

        Console.WriteLine("\nAttempting to assign supervisees to supervisors when either or both don't exist...");
        Hospital.AssignSuperviseeToSupervisor(yetAnotherDoc.Id, "NEU---");
        Hospital.AssignSuperviseeToSupervisor("CAR---", doctor.Id);
        Hospital.AssignSuperviseeToSupervisor("CAR---", "NEU---");

        Console.WriteLine($"\n{anotherDoc.Name}'s supervisor ID: {anotherDoc.SupervisorId}");
        Console.WriteLine($"{yetAnotherDoc.Name}'s supervisor ID: {yetAnotherDoc.SupervisorId}");
    }

    public static void TestRemovePatient() {
        List<Patient> patients = [
            new("Jackie Chan", 31),
            new("Viggo Mortensen", 44),
            new("Sylverster Stallone", 34),
        ];

        foreach (Patient pat in patients) {
            Hospital.AddPatient(pat);
        }

        Patient lastAddedPatient = Hospital.UnassignedPatients[^1];
        Console.WriteLine($"\nLast patient's name: {lastAddedPatient.Name}");

        Hospital.RemovePatient(lastAddedPatient.Id);
        lastAddedPatient = Hospital.UnassignedPatients[^1];
        Console.WriteLine($"Last patient's name: {lastAddedPatient.Name}");
    }

    public static void TestRemoveDoctor() {
        Doctor doctor = new("Charley Dixon", "Surgery");
        Hospital.AddDoctor(doctor);

        List<Patient> patients = [
            new("John Connor", 44),
            new("Sarah J. Connor", 19),
            new("Kyle Reese", 26),
        ];

        foreach (var patient in patients) {
            Hospital.AddPatient(patient);
            Hospital.AssignDoctorToPatient(doctor.Id, patient.Id);
        }

        Console.WriteLine($"\nDr. {doctor.Name}'s assigned patients:");
        foreach (var patient in doctor.AssignedPatients) {
            Console.WriteLine($" - Patient ID: {patient.Id}");
        }

        Doctor anotherDoc = new("Peter Silberman", "Psychiatry");
        Doctor yetAnotherDoc = new("Boyd Sherman", "Psychology");
        Hospital.AddDoctor(anotherDoc);
        Hospital.AddDoctor(yetAnotherDoc);

        Hospital.AssignSuperviseeToSupervisor(anotherDoc.Id, doctor.Id);
        Hospital.AssignSuperviseeToSupervisor(yetAnotherDoc.Id, doctor.Id);

        foreach (var supervisee in doctor.Supervisees) {
            Console.WriteLine($"{supervisee.Name}'s supervisor: {supervisee.SupervisorId}");
        }

        Console.WriteLine("\nRemoving doctor/supervisee from the hospital...");
        Hospital.RemoveDoctor(yetAnotherDoc.Id);
        foreach (var supervisee in doctor.Supervisees) {
            Console.WriteLine($"{supervisee.Name}'s supervisor: {supervisee.SupervisorId}");
        }

        Console.WriteLine("\nRemoving doctor/supervisor from the hospital...");
        Hospital.RemoveDoctor(doctor.Id);

        Console.WriteLine($"\nLast {patients.Count} unassigned patients:");
        for (int i = patients.Count; i > 0; i--) {
            Console.WriteLine($" - Patient ID: {Hospital.UnassignedPatients[^i].Id}");
        }

        foreach (var supervisee in doctor.Supervisees) {
            Console.WriteLine($"{supervisee.Name}'s supervisor: {supervisee.SupervisorId}");
        }
    }

    private static void PrintIsFieldReadOnly(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"{info.Name} is a read-only field: " +
                info.IsInitOnly);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }

    private static void PrintIsFieldConstant(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"{info.Name} is a constant field: " +
                info.IsLiteral);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }
}
