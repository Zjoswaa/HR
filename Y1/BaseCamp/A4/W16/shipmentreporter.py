import csv
from datetime import date, datetime
import sqlite3

from vessel import Vessel
from port import Port
from shipment import Shipment


class Reporter:
    def __init__(self):
        self.conn = sqlite3.connect("shipments.db")

    def __del__(self):
        self.conn.close()

    def total_amount_of_vessels(self) -> int:
        query_results = self.conn.execute('''SELECT imo FROM vessels''').fetchall()
        return len(query_results)

    def longest_shipment(self) -> Shipment | None:
        try:
            query_result = self.conn.execute('''SELECT * FROM shipments ORDER BY distance_naut DESC''').fetchall()[0]
        except IndexError:
            return None
        return Shipment(query_result[0], datetime.strptime(query_result[1], "%Y-%m-%d"), query_result[2],
                        query_result[3], query_result[4], query_result[5], query_result[6], query_result[7],
                        query_result[8])

    def longest_and_shortest_vessels(self) -> tuple[Vessel, Vessel] | None:
        query_results = self.conn.execute('''SELECT * FROM vessels ORDER BY length, imo DESC''').fetchall()
        try:
            longest_result = query_results[-1]
            shortest_result = query_results[0]
        except IndexError:
            return None
        return (Vessel(longest_result[0], longest_result[1], longest_result[2], longest_result[3], longest_result[4],
                       longest_result[5], longest_result[6], longest_result[7], longest_result[8], longest_result[9]),
                Vessel(shortest_result[0], shortest_result[1], shortest_result[2], shortest_result[3],
                       shortest_result[4], shortest_result[5], shortest_result[6], shortest_result[7],
                       shortest_result[8], shortest_result[9]))

    def widest_and_smallest_vessels(self) -> tuple[Vessel, Vessel] | None:
        query_results = self.conn.execute('''SELECT * FROM vessels ORDER BY beam''').fetchall()
        try:
            widest_result = query_results[-1]
            thinnest_result = query_results[0]
        except IndexError:
            return None
        return (Vessel(widest_result[0], widest_result[1], widest_result[2], widest_result[3], widest_result[4],
                       widest_result[5], widest_result[6], widest_result[7], widest_result[8], widest_result[9]),
                Vessel(thinnest_result[0], thinnest_result[1], thinnest_result[2], thinnest_result[3],
                       thinnest_result[4], thinnest_result[5], thinnest_result[6], thinnest_result[7],
                       thinnest_result[8], thinnest_result[9]))

    # Which vessels have the most shipments -> tuple[Vessel, ...]
    def vessels_with_the_most_shipments(self) -> tuple[Vessel, ...] | None:
        vessels = {}
        most_shipments = []
        # Get all the shipments and count how many times each vessel ID occurs, stored in a dictionary
        for vessel_imo in self.conn.execute('''SELECT vessel FROM shipments''').fetchall():
            if vessel_imo[0] not in vessels:
                vessels[vessel_imo[0]] = 1
            else:
                vessels[vessel_imo[0]] += 1
        # Get the highest value in this dictionary
        try:
            highest_shipment_count = tuple(dict(sorted(vessels.items(), key=lambda item: item[1])).values())[-1]
        except IndexError:
            return None
        # Get every vessel that also has this count and add it to the list
        for vessel_imo, count in vessels.items():
            if count == highest_shipment_count:
                query_result = self.conn.execute('''SELECT * FROM vessels WHERE imo=? LIMIT 1''',
                                                 [vessel_imo]).fetchone()
                most_shipments.append(Vessel(query_result[0], query_result[1], query_result[2], query_result[3],
                                             query_result[4], query_result[5], query_result[6], query_result[7],
                                             query_result[8], query_result[9]))
        return tuple(most_shipments)

    # Which ports have the most shipments -> tuple[Port, ...]
    def ports_with_most_shipments(self) -> tuple[Port, ...] | None:
        ports = {}
        most_shipments = []
        # Get all the shipments and count how many times each port ID occurs (origin and destination)
        for port_ids in self.conn.execute('''SELECT origin, destination FROM shipments''').fetchall():
            if port_ids[0] not in ports:
                ports[port_ids[0]] = 1
            else:
                ports[port_ids[0]] += 1
            if port_ids[1] not in ports:
                ports[port_ids[1]] = 1
            else:
                ports[port_ids[1]] += 1
        # Get the highest value in this dictionary
        try:
            highest_shipment_count = tuple(dict(sorted(ports.items(), key=lambda item: item[1])).values())[-1]
        except IndexError:
            return None
        # Get every port that also has this count and add it to the list
        for port_id, count in ports.items():
            if count == highest_shipment_count:
                query_result = self.conn.execute('''SELECT * FROM ports WHERE id=? LIMIT 1''',
                                                 [port_id]).fetchone()
                most_shipments.append(Port(query_result[0], query_result[1], query_result[2], query_result[3],
                                           query_result[4], query_result[5]))
        return tuple(most_shipments)

    # Which ports (origin) had the first shipment? -> tuple[Port, ...]:
    # Which ports (origin) had the first shipment of a specific vessel type?  -> tuple[Port, ...]:
    def ports_with_first_shipment(self, vessel_type: str = None) -> tuple[Port, ...] | None:
        def get_ports(date) -> tuple[Port, ...] | None:
            ports = []
            if vessel_type is None:
                port_ids = []
                query_results = (self.conn.execute('''SELECT origin FROM shipments WHERE date=? ORDER BY origin''',
                                                   [date]).fetchall())
                for query_result in query_results:
                    port_ids.append(query_result[0])
                for port_id in port_ids:
                    query_result = self.conn.execute('''SELECT * FROM ports WHERE id=? LIMIT 1''',
                                                     [port_id]).fetchone()
                    ports.append(Port(query_result[0], query_result[1], query_result[2], query_result[3],
                                      query_result[4], query_result[5]))
                return tuple(ports)
            else:
                port_ids = []
                query_results = (self.conn.execute('''SELECT origin, vessel FROM shipments WHERE date=?
                ORDER BY origin''', [date]).fetchall())
                for query_result in query_results:
                    db_vessel_type = self.conn.execute('''SELECT type FROM vessels WHERE imo=? LIMIT 1''',
                                                       [query_result[1]]).fetchone()
                    if db_vessel_type[0] == vessel_type:
                        port_ids.append(query_result[0])
                for port_id in port_ids:
                    query_result = self.conn.execute('''SELECT * FROM ports WHERE id=? LIMIT 1''',
                                                     [port_id]).fetchone()
                    ports.append(Port(query_result[0], query_result[1], query_result[2], query_result[3],
                                      query_result[4], query_result[5]))
                return tuple(ports)

        try:
            if vessel_type is None:
                first_date = self.conn.execute('''SELECT date FROM shipments ORDER BY date''').fetchall()[0][0]
                return get_ports(first_date)
            else:
                dates = set()
                for query_result in self.conn.execute('''SELECT date FROM shipments ORDER BY date''').fetchall():
                    dates.add(query_result[0])
                for _date in sorted(dates):
                    vessel_imos = self.conn.execute('''SELECT vessel FROM shipments WHERE date=?''',
                                                    [_date]).fetchall()
                    for vessel_imo in vessel_imos:
                        db_vessel_type = (self.conn.execute('''SELECT type FROM vessels WHERE imo=? LIMIT 1''',
                                                            [vessel_imo[0]]).fetchone())
                        if db_vessel_type[0] == vessel_type:
                            return get_ports(_date)
        except IndexError:
            return None

    # Which ports (origin) had the latest shipment? -> tuple[Port, ...]:
    # Which ports (origin) had the latetst shipment of a specific vessel type? -> tuple[Port, ...]:
    def ports_with_latest_shipment(self, vessel_type: str = None) -> tuple[Port, ...] | None:
        def get_ports(date) -> tuple[Port, ...] | None:
            ports = []
            if vessel_type is None:
                port_ids = []
                query_results = (self.conn.execute('''SELECT origin FROM shipments WHERE date=? ORDER BY origin''',
                                                   [date]).fetchall())
                for query_result in query_results:
                    port_ids.append(query_result[0])
                for port_id in port_ids:
                    query_result = self.conn.execute('''SELECT * FROM ports WHERE id=? LIMIT 1''',
                                                     [port_id]).fetchone()
                    ports.append(Port(query_result[0], query_result[1], query_result[2], query_result[3],
                                      query_result[4], query_result[5]))
                return tuple(ports)
            else:
                port_ids = []
                query_results = self.conn.execute('''SELECT origin, vessel FROM shipments WHERE date=? ORDER BY origin''',
                                                  [date]).fetchall()
                for query_result in query_results:
                    db_vessel_type = self.conn.execute('''SELECT type FROM vessels WHERE imo=? LIMIT 1''',
                                                       [query_result[1]]).fetchone()
                    if db_vessel_type[0] == vessel_type:
                        port_ids.append(query_result[0])
                for port_id in port_ids:
                    query_result = self.conn.execute('''SELECT * FROM ports WHERE id=? LIMIT 1''',
                                                     [port_id]).fetchone()
                    ports.append(Port(query_result[0], query_result[1], query_result[2], query_result[3],
                                      query_result[4], query_result[5]))
                return tuple(ports)

        try:
            if vessel_type is None:
                last_date = self.conn.execute('''SELECT date FROM shipments ORDER BY date DESC''').fetchall()[0][0]
                return get_ports(last_date)
            else:
                dates = set()
                for query_result in self.conn.execute('''SELECT date FROM shipments ORDER BY date''').fetchall():
                    dates.add(query_result[0])
                for _date in sorted(dates, reverse=True):
                    vessel_imos = self.conn.execute('''SELECT vessel FROM shipments WHERE date=?''',
                                                    [_date]).fetchall()
                    for vessel_imo in vessel_imos:
                        db_query_type = (self.conn.execute('''SELECT type FROM vessels WHERE imo=? LIMIT 1''',
                                                           [vessel_imo[0]]).fetchone())
                        if db_query_type[0] == vessel_type:
                            return get_ports(_date)
        except IndexError:
            return None

    # Which vessels have docked port Z between period X and Y? -> tuple[Vessel, ...]
    # Based on given parameter `to_csv = True` should generate CSV file as  `Vessels docking Port Z between X and Y.csv`
    # example: `Vessels docking Port MZPOL between 2023-03-01 and 2023-06-01.csv`
    # date input always in format: YYYY-MM-DD
    # otherwise it should just return the value as tuple(Vessels, ...)
    # CSV example (this are also the headers):
    #   imo, mmsi, name, country, type, build, gross, netto, length, beam
    def vessels_that_docked_port_between(self, port: Port, start: date, end: date,
                                         to_csv: bool = False) -> tuple[Vessel, ...] | None:
        vessels = []
        query_results = (self.conn.execute('''SELECT vessel FROM shipments
        WHERE (origin=? OR destination=?) AND date<=? AND date>=? ORDER BY vessel''',
                                           [port.id, port.id, end.strftime("%Y-%m-%d"), start.strftime("%Y-%m-%d")])
                         .fetchall())
        for query_result in query_results:
            vessel_result = (self.conn.execute('''SELECT * FROM vessels WHERE imo=? LIMIT 1''', [query_result[0]])
                             .fetchone())
            vessels.append(Vessel(vessel_result[0], vessel_result[1], vessel_result[2], vessel_result[3],
                                  vessel_result[4], vessel_result[5], vessel_result[6], vessel_result[7],
                                  vessel_result[8], vessel_result[9]))
        if not to_csv:
            # This removes duplicates but preserves order
            return tuple(dict.fromkeys(vessels))
        else:
            to_write = [["imo", "mmsi", "name", "country", "type", "build", "gross", "netto", "length", "beam"]]
            # This removes duplicates but preserves order
            for vessel in tuple(dict.fromkeys(vessels)):
                to_write.append([vessel.imo, vessel.mmsi, vessel.name, vessel.country, vessel.type, vessel.build,
                                 vessel.gross, vessel.netto, vessel.length, vessel.beam])

            start_time = start.strftime("%Y-%m-%d")
            end_time = end.strftime("%Y-%m-%d")
            filename = f"Vessels docking Port {port.id} between {start_time} and {end_time}.csv"
            with open(filename, "wt", newline="", encoding="utf-8") as file:
                writer = csv.writer(file, delimiter=",")
                writer.writerows(to_write)
            return None

    # Which ports are located in country X? ->tuple[Port, ...]
    # Based on given parameter `to_csv = True` should generate CSV file as  `Ports in country X.csv`
    # example: `Ports in country Norway.csv`
    # otherwise it should just return the value as tuple(Port, ...)
    # CSV example (this are also the headers):
    #   id, code, name, city, province, country
    def ports_in_country(self, country: str, to_csv: bool = False) -> tuple[Port, ...] | None:
        ports = []
        query_results = self.conn.execute('''SELECT * FROM ports WHERE country=? ORDER BY id''',
                                          [country]).fetchall()
        for query_result in query_results:
            ports.append(Port(query_result[0], query_result[1], query_result[2], query_result[3], query_result[4],
                              query_result[5]))

        if not to_csv:
            # This removes duplicates but preserves order
            return tuple(dict.fromkeys(ports))
        else:
            to_write = [["id", "code", "name", "city", "province", "country"]]
            # This removes duplicates but preserves order
            for port in tuple(dict.fromkeys(ports)):
                to_write.append([port.id, port.code, port.name, port.city, port.province, port.country])

            filename = f"Ports in country {country}.csv"
            with open(filename, "wt", newline="", encoding="utf-8") as file:
                writer = csv.writer(file, delimiter=",")
                writer.writerows(to_write)
            return None

    # Which vessels are from country X? -> tuple[Vessel, ...]
    # Based on given parameter `to_csv = True` should generate CSV file as  `Vessels from country X.csv`
    # example: `Vessels from country GER.csv`
    # otherwise it should just return the value as tuple(Vessel, ...)
    # CSV example (this are also the headers):
    #   imo, mmsi, name, country, type, build, gross, netto, length, beam
    def vessels_from_country(self, country: str, to_csv: bool = False) -> tuple[Vessel, ...] | None:
        vessels = []
        query_results = self.conn.execute('''SELECT * FROM vessels WHERE country=?''', [country]).fetchall()
        for query_result in query_results:
            vessels.append(Vessel(query_result[0], query_result[1], query_result[2], query_result[3], query_result[4],
                                  query_result[5], query_result[6], query_result[7], query_result[8], query_result[9]))

        if not to_csv:
            return tuple(vessels)
        else:
            to_write = [["imo", "mmsi", "name", "country", "type", "build", "gross", "netto", "length", "beam"]]
            for vessel in vessels:
                to_write.append([vessel.imo, vessel.mmsi, vessel.name, vessel.country, vessel.type, vessel.build,
                                 vessel.gross, vessel.netto, vessel.length, vessel.beam])

            filename = f"Vessels from country {country}.csv"
            with open(filename, "wt", newline="", encoding="utf-8") as file:
                writer = csv.writer(file, delimiter=",")
                writer.writerows(to_write)
            return None
