class Container<T> {
    public T Value { get; set; }

    public Container(T Value) {
        this.Value = Value;
    }

    public void ResetValue() {
        this.Value = default;
    }
}
