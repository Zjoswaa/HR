import math
from datetime import datetime


class ParkedCar:
    def __init__(self, license_plate: str, check_in: datetime):
        self.license_plate: str = license_plate
        self.check_in: datetime = check_in


class CarParkingMachine:
    def __init__(self, capacity: int = 10, hourly_rate: float = 2.50):
        self.capacity: int = capacity
        self.hourly_rate: float = hourly_rate
        self.parked_cars: dict = {}

    def check_in(self, license_plate: str, check_in: datetime = datetime.now()) -> bool:
        if len(self.parked_cars) == self.capacity or license_plate in self.parked_cars:
            return False
        self.parked_cars[license_plate] = ParkedCar(license_plate, check_in)
        return True

    def check_out(self, license_plate: str) -> float | None:
        if license_plate in self.parked_cars:
            fee = self.get_parking_fee(license_plate)
            del self.parked_cars[license_plate]
            return fee
        else:
            return None

    def get_parking_fee(self, license_plate: str) -> float | None:
        if license_plate not in self.parked_cars:
            return None
        else:
            return min(math.ceil((datetime.now() - self.parked_cars[license_plate].check_in).total_seconds() / 3600),
                       24) * self.hourly_rate


def main():
    machine = CarParkingMachine()
    while True:
        user_input = input("[I] Check-in car by license plate\n[O] Check-out car by license plate\n[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "i":
            if machine.check_in(input("License: ")):
                print("License registered")
            else:
                print("Capacity reached!")
        elif user_input.lower() == "o":
            license_plate = input("License: ")
            fee = machine.check_out(license_plate)
            if fee is not None:
                print(f"Parking fee: {fee:.2f} EUR")
            else:
                print(f"License {license_plate} not found!")


if __name__ == "__main__":
    main()
