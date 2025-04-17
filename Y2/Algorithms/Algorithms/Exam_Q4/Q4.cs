namespace Solution;

public static class Q4 {
    public static int[][] ConvertMatrixToList(int[,] matrix) {
        int n = matrix.GetLength(0);

        int[][] res = new int[n][];

        for (int i = 0; i < n; i++) {
            int edgeCount = 0;
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] == 1) {
                    edgeCount++;
                }
            }

            int[] row = new int[edgeCount];
            int idx = 0;

            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] == 1 && idx < edgeCount) {
                    row[idx] = j;
                    idx++;
                }
            }

            res[i] = row;
        }

        return res;
    }
}
