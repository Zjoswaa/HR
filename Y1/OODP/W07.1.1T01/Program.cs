public class Program {
    public static void Main() {
        ListWrapper<int> listInt = new();
        listInt.Add(1);
        listInt.Add(2);
        listInt.Add(3);

        for (int i = 0; i < listInt.Count; i++)
            Console.WriteLine(listInt.Get(i));

        ListWrapper<string> listString = new();
        listString.Add("Hello");
        listString.Add("World!");

        for (int i = 0; i < listString.Count; i++)
            Console.WriteLine(listString.Get(i));
    }
}
