class Circle : Shape, ISelectable {
    public bool IsSelected { get; set; } = false;
    public double Radius { get; private set; }

    public Circle(double Radius) {
        this.Radius = Math.Max(Radius, 0);
    }

    public void Select() {
        IsSelected = true;
    }

    public void Deselect() {
        IsSelected = false;
    }
}
