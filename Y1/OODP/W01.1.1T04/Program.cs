Console.WriteLine("What is your age?");
int myAge = int.Parse(Console.ReadLine());
Console.WriteLine("What is the age of the student next to you?");
int theirAge = int.Parse(Console.ReadLine());
Console.WriteLine(myAge == theirAge ? "Your ages are equal" : (myAge > theirAge ? "You are older" : "You are younger"));
