class Publication {
    public string Title { get; }
    public string Publisher { get; }
    public string PublicationType { get; }
    private int _pages;
    public int Pages {
        get { return _pages; }
        set {
            _pages = Math.Max(1, value);
        }
    }
    protected List<string> Audience { get; }
    protected DateTime _publicationDate;
    public DateTime PublicationDate { // Write-only ??? is so dumb
        set {
            IsPublished = true;
            _publicationDate = value;
        }
    }
    protected bool IsPublished { get; set; }
    public virtual string PublishedOn {
        get {
            if (!this.IsPublished) {
                return "not published yet";
            }
            return this._publicationDate.ToString("yyyy-MM-dd");
        }
    }

    public Publication(string Title, string Publisher, string PublicationType, int Pages, List<string> Audience) {
        this.Title = Title;
        this.Publisher = Publisher;
        this.PublicationType = PublicationType;
        this.Pages = Pages;
        this.Audience = Audience;
    }

    public bool IsSuitableForAudience(string Audience) {
        return this.Audience.Contains(Audience);
    }

    public override string ToString() {
        return $"{Title}, {Pages} pages, {PublishedOn}";
    }
}
