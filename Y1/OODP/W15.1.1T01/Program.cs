Console.Write("Input string: ");
var str = Console.ReadLine();

var frequencies =
    from c in str
    group c by c into g
    select new { Character = g.Key, Frequency = g.Count() };

foreach (var item in frequencies) {
    Console.WriteLine($"Char [{item.Character}]: {item.Frequency}");
}
