class Person {
    public string Name;
    public Job DayJob;

    public Person(string Name, Job DayJob) {
        this.Name = Name;
        this.DayJob = DayJob;
    }

    public string Info() {
        if (this.DayJob == null) {
            return $"{this.Name} is in between jobs";
        }
        return $"{this.Name} works as a {this.DayJob.Name}";
    }
}
