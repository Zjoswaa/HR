using System;
using System.Diagnostics;

public class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "TestColorExists":
                ColorChecker.ColorExists("black", new() { "red", "black", "blue" });
                break;
            case "TestColorNotExists":
                ColorChecker.ColorExists("green", new() { "red", "black", "blue" });
                break;
            case "TestColorStartingWith":
                ColorChecker.ColorStartingWith("b", new() { "red", "black", "blue" });
                break;
            case "TestColorNotStartingWith":
                ColorChecker.ColorStartingWith("y", new() { "red", "black", "blue" });
                break;

            // CodeTester class
            case "CodeTesterColorExists":
                CodeTester.TestColorExists();
                break;
            case "CodeTesterColorStartingWith":
                CodeTester.TestColorStartingWith();
                break;
            case "CodeTesterLambda":
                CodeTester.TestLambda();
                break;
            default:
                Console.WriteLine("No test found");
                break;
        }
    }
}
