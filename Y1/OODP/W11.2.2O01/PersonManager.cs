static class PersonManager {
    public static void SortAndDisplayPersonsByAge(Person[,] Persons) {
        Person[] ToSort = Persons.Cast<Person>().ToArray();
        Array.Sort(ToSort);
        for (int i = 0; i < ToSort.Length; i++) {
            Console.WriteLine(ToSort[i]);
        }
    }
}
