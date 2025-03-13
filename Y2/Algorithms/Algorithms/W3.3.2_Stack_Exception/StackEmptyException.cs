public class StackEmptyException : Exception {
    public StackEmptyException() { }

    public StackEmptyException(string message)
        : base(message) { }
}
