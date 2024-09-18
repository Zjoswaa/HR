using System;

class Program {
    static void Main() {
        var dnaA = new DNA("ACGT");
        var dnaB = dnaA.Replicate1();
        dnaA.Mutate("TCGT");
        CompareDNA(dnaA, dnaB);

        var dnaC = new DNA("CGTA");
        var dnaD = dnaC.Replicate2();
        dnaC.Mutate("CCGA");
        CompareDNA(dnaC, dnaD);
    }

    static void CompareDNA(DNA dna1, DNA dna2) {
        Console.WriteLine($"{dna1.Seq} and {dna2.Seq} are {(dna1.Seq == dna2.Seq ? "" : "not ")}the same sequence");
        Console.WriteLine($"dna1 and dna2 are {(dna1 == dna2 ? "" : "not ")}the same");
    }
}
