interface ISelectable {
    void Select();
    void Deselect();
    bool IsSelected { get; }
}
