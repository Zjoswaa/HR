using Newtonsoft.Json;

static class Calculator {
    public static double Add(double a, double b) {
        return a + b;
    }

    public static double Subtract(double a, double b) {
        return a - b;
    }

    public static double Multiply(double a, double b) {
        return a * b;
    }

    public static double Divide(double a, double b) {
        return a / b;
    }

    public static double Modulo(double a, double b) {
        return a % b;
    }

    public static void StoreInMemory(double Number) {
        StreamWriter writer = new StreamWriter("Memory.json");
        writer.Write(JsonConvert.SerializeObject(Number));
        writer.Close();
    }

    public static double RestoreFromMemory() {
        StreamReader reader = new StreamReader("Memory.json");
        string jsonString = reader.ReadToEnd();
        reader.Close();
        return JsonConvert.DeserializeObject<double>(jsonString);
    }
}
