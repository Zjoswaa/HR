class DigitalProduct : Product {
    public string DownloadUrl { get; set; }

    public DigitalProduct(string Name, int Price, int Quantity, string DownloadUrl) : base(Name, Price, Quantity) {
        this.DownloadUrl = DownloadUrl;
    }
}
