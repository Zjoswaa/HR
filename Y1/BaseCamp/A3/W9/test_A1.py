from A1 import *
from datetime import datetime, timedelta


# Test for a normal check-in with correct result (True)
def test_check_in_capacity_normal():
    machine = CarParkingMachine()
    assert (machine.check_in("AA-123-B"))


# Test for a check-in with maximum capacity reached (False)
def test_check_in_capacity_reached():
    machine = CarParkingMachine(capacity=0)
    assert (not machine.check_in("AA-123-B"))


# Test for checking the correct parking fees
def test_parking_fee():
    # Assert that parking time 2h10m, gives correct parking fee
    # Assert that parking time 24h, gives correct parking fee
    # Assert that parking time 30h == 24h max, gives correct parking fee

    machine = CarParkingMachine()
    machine.check_in("A", datetime.now() - timedelta(hours=2, minutes=10))
    machine.check_in("B", datetime.now() - timedelta(hours=24))
    machine.check_in("C", datetime.now() - timedelta(hours=32))

    assert (machine.check_out("A") == 7.5)
    assert (machine.check_out("B") == 60)
    assert (machine.check_out("C") == 60)


# Test for validating check-out behaviour
def test_check_out():
    # Assert that {license_plate} is in parked_cars
    # Assert that correct parking fee is provided when checking-out {license_plate}
    # Aseert that {license_plate} is no longer in parked_cars

    machine = CarParkingMachine()
    license_plate = "AA-123-B"
    machine.check_in(license_plate, datetime.now() - timedelta(hours=2, minutes=10))
    assert (license_plate in machine.parked_cars)
    assert (machine.check_out(license_plate) == 7.5)
    assert (license_plate not in machine.parked_cars)


test_check_in_capacity_normal()
test_check_in_capacity_reached()
test_parking_fee()
test_check_out()
