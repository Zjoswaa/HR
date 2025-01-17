static class TowerBuilder {
    public static void Build<TShape> (Tower<TShape> Tower, TShape Shape) where TShape : ISelectable, IStackable {
        Shape.Select();
        Tower.Add(Shape);
    }
}
