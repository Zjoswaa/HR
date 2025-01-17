public class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "1.2": Test1(); break;
            case "0.75": Test2(); break;
            default: throw new ArgumentException();
        }
    }

    public static void Test1() {
        GrayscaleImage img = new(
            new int[,] {
                { 10, 20, 30, },
                { 15, 25, 35, },
                { 20, 25, 30, },
            });
        img.AdjustBrightness(1.2);

        Console.WriteLine("Pixel values:");
        foreach (int pixel in img.PixelData) {
            Console.WriteLine(pixel);
        }
    }

    public static void Test2() {
        GrayscaleImage img = new(
            new int[,] {
                { 120, 110, 110, 110 },
                { 110, 100, 100, 90, },
                { 100, 100, 90, 90, },
            });
        img.AdjustBrightness(0.75);

        Console.WriteLine("Pixel values:");
        foreach (int pixel in img.PixelData) {
            Console.WriteLine(pixel);
        }
    }
}
