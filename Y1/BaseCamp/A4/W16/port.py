from datetime import datetime
import sqlite3


class Port:
    def __init__(self, id: str, code: int, name: str, city: str, province: str, country: str) -> None:
        self.id: str = id
        self.code: int = code
        self.name: str = name
        self.city: str = city
        self.province: str = province
        self.country: str = country

    def __repr__(self) -> str:
        return "{}({})".format(type(self).__name__, ", ".join([f"{key}={value!s}" for key, value in self.__dict__
                                                              .items()]))

    def __eq__(self, other):
        return self.id == other.id

    def __hash__(self):
        return hash(('id', self.id))

    def get_shipments(self) -> tuple:
        from shipment import Shipment

        conn = sqlite3.connect("shipments.db")
        shipments = []
        query = '''SELECT * FROM shipments WHERE origin=? OR destination=?'''
        query_results = conn.execute(query, [self.id, self.id]).fetchall()
        for query_result in query_results:
            shipments.append(Shipment(query_result[0], datetime.strptime(query_result[1], "%Y-%m-%d"),
                                      query_result[2], query_result[3], query_result[4], query_result[5],
                                      query_result[6], query_result[7], query_result[8]))
        conn.close()
        return tuple(shipments)
