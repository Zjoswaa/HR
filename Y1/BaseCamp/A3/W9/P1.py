class Customer:
    def __init__(self, name: str):
        self.name: str = name

    def print(self):
        print(f"Name: {self.name}")


class Car:
    def __init__(self, brand: str, model: str, color: str, price: str):
        self.brand: str = brand
        self.model: str = model
        self.color: str = color
        self.price: str = price
        self.sold: bool = False
        self.sold_to: Customer = None

    def sell(self, sold_to: Customer):
        self.sold = True
        self.sold_to = sold_to

    def print(self):
        print(f"Brand: {self.brand}")
        print(f"Model: {self.model}")
        print(f"Color: {self.color}")
        print(f"Price: {self.price}")
        print(f"Sold to: {self.sold_to.name}") if self.sold else print("Not sold yet")


class Motorcycle(Car):
    pass


if __name__ == "__main__":
    customer = Customer("John Doe")
    car = Car("BMW", "X5", "Black", "34.889")

    car.print()
    car.sell(customer)
    car.print()
