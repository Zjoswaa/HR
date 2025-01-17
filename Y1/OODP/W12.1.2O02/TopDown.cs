static class TopDown {
    public static void Display<T>(Item<T> item) => Display(item, "");

    public static void Display<T>(Item<T> item, string format) {
        if (item == null) {
            Console.WriteLine("None");
            return;
        }

        Console.WriteLine($"{format} {item.Value}");
        if (item.SubItems == null)
            return;

        item.SubItems.ForEach(sub => Display(sub, format + "---"));
    }

    public static Item<T> Find<T>(Item<T> item, T key) {
        if (item.Value.Equals(key)) {
            return item;
        }

        // Recursively search in the subitems.
        if (item.SubItems is not null) {
            foreach (var subItem in item.SubItems) {
                var found = Find(subItem, key);
                if (found is not null) {
                    return found;
                }
            }
        }
        
        // If no matching item was found, return null.
        return null;
    }
}
