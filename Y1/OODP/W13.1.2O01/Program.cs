public static class Program {
    public static void Main() {
        List<HistoricalEvent> hEvents = HistoricalEventSearch.ReadEvents("dataset.json");

        // average year
        Console.WriteLine($"Average event year: {HistoricalEventSearch.AverageEventYear(hEvents)}");

        // search for "Marcus Aurelius"
        Console.WriteLine(
            $"Number of search results for 'Marcus Aurelius': {HistoricalEventSearch.SearchInDescription(hEvents, "Marcus Aurelius").Count}");

        // search between years
        Console.WriteLine(
            $"Number of search results for year range '-10' to '100': {HistoricalEventSearch.SearchBetweenYears(hEvents, -10, 100).Count}");
    }
}
