using Newtonsoft.Json;

public static class ContainerManager {
    public static Queue<Container> selectedForInspection = new();
    public static Stack<Container> underReview = new();
    
    
    public static void Start(string ManifestPath) {
        foreach (string FileName in Directory.EnumerateFiles(ManifestPath)) {
            // foreach (Container Container in ProcessManifest(FileName)) {
            //     Console.WriteLine(Container);
            // }
            MarkForInspection(ProcessManifest(FileName), c => c.Origin == "COL" && c.Categories.Contains("Fruits"));
        }
        InspectContainers();
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

    public static void MarkForInspection(List<Container> Containers, Func<Container, bool> filter) {
        foreach (Container Container in Containers) {
            if (filter(Container)) {
                Container.Status = ContainerStatus.MarkedForInspection;
                selectedForInspection.Enqueue(Container);
            } else {
                Container.Status = ContainerStatus.Approved;
            }
            ContainerLogger.Log(Container);
        }
        Console.WriteLine($"Number of containers selected for inspection: {Containers.Count(c => c.Status == ContainerStatus.MarkedForInspection)}");
    }

    public static void MarkForInspection(List<Container> Containers) {
        foreach (Container Container in Containers) {
            Container.Status = ContainerStatus.Approved;
            ContainerLogger.Log(Container);
        }
        Console.WriteLine($"Number of containers selected for inspection: {Containers.Count(c => c.Status == ContainerStatus.MarkedForInspection)}");
    }

    public static void InspectContainers() {
        while (selectedForInspection.Any()) {
            Container selected = selectedForInspection.Dequeue();
            if (selected.ActualWeight > selected.Weight * 1.1) {
                selected.Status = ContainerStatus.UnderReview;
                underReview.Push(selected);
            }
            else {
                selected.Status = ContainerStatus.ApprovedAfterInspection;
            }
            ContainerLogger.Log(selected);
        }
    }
}
