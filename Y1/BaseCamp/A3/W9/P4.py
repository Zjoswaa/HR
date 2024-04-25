conversions = {"inches": 0.0254, "feet": 0.3048, "yards": 0.9144, "miles": 1609.344, "kilometers": 1000, "meters": 1,
               "centimeters": 0.01, "millimeters": 0.001}


class Converter:
    def __init__(self, amount: int, unit: str):
        if unit in conversions:
            self.amount_meter: float = amount * conversions[unit]
        else:
            self.amount_meter: float = 0.0

    def inches(self):
        return self.amount_meter / conversions["inches"]

    def feet(self):
        return self.amount_meter / conversions["feet"]

    def yards(self):
        return self.amount_meter / conversions["yards"]

    def miles(self):
        return self.amount_meter / conversions["miles"]

    def kilometers(self):
        return self.amount_meter / conversions["kilometers"]

    def meters(self):
        return self.amount_meter / conversions["meters"]

    def centimeters(self):
        return self.amount_meter / conversions["centimeters"]

    def millimeters(self):
        return self.amount_meter / conversions["millimeters"]
