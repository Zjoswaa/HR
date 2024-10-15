public class Program {
    public static void Main() {
        Pedestrian john = new("John Doe");
        Car honda = new();
        for (int i = 0; i < 3; i++) {
            foreach (var commuter in new List<ICommute>() { john, honda }) {
                commuter.Move(5);
            }
        }
    }
}
