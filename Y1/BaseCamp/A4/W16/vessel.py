from datetime import datetime
import sqlite3


class Vessel:
    def __init__(self, imo: int, mmsi: int | None, name: str, country: str, type: str, build: int, gross: int, netto: int,
                 length: int, beam: int) -> None:
        self.imo: int = imo
        self.mmsi: int | None = mmsi
        self.name: str = name
        self.country: str = country
        self.type: str = type
        self.build: int = build
        self.gross: int = gross
        self.netto: int = netto
        self.length: int = length
        self.beam: int = beam

    def __repr__(self) -> str:
        return "{}({})".format(type(self).__name__, ", ".join([f"{key}={value!s}" for key, value in self.__dict__
                                                              .items()]))

    def __eq__(self, other):
        return self.imo == other.imo

    def __hash__(self):
        return hash(('imo', self.imo))

    def get_shipments(self) -> tuple:
        from shipment import Shipment

        conn = sqlite3.connect("shipments.db")
        shipments = []
        query = '''SELECT * FROM shipments WHERE vessel=?'''
        query_results = conn.execute(query, [self.imo]).fetchall()
        for query_result in query_results:
            shipments.append(Shipment(query_result[0], datetime.strptime(query_result[1], "%Y-%m-%d"),
                                      query_result[2], query_result[3], query_result[4], query_result[5],
                                      query_result[6], query_result[7], query_result[8]))
        conn.close()
        return tuple(shipments)

    def get_fuel_consumption(self, distance: float) -> float:
        efficiency = {"Aggregates Carrier": 0.4, "Bulk Carrier": 0.35, "Oil Carrier": 0.35, "Cement Carrier": 0.4,
                      "Container Ship": 0.3, "Deck Cargo Ship": 0.4, "General Cargo Ship": 0.4,
                      "Heavy Load Carrier": 0.4, "Landing Craft": 0.4, "Nuclear Fuel Carrier": 0.35,
                      "Palletised Cargo Ship": 0.4, "Passenger Ship": 0.3, "Ro-Ro Cargo Ship": 0.4,
                      "Self Discharging Bulk Carrier": 0.35, "Vehicles Carrier": 0.35, "Wood Chips Carrier": 0.35}
        return round(efficiency[self.type] * (self.gross / self.netto) * distance, 5)
