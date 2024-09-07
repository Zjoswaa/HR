string input;
do {
    Console.WriteLine("Really delete this file? (y/n)");
    input = Console.ReadLine();
} while (input != "y" && input != "n");

if (input == "y") {
    Console.WriteLine("File deleted");
}
