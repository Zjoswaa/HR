public class File : IStorable {
    public string FileName { get; set; }

    public File(string fileName) => FileName = fileName;

    public void Save() {
        //Implementation of IStorable.Save
    }

    public void Load() {
        //Implementation of IStorable.Load
    }
}
