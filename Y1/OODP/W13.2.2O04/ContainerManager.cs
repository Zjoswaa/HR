using Newtonsoft.Json;

public static class ContainerManager {
    public static void Start(string ManifestPath) {
        foreach (string FileName in Directory.EnumerateFiles(ManifestPath)) {
            foreach (Container Container in ProcessManifest(FileName)) {
                Console.WriteLine(Container);
            }
        }
    }

    public static List<Container>? ProcessManifest(string FileName) {
        using StreamReader reader = new(FileName);
        return JsonConvert.DeserializeObject<List<Container>>(reader.ReadToEnd());

        // foreach (Person Person in People) {
        //     foreach (Car Car in Person.OwnedCars) {
        //         for (int i = 0; i < 5; i++) {
        //             Car.Drive();
        //         }
        //     }
        // }
        //
        // StreamWriter writer = new("People.json");
        // writer.Write(JsonConvert.SerializeObject(People, Formatting.Indented));
        // writer.Close();
    }

    public static List<Container> SearchByOrigin(List<Container> Containers, string Origin) {
        return Containers.FindAll(c => c.Origin == Origin);
    }

    public static Container? SearchForHeaviest(List<Container> Containers) {
        return Containers.MaxBy(c => c.Weight);
    }
}
