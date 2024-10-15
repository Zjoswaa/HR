class Magazine : Publication {
    private string Issue { get; set; }
    public override string PublishedOn {
        get {
            if (!this.IsPublished) {
                return "not published yet";
            }
            return $"Issue: {Issue}; published on {this._publicationDate.ToString("yyyy-MM-dd")}";
        }
    }

    public Magazine(string Title, string Publisher, int Pages, List<string> Audience, string Issue) : base(Title, Publisher, "Magazine", Pages, Audience) {
        this.Issue = Issue;
    }
}
