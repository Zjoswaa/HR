Console.WriteLine("Give some text");
string text = Console.ReadLine();

Console.WriteLine("What do you want to do with this text?");
Console.WriteLine("U: make all uppercase");
Console.WriteLine("L: make all lowercase");
Console.WriteLine("Any other key: do not change");
string choice = Console.ReadLine();

if (choice.ToUpper() == "U") {
    text = text.ToUpper();
} else if (choice.ToUpper() == "L") {
    text = text.ToLower();
}

Console.WriteLine(text);
