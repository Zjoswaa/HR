using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        //Create a stack of integers
        Stack<int> Stack = new();

        //int to switch on
        int choice;

        do {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add integer to stack");
            Console.WriteLine("2. Remove integer from stack");
            Console.WriteLine("3. View top integer on stack");
            Console.WriteLine("4. View all integers on stack");
            Console.WriteLine("5. Exit program");
            Console.Write("Enter the number of your choice: ");
            choice = int.Parse(Console.ReadLine());

            //Create a switch statement to handle the functions from the menu
            switch (choice) {
                case 1:
                    Console.Write("Number: ");
                    int Number = int.Parse(Console.ReadLine());
                    Stack.Push(Number);
                    break;
                case 2:
                    Stack.Pop();
                    break;
                case 3:
                    Console.WriteLine($"Top integer on stack: {Stack.Peek()}");
                    break;
                case 4:
                    Console.WriteLine("All integers on stack:");
                    foreach (int n in Stack) {
                        Console.WriteLine(n);
                    }
                    break;
            }

        } while (choice != 5);
    }
}
