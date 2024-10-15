interface ITransform {
    bool IsTransformed { get; }
    void Transform();
    void Revert();
}
