static class Hospital {
    public const string Name = "Erasmus MC";
    public static readonly List<Doctor> Doctors = [];
    public static readonly List<Patient> UnassignedPatients = [];
    public static readonly List<string> Departments = ["Cardiology", "Neurology", "Oncology"];

    public static void AddDoctor(Doctor Doctor) {
        if (Doctors.Find(d => d.Id == Doctor.Id) != null) {
            Console.WriteLine($"Doctor {Doctor.Id} already works in the hospital");
            return;
        }
        Doctors.Add(Doctor);
        Console.WriteLine($"Doctor {Doctor.Id} has been added");
    }

    public static void RemoveDoctor(string DoctorID) {
        Doctor? ToRemove = Doctors.Find(d => d.Id == DoctorID);
        if (ToRemove == null) {
            Console.WriteLine($"Doctor with ID {DoctorID} not found");
            return;
        }

        // Add doctors assigned patients back in UnassignedPatients
        foreach (Patient Patient in ToRemove.AssignedPatients) {
            UnassignedPatients.Add(Patient);
        }

        // Any doctors that this doctor supervised need to have their SupervisorId reset
        foreach (Doctor Doctor in ToRemove.Supervisees) {
            Doctor.SupervisorId = Doctor.DefaultSupervisorId;
        }

        // Remove doctor
        Doctors.Remove(ToRemove);
        Console.WriteLine($"Doctor {DoctorID} has been removed");
    }

    public static void AddPatient(Patient Patient) {
        // Check if patient with the same id is already in UnassignedPatients
        if (UnassignedPatients.Find(p => p.Id == Patient.Id) != null) {
            Console.WriteLine($"Patient {Patient.Id} is already registered in the hospital");
            return;
        }

        // Check if there is already a doctor with an assigned patient that has the same id
        foreach (Doctor Doctor in Doctors) {
            if (Doctor.AssignedPatients.Find(p => p.Id == Patient.Id) != null) {
                Console.WriteLine($"Patient {Patient.Id} is already assigned to doctor {Doctor.Id}");
                return;
            }
        }

        // Else we can add the patient to UnassignedPatients
        UnassignedPatients.Add(Patient);
        Console.WriteLine($"Patient {Patient.Id} registered in the hospital");
    }

    public static void RemovePatient(string PatientID) {
        // Check if a patient with this id is in UnassingedPatients
        Patient? ToRemove = UnassignedPatients.Find(p => p.Id == PatientID);
        if (ToRemove != null) {
            UnassignedPatients.Remove(ToRemove);
            Console.WriteLine($"Patient {PatientID} has been removed");
            return;
        }

        // Check if there is a doctor that this patient has been assigned to
        foreach (Doctor Doctor in Doctors) {
            ToRemove = Doctor.AssignedPatients.Find(p => p.Id == PatientID);
            if (ToRemove != null) {
                Doctor.AssignedPatients.Remove(ToRemove);
                Console.WriteLine($"Patient {PatientID} has been removed");
                return;
            }
        }

        // Else there was no patient found with that id
        Console.WriteLine($"Patient with ID {PatientID} not found");
    }

    public static void AssignDoctorToPatient(string DoctorID, string PatientID) {
        bool Failed = false;

        // The doctor does not exists
        if (Doctors.Find(d => d.Id == DoctorID) == null) {
            Console.WriteLine($"Doctor with ID {DoctorID} not found");
            Failed = true;
        }

        // The patient is already assigned to another doctor
        foreach (Doctor Doctor in Doctors) {
            if (Doctor.AssignedPatients.Find(p => p.Id == PatientID) != null) {
                //Console.WriteLine($"Patient {PatientID} is already assigned to doctor {Doctor.Id}");
                Failed = true;
            }
        }

        // The patient is not in UnassignedPatients
        if (UnassignedPatients.Find(p => p.Id == PatientID) == null) {
            Console.WriteLine($"Patient with ID {PatientID} not found");
            Failed = true;
        }

        if (Failed) {
            return;
        }

        // Else the patient and doctor exist and the patient is not yet assigned to a doctor
        // Add the patient to the doctors assigned patients
        Doctors.Find(d => d.Id == DoctorID)?.AssignedPatients.Add(UnassignedPatients.Find(p => p.Id == PatientID)!);
        // Remove the patient from UnassignedPatients
        UnassignedPatients.RemoveAll(p => p.Id == PatientID);
        Console.WriteLine($"Patient {PatientID} is assigned to doctor {DoctorID}");
    }

    //                                              He is supervised     He supervises
    public static void AssignSuperviseeToSupervisor(string SuperviseeID, string SupervisorID) {
        // Check if both doctors exist
        Doctor? Supervisee = Doctors.Find(d => d.Id == SuperviseeID);
        Doctor? Supervisor = Doctors.Find(d => d.Id == SupervisorID);
        if (Supervisee == null || Supervisor == null) {
            Console.WriteLine("Doctor(s) not found:");
            if (Supervisee == null) {
                Console.WriteLine($" - {SuperviseeID}");
            }
            if (Supervisor == null) {
                Console.WriteLine($" - {SupervisorID}");
            }
            return;
        }

        // Else both doctors exist, add the supervisee to the supervisor
        Doctors.Find(d => d.Id == SuperviseeID)!.SupervisorId = SupervisorID;
        Doctors.Find(d => d.Id == SupervisorID)?.Supervisees.Add(Doctors.Find(d => d.Id == SuperviseeID)!);
        Console.WriteLine($"Added {SuperviseeID} to supervisor {SupervisorID}");
    }
}
