class Song {
    public string Title;
    public Artist Singer;

    public Song(string Title) {
        this.Title = Title;
        this.Singer = new Artist("Unknown");
    }

    public void SetSinger(Artist Singer) {
        this.Singer = Singer;
    }

    public string Info() {
        return $"{this.Title} is by {this.Singer.Name}";
    }
}
