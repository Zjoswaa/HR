class Product:
    def __init__(self, name: str, amount: int, price: float):
        self.name: str = name
        self.amount: int = amount
        self.price: float = price

    def get_price(self, amount: int):
        if amount < 0:
            return 0
        elif amount < 10:
            return amount * self.price
        elif amount in range(10, 100):
            return (amount * self.price) * 0.9
        else:
            return (amount * self.price) * 0.8

    def make_purchase(self, amount: int):
        if amount > self.amount:
            self.amount = 0
        else:
            self.amount -= amount
