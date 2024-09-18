class Todo {
    public List<Task> TaskList;

    public Todo() {
        this.TaskList = new();
    }

    public void AddTask(string TaskName) {
        this.TaskList.Add(new Task(TaskName));
    }

    public Task GetTask(string TaskName) {
        foreach (Task task in this.TaskList) {
            if (task.Name == TaskName) {
                return task;
            }
        }
        return null;
    }

    public string Report() {
        string InfoString = "";
        foreach (Task task in this.TaskList) {
            InfoString += task.Info() + "\n";
        }
        return InfoString;
    }
}
