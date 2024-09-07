class Program {
    static void printList(List<string> list) {
        Console.WriteLine($"Amount of tasks: {list.Count}");
        for (int i = 0; i < list.Count; i++) {
            Console.WriteLine(list[i]);
        }
    }

    static void Main() {
        List<string> list = new();
        printList(list);
        list.Add("Mow lawn");
        list.Add("Pay taxes");
        printList(list);
        list.Remove("Mow lawn");
        list.Add("Shopping");
        printList(list);
    }
}
