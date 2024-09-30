using Newtonsoft.Json;

class Program {
    public static void Main() {
        try {
            StreamReader reader = new("People.json");
            List<Person> People = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd())!;
            reader.Close();

            foreach (Person Person in People) {
                foreach (Car Car in Person.OwnedCars) {
                    for (int i = 0; i < 5; i++) {
                        Car.Drive();
                    }
                }
            }

            StreamWriter writer = new("People.json");
            writer.Write(JsonConvert.SerializeObject(People));
            writer.Close();
        } catch (FileNotFoundException e) {
            Console.Write("Missing JSON file. ");
            Console.WriteLine(e.Message);
        } catch (Newtonsoft.Json.JsonReaderException e) {
            Console.Write("Invalid JSON. ");
            Console.WriteLine(e.Message);
        }
    }
}
