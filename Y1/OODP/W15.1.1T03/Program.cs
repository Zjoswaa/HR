Console.Write("Input string: ");
var str = Console.ReadLine();

var frequencies =
    from c in str
    group c by c
    into g
    orderby g.Count()
    select new { Character = g.Key, Frequency = g.Count() };

Console.WriteLine(frequencies.Last().Character);
