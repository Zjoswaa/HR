using Newtonsoft.Json;

public static class HistoricalEventSearch {
    public static List<HistoricalEvent> ReadEvents(string dataset) {
        StreamReader reader = new StreamReader(dataset);
        string jsonString = reader.ReadToEnd();
        reader.Close();
        return JsonConvert.DeserializeObject<List<HistoricalEvent>>(jsonString)!;
    }

    public static List<HistoricalEvent> SearchInDescription(List<HistoricalEvent> events, string search) {
        return events.Where(e => e.Description.ToLower().Contains(search.ToLower())).ToList();
    }

    public static List<HistoricalEvent> SearchBetweenYears(List<HistoricalEvent> events, int fromYear, int toYear) {
        return events.Where(e => e.Year >= fromYear && e.Year <= toYear).ToList();
    }

    public static double AverageEventYear(List<HistoricalEvent> events) {
        return Math.Floor(events.Average(e => e.Year));
    }
}
