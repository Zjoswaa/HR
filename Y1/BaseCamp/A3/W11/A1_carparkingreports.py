import csv
from datetime import datetime


def read_from_csv(file_name: str) -> list:
    with open(file_name, "rt", newline="", encoding="utf-8") as file:
        reader = csv.reader(file)
        return list(reader)


def write_to_csv(data: list, file_name: str):
    with open(file_name, "wt", newline="", encoding="utf-8") as file:
        writer = csv.writer(file, delimiter=";")
        writer.writerows(data)


def report_cars():
    user_input = input("ID, Start Date, End Date: ")
    try:
        cpm_id = user_input.split(",")[0].strip()
        first = datetime(int(user_input.split(",")[1].split("-")[2].strip()),
                         int(user_input.split(",")[1].split("-")[1].strip()),
                         int(user_input.split(",")[1].split("-")[0].strip()))
        second = datetime(int(user_input.split(",")[2].split("-")[2].strip()),
                          int(user_input.split(",")[2].split("-")[1].strip()),
                          int(user_input.split(",")[2].split("-")[0].strip()))
    except IndexError:
        print("Invalid input")
        return
    # print(f"{first} {second}")
    cars = {}
    with open("carparklog.txt", "r") as file:
        for line in file:
            day = line.removesuffix("\n").split(";")[0].split(" ")[0]
            time = line.removesuffix("\n").split(";")[0].split(" ")[1]
            date = datetime(int(day.split("-")[2]), int(day.split("-")[1]), int(day.split("-")[0]),
                            int(time.split(":")[0]), int(time.split(":")[1]), int(time.split(":")[2]))
            name = line.split(" ")[1].split(";")[1].split("=")[1]
            license_plate = line.split(" ")[1].split(";")[2].split("=")[1]
            action = line.split(" ")[1].split(";")[3].split("=")[1].removesuffix("\n")
            if action == "check-out":
                fee = float(line.split(" ")[1].split(";")[4].split("=")[1].removesuffix("\n"))

            if cpm_id == name and first <= date <= second:
                if license_plate not in cars:
                    cars[license_plate] = {"check-in": "None", "check-out": "None", "parking_fee": 0.0}
                if action == "check-in":
                    cars[license_plate]["check-in"] = day + " " + time
                else:
                    cars[license_plate]["check-out"] = day + " " + time
                    cars[license_plate]["parking_fee"] = fee
    # print(cars)
    csv_list = [["license_plate", "checked_in", "checked_out", "parking_fee"]]
    for license_plate, info in cars.items():
        csv_list.append([license_plate, info["check-in"], info["check-out"], info["parking_fee"]])
    first_str = first.strftime("%d-%m-%Y")
    second_str = second.strftime("%d-%m-%Y")
    write_to_csv(csv_list, f"parkedcars_{cpm_id}_from_{first_str}_to_{second_str}.csv")


def report_fees():
    user_input = input("Start Date, End Date: ")
    try:
        first = datetime(int(user_input.split(",")[0].split("-")[2].strip()),
                         int(user_input.split(",")[0].split("-")[1].strip()),
                         int(user_input.split(",")[0].split("-")[0].strip()))
        second = datetime(int(user_input.split(",")[1].split("-")[2].strip()),
                          int(user_input.split(",")[1].split("-")[1].strip()),
                          int(user_input.split(",")[1].split("-")[0].strip()))
    except IndexError:
        print("Invalid input")
        return
    fees = {}
    with open("carparklog.txt", "r") as file:
        for line in file:
            name = line.split(" ")[1].split(";")[1].split("=")[1]
            action = line.split(" ")[1].split(";")[3].split("=")[1].removesuffix("\n")
            if action == "check-out":
                fee = float(line.split(" ")[1].split(";")[4].split("=")[1].removesuffix("\n"))
            if name not in fees:
                fees[name] = 0.0
            if action == "check-out":
                fees[name] += fee
    # print(fees)
    csv_list = [["car_parking_machine", "total_parking_fee"]]
    for machine, total_fee in fees.items():
        csv_list.append([machine, total_fee])
    first_str = first.strftime("%d-%m-%Y")
    second_str = second.strftime("%d-%m-%Y")
    write_to_csv(csv_list, f"totalfee_from_{first_str}_to_{second_str}.csv")


if __name__ == "__main__":
    while True:
        user_input = input("[P] Report all parked cars during a parking period for a specific parking machine\n"
                           "[F] Report total collected parking fee during a parking period for all parking machines\n"
                           "[Q] Quit program\n")
        match user_input.lower():
            case "q":
                break
            case "p":
                try:
                    report_cars()
                except FileNotFoundError:
                    print("Could not find log file")
            case "f":
                try:
                    report_fees()
                except FileNotFoundError:
                    print("Could not find log file")
