Console.WriteLine("Enter an age: ");

if (int.TryParse(Console.ReadLine(), out int age)) {
    string category = age switch {
        >= 0 and <= 12 => "a child",
        >= 13 and <= 19 => "a teenager",
        >= 20 and <= 150 => "an adult",
        _ => "Invalid"
    };

    Console.WriteLine($"Age {age}: {category}");
} else {
    Console.WriteLine("Please enter a valid number.");
}
