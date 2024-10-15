class Vehicle {
    public string Make { get; set; }
    public string Model { get; set; }
    public IEngine Engine { get; set; }

    public Vehicle (string Make, string Model, IEngine Engine) {
        this.Make = Make;
        this.Model = Model;
        this.Engine = Engine;
    }
}
