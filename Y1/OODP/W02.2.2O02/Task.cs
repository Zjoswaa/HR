class Task {
    public string Name;
    public bool IsDone;

    public Task(string Name) {
        this.Name = Name;
        this.IsDone = false;
    }

    public void Done() {
        this.IsDone = true;
    }

    public string Info() {
        return $"Task: {this.Name}, Status: {(this.IsDone ? "Done" : "Pending")}";
    }
}
