interface IStorable {
    string FileName { get; set; }

    void Load();
    void Save();
}
