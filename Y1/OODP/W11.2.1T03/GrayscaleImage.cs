public class GrayscaleImage {
    public int Height { get; }
    public int Width { get; }
    public int[,] PixelData { get; }

    public GrayscaleImage(int height, int width) {
        PixelData = new int[height, width];
    }

    public GrayscaleImage(int[,] pixelData) {
        PixelData = pixelData;
    }
}
