class Program {
    static void Main() {
        Car car1 = new Car { Make = "Toyota", Model = "Camry", Year = 2021 };
        Car car2 = new Car { Make = "Honda", Model = "Civic", Year = 2021 };
        Car car3 = new Car { Make = "Toyota", Model = "Camry", Year = 2021 };

        // Using the overloaded == and != operators
        Console.WriteLine("Using overloaded operators:");
        Console.WriteLine($"car1 == car2: {car1 == car2}"); // false
        Console.WriteLine($"car1 != car2: {car1 != car2}"); // true
        Console.WriteLine($"car1 == car3: {car1 == car3}"); // true
        Console.WriteLine($"car1 != car3: {car1 != car3}"); // false

        // Using the Equals method
        Console.WriteLine("\nUsing the Equals method:");
        Console.WriteLine($"car1.Equals(car2): {car1.Equals(car2)}"); // false
        Console.WriteLine($"car1.Equals(car3): {car1.Equals(car3)}"); // true
    }
}
