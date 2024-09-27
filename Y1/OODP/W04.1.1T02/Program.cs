using Newtonsoft.Json;

class Program {
    public static void Main() {
        StreamReader reader = new("Cars.json");
        List<Car> Cars = JsonConvert.DeserializeObject<List<Car>>(reader.ReadToEnd())!;
        reader.Close();

        foreach (Car Car in Cars) {
            Console.Write($"{Car.Brand} : {Car.Mileage} -> ");
            for (int i = 0; i < 5; i++) {
                Car.Drive();
            }
            Console.WriteLine(Car.Mileage);
        }

        StreamWriter writer = new("Cars.json");
        writer.Write(JsonConvert.SerializeObject(Cars, Formatting.Indented));
        writer.Close();
    }
}
