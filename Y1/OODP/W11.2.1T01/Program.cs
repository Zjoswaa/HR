public class Program {
    public static void Main() {
        int[][] salesData = new int[][] {
            new int[] { 1000, 1500, 1700, 2000 },
            new int[] { 1200, 1700, 1600, 1700, 2000 },
            new int[] { 1300, 2000, 1500 },
        };
        SalesHelper.PrintSalesData(salesData);
    }
}
