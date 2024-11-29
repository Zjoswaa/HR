from datetime import datetime
import math

# ParkedCar class to store information of parked cars.
class ParkedCar:
    def __init__(self, license_plate: str, check_in: datetime = None):
        self.license_plate: str = license_plate
        self.check_in: datetime = check_in # tijd dat de auto heeft ingechecked

# Day car parking machine. Max parking fee is 24 hours (hourly_rate * 24).
class CarParkingMachine:
    def __init__(self, capacity: int = 10, hourly_rate: float = 2.50):
        self.capacity: int = capacity
        self.hourly_rate: float = hourly_rate
        self.parked_cars = {}
        self.capacity = len(self.parked_cars)

    def check_in(self, license_plate: str, check_in: datetime.now()):
        if len(self.capacity) > 10:
            return False

        else:
            self.capacity[license_plate] = ParkedCar(license_plate, check_in)
            return True

    def get_parking_fee(self, license_plate: str):
        check_in_date = self.parked_cars[license_plate].check_in
        time_difference = datetime.now() - check_in_date
        difference_in_hours = math.ceil(time_difference.total_seconds() / 3600)
        if difference_in_hours > 24:
            difference_in_hours = 24
        parking_fee: float = self.hourly_rate * difference_in_hours
        return parking_fee

    def check_out(self, license_plate: str):
        parking_fee: float = self.get_parking_fee(license_plate)
        del(self.parked_cars[license_plate])
        return parking_fee

def main():
# build menu structure as following
# the input can be case-insensitive (so E and e are valid inputs)
# [I] Check-in car by license plate
# [O] Check-out car by license plate
# [Q] Quit program

if __name__ == "__main__":
    main()




