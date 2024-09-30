using Newtonsoft.Json;

class Program {
    public static void Main() {
        StreamReader reader = new("People.json");
        List<Person> People = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd())!;
        reader.Close();

        foreach (Person Person in People) {
            foreach (Car Car in Person.OwnedCars) {
                for (int i = 0; i < 5; i++) {
                    Car.Drive();
                }
                Console.WriteLine($"{Car.Brand} : {Car.Mileage}");
            }
        }

        StreamWriter writer = new("People.json");
        writer.Write(JsonConvert.SerializeObject(People, Formatting.Indented));
        writer.Close();
    }
}
