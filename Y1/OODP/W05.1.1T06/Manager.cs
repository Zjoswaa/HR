public class Manager : Employee {
    public int DirectReportsCount;

    public Manager(int id, string name, string position, int directReportsCount)
        : base(id, name, position) => DirectReportsCount = directReportsCount;
}
