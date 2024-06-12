from vessel import Vessel
from shipment import Shipment
from datetime import datetime


# Test to check if duration is converted correctly based on the given arguments
# 1) %D:%H:%M
# 2) %H:%M
def test_convert_duration():
    shipment = Shipment(id="C8046337-CDC8-4A61-AD2E-8A12CA687C3C", date=datetime(2024, 1, 1),
                        cargo_weight=1704, distance_naut=4120.326, duration_hours=251.239, average_speed=16.4,
                        origin="CNJMN", destination="INJDH", vessel=1034034)

    assert shipment.convert_duration("%D:%H:%M") == "10:11:14"
    assert shipment.convert_duration("%H:%M") == "251:14"


# Test to check if distance is converted correctly based on the given arguments
# 1) NM = Nautical Meters
# 2) M = Meters
# 3) KM = Kilometers
# 4) MI = Miles
# 5) YD = Yards
# 6) ValueError check
def test_convert_distance():
    shipment = Shipment(id="C8046337-CDC8-4A61-AD2E-8A12CA687C3C", date=datetime(2024, 1, 1),
                        cargo_weight=1704, distance_naut=4120.326, duration_hours=251.239, average_speed=16.4,
                        origin="CNJMN", destination="INJDH", vessel=1034034)

    assert shipment.convert_distance("NM") == 4120.326
    assert shipment.convert_distance("M") == 7630843.752
    assert shipment.convert_distance("KM") == 7630.843752
    assert shipment.convert_distance("MI") == 4742.495226
    assert shipment.convert_distance("YD") == 8343664.880134
    try:
        shipment.convert_distance("FT")
        assert False
    except ValueError:
        assert True


# Test to check if speed is converted correctly based on the given arguments
# 1) Knts = Knots
# 2) Mph = Miles per hour
# 3) Kph = Kilometers per hour
# 4) ValueError check
def test_convert_speed():
    shipment = Shipment(id="C8046337-CDC8-4A61-AD2E-8A12CA687C3C", date=datetime(2024, 1, 1),
                        cargo_weight=1704, distance_naut=4120.326, duration_hours=251.239, average_speed=16.4,
                        origin="CNJMN", destination="INJDH", vessel=1034034)

    assert shipment.convert_speed("Knts") == 16.4
    assert shipment.convert_speed("Mph") == 18.872783
    assert shipment.convert_speed("Kmph") == 30.372784
    try:
        shipment.convert_speed("Mps")
        assert False
    except ValueError:
        assert True


# Test to check if the fuel consumption is calculated correctly based on the distance
def test_get_fuel_consupmtion():
    vessel = Vessel(imo=9936393, mmsi=None, name="ONE FUTURE", country="Hong Kong", type="Container Ship", build=2024,
                    gross=155811, netto=155000, length=366, beam=51)

    assert vessel.get_fuel_consumption(50.0) == 15.07848
    assert vessel.get_fuel_consumption(75.0) == 22.61773


# Test to check if the fuel costs are calculated correctly based on the price per liter
def test_calculate_fuel_costs():
    vessel = Vessel(imo=9936393, mmsi=None, name="ONE FUTURE", country="Hong Kong", type="Container Ship", build=2024,
                    gross=155811, netto=155000, length=366, beam=51)
    shipment = Shipment(id="C8046337-CDC8-4A61-AD2E-8A12CA687C3C", date=datetime(2024, 1, 1),
                        cargo_weight=1704, distance_naut=4120.326, duration_hours=251.239, average_speed=16.4,
                        origin="CNJMN", destination="INJDH", vessel=1034034)

    assert shipment.calculate_fuel_costs(5.0, vessel) == 1560904.418


# Test to check if the returned ports are correct
# 1) amount check
# 2) keys check
# 3) values check
def test_get_ports():
    shipment = Shipment(id="C8046337-CDC8-4A61-AD2E-8A12CA687C3C", date=datetime(2024, 1, 1),
                        cargo_weight=1704, distance_naut=4120.326, duration_hours=251.239, average_speed=16.4,
                        origin="CNJMN", destination="INJDH", vessel=1034034)

    assert len(shipment.get_ports()) == 2
    assert "origin" in shipment.get_ports()
    assert "destination" in shipment.get_ports()
    assert shipment.get_ports()["origin"].id == "CNJMN"
    assert shipment.get_ports()["origin"].code == 57000
    assert shipment.get_ports()["destination"].id == "INJDH"
    assert shipment.get_ports()["destination"].name == "Jodhpur"


# Test if the returned shipments contain the required shipment(s)
def test_get_shipments():
    vessel = Vessel(imo=9936393, mmsi=None, name="ONE FUTURE", country="Hong Kong", type="Container Ship", build=2024,
                    gross=155811, netto=155000, length=366, beam=51)

    assert len(vessel.get_shipments()) > 0


# test_convert_duration()
# test_convert_distance()
# test_convert_speed()
# test_get_fuel_consupmtion()
# test_calculate_fuel_costs()
# test_get_ports()
# test_get_shipments()
