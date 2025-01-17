public class GrayscaleImage {
    public int Height { get; }
    public int Width { get; }
    public int[,] PixelData { get; }

    public GrayscaleImage(int height, int width) {
        PixelData = new int[height, width];
    }

    public GrayscaleImage(int[,] pixelData) {
        PixelData = pixelData;
        Height = PixelData.GetLength(0);
        Width = PixelData.GetLength(1);
    }

    public void AdjustBrightness(double factor) {
        for (int i = 0; i < Height; i++) {
            for (int j = 0; j < Width; j++) {
                PixelData[i, j] = Convert.ToInt32(Math.Floor(Convert.ToDouble(PixelData[i, j]) * factor));
            }
        }
    }
}
