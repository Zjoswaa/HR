class Tower<TShape> where TShape: IStackable {
    public TShape[] Shapes;
    public int Index { get; private set; } = 0;

    public Tower(int Size) {
        Shapes = new TShape[Size];
    }

    public Tower(Tower<TShape> Tower) {
        Shapes = Tower.Shapes;
        Index = Tower.Index;
    }

    public void Add(TShape Shape) {
        if (Index >= Shapes.Length) {
            return;
        }
        Shapes[Index++] = Shape;
    }

    public static Tower<TShape> operator +(Tower<TShape> Tower, TShape Shape) {
        Tower<TShape> ToReturn = new(Tower);
        ToReturn.Add(Shape);
        return ToReturn;
    }
}
