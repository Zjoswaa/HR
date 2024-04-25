import math
from datetime import datetime
import json


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


class ParkedCar:
    def __init__(self, license_plate: str, check_in: datetime = None):
        self.license_plate: str = license_plate
        if check_in is None:
            self.check_in = datetime.now()
        else:
            self.check_in: datetime = check_in


class CarParkingMachine:
    def __init__(self, id: str, capacity: int = 10, hourly_rate: float = 2.50):
        self.logger = CarParkingLogger(id)
        self.id = id
        self.capacity: int = capacity
        self.hourly_rate: float = hourly_rate
        try:
            self.init_from_file()
        except FileNotFoundError:
            self.parked_cars: dict = {}
        # print(self.parked_cars)

    def init_from_file(self):
        self.parked_cars = read_from_json(self.id + "_state.json")

    def check_in(self, license_plate: str, check_in: datetime = None) -> bool:
        # print(datetime.now().strftime("%d-%m-%Y %H:%M:%S"))
        if (len(self.parked_cars) == self.capacity or license_plate in self.parked_cars
                or self.car_checked_in_already(license_plate)):
            return False
        if check_in is None:
            check_in = datetime.now()
        self.parked_cars[license_plate] = ParkedCar(license_plate, check_in)
        write_to_json(self.parked_cars, self.id + "_state.json")
        try:
            with open("carparklog.txt", "a") as file:
                date = check_in.date().strftime("%d-%m-%Y")
                time = check_in.time().strftime("%H:%M:%S")
                file.write(f"{date} {time}"
                           f";cpm_name={self.id};license_plate={license_plate};"
                           f"action=check-in")
                file.write("\n")
                file.close()
        except FileNotFoundError:
            print("Failed to open log file")
            return False
        return True

    def check_out(self, license_plate: str) -> float | None:
        # print(datetime.now().strftime("%d-%m-%Y %H:%M:%S"))
        if license_plate not in self.parked_cars:
            return None
        fee = self.get_parking_fee(license_plate)
        del self.parked_cars[license_plate]
        write_to_json(self.parked_cars, self.id + "_state.json")
        try:
            with open("carparklog.txt", "a") as file:
                date = datetime.now().date().strftime("%d-%m-%Y")
                time = datetime.now().time().strftime("%H:%M:%S")
                file.write(f"{date} {time}"
                           f";cpm_name={self.id};license_plate={license_plate}"
                           f";action=check-out;parking_fee={fee}")
                file.write("\n")
            file.close()
        except FileNotFoundError:
            print("Failed to open log file")
        return fee

    def get_parking_fee(self, license_plate: str) -> float | None:
        if license_plate not in self.parked_cars:
            return None
        else:
            return min(math.ceil((datetime.now() - self.parked_cars[license_plate].check_in).total_seconds() / 3600),
                       24) * self.hourly_rate

    def car_checked_in_already(self, license_plate_check: str) -> bool:
        check_ins = []
        with open("carparklog.txt", "r") as file:
            for line in file:
                name = line.split(" ")[1].split(";")[1].split("=")[1]
                license_plate = line.split(" ")[1].split(";")[2].split("=")[1]
                action = line.split(" ")[1].split(";")[3].split("=")[1].removesuffix("\n")

                if license_plate_check == license_plate and name != self.id:
                    if action == "check-in":
                        check_ins.append(name)
                    else:
                        check_ins.remove(name)
        return len(check_ins) != 0


def str_to_datetime(date: str) -> datetime:
    year = int(date.split(" ")[0].split("-")[2])
    month = int(date.split(" ")[0].split("-")[1])
    day = int(date.split(" ")[0].split("-")[0])
    hour = int(date.split(" ")[1].split(":")[0])
    minutes = int(date.split(" ")[1].split(":")[1])
    seconds = int(date.split(" ")[1].split(":")[2])
    return datetime(year, month, day, hour, minutes, seconds)


def read_from_json(file_name: str) -> dict:
    parked_cars = {}
    with open(file_name, "r", encoding="utf-8") as file:
        json_data = json.load(file)
        # print(len(json_data))
        for item in json_data:
            # print(item)
            parked_cars[item["license_plate"]] = ParkedCar(item["license_plate"], str_to_datetime(item["check_in"]))
    return parked_cars


def write_to_json(data: dict[str, ParkedCar], file_name: str):
    json_data = []
    for license_plate, car in data.items():
        json_data.append({"license_plate": license_plate, "check_in": car.check_in.strftime("%d-%m-%Y %H:%M:%S")})
    with open(file_name, "w", encoding="utf-8") as file:
        json.dump(json_data, file, ensure_ascii=False, indent=2)


def main():
    machine = CarParkingMachine("North")
    while True:
        user_input = input("[I] Check-in car by license plate\n[O] Check-out car by license plate\n[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "i":
            if machine.check_in(input("License: ")):
                print("License registered")
            else:
                print("Failed to register license, capacity reached or license already parked.")
        elif user_input.lower() == "o":
            license_plate = input("License: ")
            fee = machine.check_out(license_plate)
            if fee is not None:
                print(f"Parking fee: {fee:.2f} EUR")
            else:
                print(f"License {license_plate} not found!")


if __name__ == "__main__":
    main()
