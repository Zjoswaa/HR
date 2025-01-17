using System.Reflection;

public class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "TYPE": CheckType(); break;
            case "DIMS": CheckDimensions(); break;
            case "PROP": CheckProperty(); break;
            case "ALL":
                CheckType();
                CheckProperty();
                CheckDimensions();
                break;
            default: throw new ArgumentException();
        }
    }

    public static void CheckType() {
        Type type = typeof(GrayscaleImage).GetProperty("PixelData").PropertyType;
        Console.WriteLine("PixelData is a multidimensional array: "
                          + (type.IsArray && type.GetArrayRank() > 1));
    }

    public static void CheckProperty() {
        PropertyInfo propertyInfo = typeof(GrayscaleImage).GetProperty("PixelData");
        Console.WriteLine("PixelData is read-only: " + !propertyInfo.CanWrite);
    }

    public static void CheckDimensions() {
        GrayscaleImage img = new(200, 300);
        Console.WriteLine("Height: " + img.PixelData.GetLength(0));
        Console.WriteLine("Width: " + img.PixelData.GetLength(1));
    }
}
