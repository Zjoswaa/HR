import math
from datetime import datetime


class ParkedCar:
    def __init__(self, license_plate: str, check_in: datetime):
        self.license_plate: str = license_plate
        self.check_in: datetime = check_in


class CarParkingMachine:
    def __init__(self, id: str, capacity: int = 10, hourly_rate: float = 2.50):
        self.logger = CarParkingLogger(id)
        self.id = id
        self.capacity: int = capacity
        self.hourly_rate: float = hourly_rate
        self.parked_cars: dict[str: ParkedCar] = {}
        self.init_from_log()

    def init_from_log(self):
        try:
            checked_in_cars = {}
            with open("carparklog.txt", "r") as file:
                lines = file.readlines()
                for line in lines:
                    if line != "\n":
                        line = line.removesuffix("\n")
                        action = line.split(" ")[1].split(";")[3].split("=")[1]
                        license_plate = line.split(" ")[1].split(";")[2].split("=")[1]
                        cpm_name = line.split(" ")[1].split(";")[1].split("=")[1]

                        if cpm_name == self.id:
                            if action == "check-in":
                                date = datetime(year=int(line.split(" ")[0].split("-")[2]),
                                                month=int(line.split(" ")[0].split("-")[1]),
                                                day=int(line.split(" ")[0].split("-")[0]),
                                                hour=int(line.split(" ")[1].split(";")[0].split(":")[0]),
                                                minute=int(line.split(" ")[1].split(";")[0].split(":")[1]),
                                                second=int(line.split(" ")[1].split(";")[0].split(":")[2]))
                                checked_in_cars[license_plate] = date
                            else:
                                if license_plate in checked_in_cars:
                                    del checked_in_cars[license_plate]
                for license_plate, check_in in checked_in_cars.items():
                    self.parked_cars[license_plate] = ParkedCar(license_plate, check_in)
            file.close()
        except FileNotFoundError:
            print("Failed to open log file")

    def check_in(self, license_plate: str, check_in: datetime = datetime.now()) -> bool:
        if len(self.parked_cars) == self.capacity or license_plate in self.parked_cars:
            return False
        self.parked_cars[license_plate] = ParkedCar(license_plate, check_in)
        try:
            with open("carparklog.txt", "a") as file:
                date = check_in.date().strftime("%d-%m-%Y")
                time = check_in.time().strftime("%H:%M:%S")
                file.write(f"{date} {time}"
                           f";cpm_name={self.id};license_plate={license_plate};action=check-in")
                file.write("\n")
                file.close()
        except FileNotFoundError:
            print("Failed to open log file")
            return False
        return True

    def check_out(self, license_plate: str) -> float | None:
        if license_plate not in self.parked_cars:
            return None
        fee = self.get_parking_fee(license_plate)
        del self.parked_cars[license_plate]
        try:
            with open("carparklog.txt", "a") as file:
                date = datetime.now().date().strftime("%d-%m-%Y")
                time = datetime.now().time().strftime("%H:%M:%S")
                file.write(f"{date} {time}"
                           f";cpm_name={self.id};license_plate={license_plate};action=check-out;parking_fee={fee}")
                file.write("\n")
            file.close()
        except FileNotFoundError:
            print("Failed to open log file")
        return fee

    def get_parking_fee(self, license_plate: str):
        if license_plate not in self.parked_cars:
            return None
        else:
            return min(math.ceil((datetime.now() - self.parked_cars[license_plate].check_in).total_seconds() / 3600),
                       24) * self.hourly_rate


def main():
    machine = CarParkingMachine("North")
    # machine.check_in("AA-123-A", datetime.now() - timedelta(hours=2))
    # print(list(machine.parked_cars.keys()))
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


class CarParkingLogger:
    def __init__(self, id: str):
        self.id = id

    def get_machine_fee_by_day(self, car_parking_machine_id: str, search_date: str) -> float:
        try:
            with open("carparklog.txt", "r") as file:
                total_fee = 0.0
                lines = file.readlines()
                for line in lines:
                    if line != "\n":
                        line = line.removesuffix("\n")
                        action = line.split(" ")[1].split(";")[3].split("=")[1]
                        cpm_name = line.split(" ")[1].split(";")[1].split("=")[1]
                        if line.startswith(search_date) and cpm_name == car_parking_machine_id \
                                and action == "check-out":
                            total_fee += float(line.split(" ")[1].split(";")[4].split("=")[1])
            file.close()
            return round(total_fee, 2)
        except FileNotFoundError:
            print("No cars have been checked in yet")
            return 0.0

    def get_total_car_fee(self, license_plate: str) -> float:
        try:
            with open("carparklog.txt", "r") as file:
                total_fee = 0.0
                lines = file.readlines()
                for line in lines:
                    if line != "\n":
                        line = line.removesuffix("\n")
                        action = line.split(" ")[1].split(";")[3].split("=")[1]
                        if license_plate == line.split(" ")[1].split(";")[2].split("=")[1] and action == "check-out":
                            total_fee += float(line.split(" ")[1].split(";")[4].split("=")[1])

            file.close()
            return round(total_fee, 2)
        except FileNotFoundError:
            print("No cars have been checked in yet")
            return 0.0


if __name__ == "__main__":
    main()
