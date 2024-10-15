class Popup {
    public string Message;
    public Popup(string message) => Message = message;

    public void Show() => Display();
    public virtual void Display() => Console.WriteLine(Message);
}
