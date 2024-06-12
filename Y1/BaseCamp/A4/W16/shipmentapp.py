import json
import sqlite3
from datetime import date, datetime

from port import Port
from vessel import Vessel
from shipment import Shipment
from shipmentreporter import Reporter


def read_from_json(file_name: str) -> list:
    with open(file_name, "r", encoding="utf-8") as file:
        return json.load(file)


class ShipmentApp:
    def __init__(self, json_filename: str, db_filename: str):
        self.conn = sqlite3.connect(db_filename)
        self.init_vessels_table(json_filename)
        self.init_ports_table(json_filename)
        self.init_shipments_table(json_filename)

    def __del__(self):  # Destructor
        self.conn.close()

    def init_vessels_table(self, filename: str):
        vessel_ids = set()  # Set of ID's of vessels that are added to the DB table, this prevents duplicates
        query = '''INSERT OR IGNORE INTO vessels
                (imo, mmsi, name, country, type, build, gross, netto, length, beam)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)'''
        for item in read_from_json(filename):
            imo: int = item["vessel"]["imo"]
            if imo not in vessel_ids:
                vessel_ids.add(imo)
                length: int = int(item["vessel"]["size"].split("/")[0].replace(" ", ""))
                beam: int = int(item["vessel"]["size"].split("/")[1].replace(" ", ""))

                self.conn.execute(query, [imo,
                                          item["vessel"]["mmsi"], item["vessel"]["name"], item["vessel"]["country"],
                                          item["vessel"]["type"], item["vessel"]["build"], item["vessel"]["gross"],
                                          item["vessel"]["netto"], length, beam])
        self.conn.commit()

    def init_ports_table(self, filename: str):
        port_ids = set()  # Set of ID's of ports that are added to the DB table, this prevents duplicates
        query = '''INSERT OR IGNORE INTO ports
                (id, code, name, city, province, country)
                VALUES (?, ?, ?, ?, ?, ?)'''
        for item in read_from_json(filename):
            # Origin ports
            port_id: int = item["origin"]["id"]
            if port_id not in port_ids:
                port_ids.add(port_id)
                self.conn.execute(query, [port_id, item["origin"]["code"], item["origin"]["name"],
                                          item["origin"]["city"], item["origin"]["province"], item["origin"]["country"]])

            # Destination ports
            port_id: int = item["destination"]["id"]
            if port_id not in port_ids:
                port_ids.add(port_id)
                self.conn.execute(query, [port_id, item["destination"]["code"], item["destination"]["name"],
                                          item["destination"]["city"], item["destination"]["province"],
                                          item["destination"]["country"]])
        self.conn.commit()

    def init_shipments_table(self, filename: str):
        query = '''INSERT OR IGNORE INTO shipments
                (id, date, cargo_weight, distance_naut, duration_hours, average_speed, origin, destination, vessel)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)'''
        for item in read_from_json(filename):
            old_date = item["date"]
            date_split = old_date.split("-")
            new_date = date_split[2] + "-" + date_split[1] + "-" + date_split[0]
            self.conn.execute(query, [item["tracking_number"], new_date, item["cargo_weight"],
                                      item["distance_naut"], item["duration_hours"], item["average_speed"],
                                      item["origin"]["id"], item["destination"]["id"], item["vessel"]["imo"]])

        self.conn.commit()


if __name__ == "__main__":
    app = ShipmentApp("shipments.json", "shipments.db")
    reporter = Reporter()
    port = Port("MYTPP", 55750, "Tanjung Pelepas", "Tanjung Pelepas", "Johor",
                "Malaysia")
    print(port.get_shipments())
    print(reporter.total_amount_of_vessels())
    print(reporter.longest_shipment())
    print(reporter.longest_and_shortest_vessels())
    print(reporter.widest_and_smallest_vessels())
    print(reporter.vessels_with_the_most_shipments())
    print(reporter.ports_with_most_shipments())
    print(reporter.ports_with_first_shipment("Bulk Carrier"))
    print(reporter.ports_with_latest_shipment("Bulk Carrier"))
    print(reporter.vessels_that_docked_port_between(port, date(2023, 2, 4), date(2024, 4, 3), False))
    print(reporter.ports_in_country("Norway", True))
    print(reporter.vessels_from_country("Denmark", True))
    vessel = Vessel(1034034, None, "GREAT WALL 17", "Tanzania", "Deck Cargo Ship", 2023, 1978, 2373, 84, 19)
    print(vessel.get_shipments())
    print(vessel.get_fuel_consumption(50.0))
    shipment = Shipment("C8046337-CDC8-4A61-AD2E-8A12CA687C3C", datetime.strptime("01-01-2024", "%d-%m-%Y"), 1704,
                        4120.326, 200.239, 16.4, "CNJMN", "INJDH", 1034034)
    print(shipment.get_ports())
    print(shipment.get_vessel())
    print(shipment.calculate_fuel_costs(2.0, vessel))
    print(shipment.convert_speed("Kmph"))
    print(shipment.convert_distance("YD"))
    print(shipment.convert_duration("%D:%H:%M"))
