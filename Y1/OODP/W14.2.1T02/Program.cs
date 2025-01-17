string[] persons = { "Dave", "John", "Peter", "Johanna", "Bart", "Henk", "Marie" };
string[] students = { "Dave", "Michael", "Roxanne", "Johanna", "John", "Bart", "Henk" };

Console.WriteLine("These names are in both datasets:");
foreach (string Name in persons.Intersect(students)) {
    Console.WriteLine(Name);
}

Console.WriteLine("\nThese names are unique:");
foreach (string Name in persons.Union(students).OrderBy(n => n)) {
    Console.WriteLine(Name);
}
