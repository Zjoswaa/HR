import math
from datetime import datetime
import sqlite3
import os
import sys
import csv


class CarParkingLogger:
    def __init__(self, id: str):
        self.id = id


class ParkedCar:
    def __init__(self, id: int | None, license_plate: str, check_in: datetime, check_out: datetime | None,
                 parking_fee: float):
        self.id: int | None = id
        self.license_plate: str = license_plate
        self.check_in: datetime = check_in
        self.check_out: datetime | None = check_out
        self.parking_fee: float = parking_fee

    def __str__(self):
        return (f"ID: {self.id}\n"
                f"License plate: {self.license_plate}\n"
                f"Check-in: {self.check_in}\n"
                f"Check-out: {self.check_out}\n"
                f"Parking fee: {self.parking_fee}")


class CarParkingMachine:
    def __init__(self, id: str, capacity: int = 10, hourly_rate: float = 2.50):
        self.parked_cars = {}
        self.id: str = id
        self.capacity: int = capacity
        self.hourly_rate: float = hourly_rate
        self.conn = sqlite3.connect(os.path.join(sys.path[0], 'carparkingmachine.db'))
        self.conn.execute(
            '''CREATE TABLE IF NOT EXISTS parkings (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                car_parking_machine TEXT NOT NULL,
                license_plate TEXT NOT NULL,
                check_in TEXT NOT NULL,
                check_out TEXT DEFAULT NULL,
                parking_fee REAL DEFAULT 0
            );'''
        )
        self.init_from_db()

    def report_cars(self):
        cars = []
        user_input = input("ID, From date, To date (DD-MM-YY): ").replace(" ", "").split(",")
        from_date = datetime.strptime(user_input[1], "%d-%m-%Y")
        to_date = datetime.strptime(user_input[2], "%d-%m-%Y")

        query = "SELECT * FROM parkings WHERE car_parking_machine=? AND check_out IS NOT NULL"
        results = self.conn.execute(query, [user_input[0]]).fetchall()
        for result in results:
            if ((from_date < datetime.strptime(result[3], "%m-%d-%Y %H:%M:%S"))
                    and (to_date > datetime.strptime(result[4], "%m-%d-%Y %H:%M:%S"))):
                cars.append({"license_plate": result[2], "check_in": result[3], "check_out": result[4],
                             "parking_fee": f"{result[5]:.2f}"})
        # print(cars)

        from_date_str = from_date.strftime("%d-%m-%Y")
        to_date_str = to_date.strftime("%d-%m-%Y")
        file_name = f"parkedcars_{user_input[0]}_from_{from_date_str}_to_{to_date_str}.csv"
        with open(file_name, "wt", newline="", encoding="utf-8") as file:
            writer = csv.DictWriter(file, ["license_plate", "check_in", "check_out", "parking_fee"])
            writer.writeheader()
            writer.writerows(cars)

    def report_fees(self):
        fees = {}
        user_input = input("From date, To date (DD-MM-YY): ").replace(" ", "").split(",")
        from_date = datetime.strptime(user_input[0], "%d-%m-%Y")
        to_date = datetime.strptime(user_input[1], "%d-%m-%Y")

        query = "SELECT * FROM parkings WHERE car_parking_machine=? AND check_out IS NOT NULL"
        results = self.conn.execute(query, [self.id]).fetchall()
        for result in results:
            if ((from_date < datetime.strptime(result[3], "%m-%d-%Y %H:%M:%S"))
                    and (to_date > datetime.strptime(result[4], "%m-%d-%Y %H:%M:%S"))):
                if result[1] not in fees:
                    fees[result[1]] = result[5]
                else:
                    fees[result[1]] += result[5]
        csv_fees = []
        for fee in fees.items():
            csv_fees.append({"car_parking_machine": fee[0], "total_parking_fee": f"{fee[1]:.2f}"})
        print(csv_fees)

        from_date_str = from_date.strftime("%d-%m-%Y")
        to_date_str = to_date.strftime("%d-%m-%Y")
        file_name = f"total_fees_from_{from_date_str}_to_{to_date_str}.csv"
        with open(file_name, "wt", newline="", encoding="utf-8") as file:
            writer = csv.DictWriter(file, ["car_parking_machine", "total_parking_fee"])
            writer.writeheader()
            writer.writerows(csv_fees)

    def report_license_plate(self):
        parkings = []
        license_plate = input("License plate: ")
        query = "SELECT * FROM parkings WHERE license_plate=? AND check_out IS NOT NULL"

        results = self.conn.execute(query, [license_plate]).fetchall()
        for result in results:
            parkings.append({"car_parking_machine": result[1], "check_in": result[3], "check_out": result[4],
                             "parking_fee": f"{result[5]:.2f}"})

        file_name = f"complete_parkings_{license_plate}.csv"
        with open(file_name, "wt", newline="", encoding="utf-8") as file:
            writer = csv.DictWriter(file, ["car_parking_machine", "check_in", "check_out", "parking_fee"])
            writer.writeheader()
            writer.writerows(parkings)

    def init_from_db(self):
        query = """SELECT * FROM parkings WHERE car_parking_machine=?"""
        for record in self.conn.execute(query, [self.id]):
            self.parked_cars[record[2]] = (
                ParkedCar(record[0],
                          record[2],
                          datetime.strptime(record[3], "%m-%d-%Y %H:%M:%S"),
                          None if record[4] is None else datetime.strptime(record[4], "%m-%d-%Y %H:%M:%S"),
                          float(record[5])))

    def check_in(self, license_plate: str, check_in: datetime = None) -> bool:
        if check_in is None:
            check_in = datetime.now()
        if len(self.parked_cars) == self.capacity:
            # print("Capacity reached")
            return False
        if self.car_checked_in_already(license_plate):
            # print("Car checked in already")
            return False

        car = self.insert(ParkedCar(None, license_plate, check_in, None, 0.0))
        self.parked_cars[license_plate] = car

        return True

    def check_out(self, license_plate: str) -> float | None:
        query = """SELECT id, check_in, check_out FROM parkings WHERE license_plate=?"""
        records = self.conn.execute(query, [license_plate]).fetchall()
        if not len(records):
            # print("This car has not been registered yet")
            return None
        elif records[-1][2] is not None:  # If the last time the car was seen, it checked out
            # print("This car needs to check in first")
            return None
        else:  # The car was seen here, and the last time it was seen, it checked in
            check_in_time = datetime.strptime(records[-1][1], "%m-%d-%Y %H:%M:%S")
            now = datetime.now()
            hours_parked = min(24, math.ceil((now - check_in_time).total_seconds() / 3600.0))
            fee = hours_parked * self.hourly_rate
            car_id = records[-1][0]

            query = "UPDATE parkings SET parking_fee=?, check_out=? WHERE id=?"
            self.conn.execute(query, [fee, now.strftime("%m-%d-%Y %H:%M:%S"), car_id])
            self.conn.commit()
            return fee

    def get_parking_fee(self, license_plate: str) -> float | None:
        pass

    def car_checked_in_already(self, license_plate_check: str) -> bool:
        query = """SELECT check_out FROM parkings WHERE car_parking_machine=? AND license_plate=?"""
        result = self.conn.execute(query, [self.id, license_plate_check]).fetchall()
        if not len(result):  # If car has not yet been seen in this parking machine before
            return False
        elif result[-1][0] is None:  # If last time this car was seen, it has not yet checked out
            return True
        return False

    def find_by_id(self, id: int) -> ParkedCar | None:
        query = """SELECT id, license_plate, check_in, check_out, parking_fee FROM parkings
                    WHERE car_parking_machine=? AND id=? LIMIT 1"""

        records = self.conn.execute(query, [self.id, id]).fetchall()
        if len(records):
            record = records[0]
            # Check out can be null in the database
            if record[3] is None:
                check_out_time = None
            else:
                check_out_time = datetime.strptime(record[3], "%m-%d-%Y %H:%M:%S")

            return ParkedCar(record[0],
                             record[1],
                             datetime.strptime(record[2], "%m-%d-%Y %H:%M:%S"),
                             check_out_time,
                             float(record[4]))
        return None

    def find_last_checkin(self, license_plate: str) -> int | None:
        query = """SELECT id FROM parkings
                    WHERE car_parking_machine=? AND license_plate=? AND check_out IS NULL"""
        records = self.conn.execute(query, [self.id, license_plate]).fetchall()
        if len(records):  # If any record is found
            return records[-1][0]
        return None

    def insert(self, parked_car: ParkedCar) -> ParkedCar:
        query = """INSERT INTO parkings (car_parking_machine, license_plate, check_in, check_out, parking_fee)
                    VALUES(?, ?, ?, ?, ?)"""
        result = self.conn.execute(query, [
            self.id,
            parked_car.license_plate,
            datetime.strftime(parked_car.check_in, "%m-%d-%Y %H:%M:%S"),
            None if parked_car.check_out is None else datetime.strftime(parked_car.check_out, "%m-%d-%Y %H:%M:%S"),
            parked_car.parking_fee]
        )
        parked_car.id = result.lastrowid
        self.conn.commit()
        return parked_car

    def update(self, parked_car: ParkedCar) -> None:
        query = """UPDATE parkings SET car_parking_machine=?, license_plate=?, check_in=?, check_out=?, parking_fee=?
                    WHERE id=?"""
        self.conn.execute(query, [
            self.id,
            parked_car.license_plate,
            datetime.strftime(parked_car.check_in, "%m-%d-%Y %H:%M:%S"),
            None if parked_car.check_out is None else datetime.strftime(parked_car.check_out, "%m-%d-%Y %H:%M:%S"),
            parked_car.parking_fee,
            parked_car.id]
        )
        self.conn.commit()


def main():
    machine = CarParkingMachine("North")
    # print(machine.find_last_checkin("AA-123-AA"))
    # print(machine.find_last_checkin("BB-456-BB"))
    # print(machine.find_last_checkin("AA-123-BB"))

    # print(machine.find_by_id(3))

    # car = ParkedCar(None, "DD-111-DD", datetime.now(), None, 0.0)
    # machine.insert(car)

    # car = ParkedCar(4, "DD-222-DD", datetime.now(), None, 0.0)
    # machine.update(car)

    # for car in machine.cars:
    #     print(car)
    #     print()

    # print(machine.car_checked_in_already("AA-123-AA"))
    # print(machine.car_checked_in_already("DD-222-DD"))
    # print(machine.car_checked_in_already("A"))

    while True:
        user_input = input("[I] Check-in car by license plate\n[O] Check-out car by license plate\n[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "i":
            if machine.check_in(input("License: ")):
                print("License registered")
        elif user_input.lower() == "o":
            license_plate = input("License: ")
            fee = machine.check_out(license_plate)
            if fee is not None:
                print(f"Parking fee: {fee:.2f} EUR")


if __name__ == "__main__":
    main()
