using Newtonsoft.Json;

class Program {
    public static void Main() {
        StreamReader? reader = null;
        StreamWriter? writer = null;

        try {
            reader = new("People.json");
            List<Person> People = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd())!;

            foreach (Person Person in People) {
                foreach (Car Car in Person.OwnedCars) {
                    for (int i = 0; i < 5; i++) {
                        Car.Drive();
                    }
                }
            }

            writer = new("People.json");
            writer.Write(JsonConvert.SerializeObject(People));
            
        } catch (FileNotFoundException e) {
            Console.Write("Missing JSON file. ");
            Console.WriteLine(e.Message);
        } catch (Newtonsoft.Json.JsonReaderException e) {
            Console.Write("Invalid JSON. ");
            Console.WriteLine(e.Message);
        } finally {
            reader?.Close();
            writer?.Close();
        }
    }
}
