class Artist {
    public string Name;
    public int NumberOfSongs;

    public Artist(string name) => Name = name;

    public Song WriteSong(string name) {
        NumberOfSongs++;
        var song = new Song(name);
        song.SetSinger(this);
        return song;
    }
}
