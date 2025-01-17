static class SalesHelper {
    public static void PrintSalesData(int[][] salesData) {
        for (int i = 0; i < salesData.Length; i++) {
            Console.WriteLine($"Sales data for department {i + 1}:");
            for (int j = 0; j < salesData[i].Length; j++) {
                Console.WriteLine($" - {salesData[i][j]}");
            }
            if (i != salesData.Length - 1) {
                Console.WriteLine();
            }
        }
    }
}
