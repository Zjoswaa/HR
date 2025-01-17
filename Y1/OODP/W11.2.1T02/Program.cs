public class Program {
    public static void Main() {
        int[][] salesData = new int[][] {
            new int[] { 1000, 1100 },
            new int[] { 1200, 1300, 1400 },
            new int[] { 1500, 1600 },
        };
        SalesHelper.PrintSalesData(salesData);
    }
}
