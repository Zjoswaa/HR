class MyBoolList : MyGenericList<bool> {
    public MyBoolList(List<bool> elems) : base(elems) { }

    public override bool Combine() {
        foreach (bool Elem in Elems) {
            if (!Elem) {
                return false;
            }
        }
        return true;
    }
}
