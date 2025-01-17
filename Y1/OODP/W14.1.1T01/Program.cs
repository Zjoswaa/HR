using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        // Create a dictionary to store contact information
        Dictionary<string, string> Contacts = new();

        // Prompt the user for input and perform the requested operation
        bool quit = false;
        while (!quit) {
            Console.WriteLine("Enter a command (add, view, remove, list, quit):");
            string command = Console.ReadLine();

            if (command == "add") {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Phone number: ");
                string PhoneNumber = Console.ReadLine();
                Contacts[Name] = PhoneNumber;
            }
            else if (command == "view") {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                if (!Contacts.ContainsKey(Name)) {
                    Console.WriteLine("Contact not found");
                    continue;
                }
                Console.WriteLine($"Phone number: {Contacts[Name]}");
            }
            else if (command == "remove") {
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Contacts.Remove(Name);
            }
            else if (command == "list") {
                foreach (KeyValuePair<string, string> KVP in Contacts) {
                    Console.WriteLine($"{KVP.Key}: {KVP.Value}");
                }
            }
            else if (command == "quit") {
                quit = true;
            }
            else {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}
