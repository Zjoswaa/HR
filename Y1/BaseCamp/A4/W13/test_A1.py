from A1 import CarParkingMachine

machine = CarParkingMachine("South")
assert not len(machine.parked_cars)

machine.check_in("AA-123-AA")
assert len(machine.parked_cars) == 1
assert machine.car_checked_in_already("AA-123-AA")
assert not machine.car_checked_in_already("BB-123-BB")

assert machine.check_out("CC-111-CC") is None
assert machine.check_out("AA-123-AA") != 0.0
