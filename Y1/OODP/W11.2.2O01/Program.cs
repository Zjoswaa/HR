public class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Batch1":
                TestBatch1();
                return;
            case "Batch2":
                TestBatch2();
                return;
            default: throw new ArgumentException();
        }
    }

    static void TestBatch1() {
        Person[,] persons = new Person[3, 3];

        persons[0, 0] = new Person("Alice", 30);
        persons[0, 1] = new Person("Bob", 25);
        persons[0, 2] = new Person("Charlie", 35);
        persons[1, 0] = new Person("David", 22);
        persons[1, 1] = new Person("Eve", 40);
        persons[1, 2] = new Person("Frank", 28);
        persons[2, 0] = new Person("Grace", 32);
        persons[2, 1] = new Person("Helen", 29);
        persons[2, 2] = new Person("Ivy", 37);

        PersonManager.SortAndDisplayPersonsByAge(persons);
    }

    static void TestBatch2() {
        Person[,] persons = new Person[2, 2];

        persons[0, 0] = new Person("John", 45);
        persons[0, 1] = new Person("Kate", 38);
        persons[1, 0] = new Person("Liam", 31);
        persons[1, 1] = new Person("Mia", 27);

        PersonManager.SortAndDisplayPersonsByAge(persons);
    }
}
