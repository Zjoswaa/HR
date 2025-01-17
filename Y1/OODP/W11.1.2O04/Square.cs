class Square : Shape, ISelectable, IStackable {
    public bool IsSelected { get; set; } = false;
    public double Size { get; private set; }

    public Square(double Size) {
        this.Size = Math.Max(Size, 0);
    }

    public void Select() {
        IsSelected = true;
    }

    public void Deselect() {
        IsSelected = false;
    }
}
