from A1 import CarParkingMachine

if __name__ == "__main__":
    machine = CarParkingMachine("North")
    while True:
        user_input = input("[P] Report all parked cars during a parking period for a specific parking machine\n"
                           "[F] Report total collected parking fee during a parking period for all parking machines\n"
                           "[C] Report all complete parkings over all parking machines for a specific car\n"
                           "[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "p":
            machine.report_cars()
        elif user_input.lower() == "f":
            machine.report_fees()
        elif user_input.lower() == "c":
            machine.report_license_plate()
