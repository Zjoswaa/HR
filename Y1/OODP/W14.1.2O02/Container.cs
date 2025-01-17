public class Container {
    public string Code { get; }
    public string Manifest { get; }
    public string[] Categories { get; }
    public string Origin { get; }
    public double Weight { get; }
    public int Status { get; set; }

    public Container(string Code, string Manifest, string[] Categories, string Origin, string Weight, int Status = 0) {
        this.Code = Code;
        this.Manifest = Manifest;
        this.Categories = Categories;
        this.Origin = Origin;
        this.Weight = Math.Round(Double.Parse(Weight.Split(" ")[0]) * 0.45359237, 2, MidpointRounding.AwayFromZero);
        this.Status = Status;
    }

    public override string ToString() {
        return $"Container(Code:'{this.Code}', Manifest:'{this.Manifest}', Categories:'{String.Join(',', Categories)}', Origin:'{this.Origin}', Status:'{this.Status}', Weight:'{this.Weight}')";
    }
}
