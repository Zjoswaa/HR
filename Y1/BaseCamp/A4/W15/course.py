class Course:
    def __init__(self, name: str, points: int, id: int = None):
        self.id: int = id
        self.name: str = name
        self.points: int = points

    # Representation method
    # This will format the output in the correct order
    # Format is @dataclass-style: Classname(attr=value, attr2=value2, ...)
    def __repr__(self) -> str:
        return "{}({})".format(type(self).__name__, ", ".join([f"{key}={value!r}" for key, value in self.__dict__.items()]))
