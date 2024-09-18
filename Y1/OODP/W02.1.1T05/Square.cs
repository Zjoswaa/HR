class Square {
    public int Side;
    public Square(int side) {
        this.Side = side;
    }

    public int Area() => this.Side * this.Side;
    public int Perimeter() => 4 * this.Side;
}
