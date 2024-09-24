class Program {
    public static void Main() {
        var john = new Person("John Doe");
        for (int i = 0; i < 5; i++)
            john.GrowOlder();
        var bicycle = new Bicycle(null, "abc123", "Red");
        bicycle.Paint("Blue");
        bicycle.ChangeOwner(john);
        bicycle.ChangeGear(2);

        Console.WriteLine($"The bicycle's owner is {bicycle.Owner.Name}, who is {bicycle.Owner.Age}");
        Console.WriteLine($"The bicycle is in gear {bicycle.CurrentGear}");
    }
}
