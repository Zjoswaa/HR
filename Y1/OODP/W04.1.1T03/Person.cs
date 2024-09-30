public class Person {
    public string Name;
    public List<Car> OwnedCars;

    public Person(string name) {
        Name = name;
        OwnedCars = new List<Car>();
    }

    public void AquireCar(Car car) => OwnedCars.Add(car);
}
