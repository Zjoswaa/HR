using System;

class Program {
    public static void Main() {
        var jobs = new List<Job> {
            new Job("Waiter", 25000.0),
            new Job("Clown", 10000.0),
            new Job("Developer", 90000.0),
        };

        Person person = new Person("Jane", jobs[0]);
        Console.WriteLine(person.Info());

        for (int i = 1; i < jobs.Count; i++) {
            person.DayJob = person.DayJob.BiggestSalary(jobs[i]);
        }
        Console.WriteLine(person.Info());

        person.DayJob = null;
        Console.WriteLine(person.Info());
    }
}
