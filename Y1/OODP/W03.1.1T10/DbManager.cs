//https://www.infoworld.com/article/3546242/how-to-use-const-readonly-and-static-in-csharp.html#:~:text=Use%20the%20readonly%20keyword%20when,the%20instance%20of%20the%20type.

class DbManager {
    public readonly string Connection = "Database connection";
    public DbManager() => Connection = "Reassign in constructor";
}
