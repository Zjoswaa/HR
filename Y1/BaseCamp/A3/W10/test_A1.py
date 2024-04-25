from A1 import *
from datetime import datetime, timedelta


def test_check_in_capacity_normal():
    machine = CarParkingMachine("1")
    return machine.check_in("111")


def test_check_in_capacity_reached():
    machine = CarParkingMachine("2", 0)
    return machine.check_in("222")


def test_parking_fee():
    machine = CarParkingMachine("3")
    # Assert that parking time 2h10m, gives correct parking fee
    machine.check_in("333", check_in=datetime.now() - timedelta(hours=2, minutes=10))
    assert machine.get_parking_fee("333") == 3 * 2.50
    # Assert that parking time 24h, gives correct parking fee
    machine.check_in("444", check_in=datetime.now() - timedelta(hours=24))
    assert machine.get_parking_fee("444") == 24 * 2.50
    # Assert that parking time 30h == 24h max, gives correct parking fee
    machine.check_in("555", check_in=datetime.now() - timedelta(hours=30))
    assert machine.get_parking_fee("555") == 24 * 2.50


def test_check_out():
    machine = CarParkingMachine("4")
    machine.check_in("666", datetime.now() - timedelta(minutes=10))
    # Assert that {license_plate} is in parked_cars
    assert "666" in machine.parked_cars
    # Assert that correct parking fee is provided when checking-out {license_plate}
    assert machine.check_out("666") == 2.50
    # Assert that {license_plate} is no longer in parked_cars
    assert "666" not in machine.parked_cars
