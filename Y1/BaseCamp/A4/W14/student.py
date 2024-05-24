class Student:
    def __init__(self, first_name: str, last_name: str, date_of_birth: str, class_code: str, id: int = None):
        self.id: int = id
        self.first_name: str = first_name
        self.last_name: str = last_name
        self.date_of_birth: str = date_of_birth
        self.class_code: str = class_code

    # Representation method
    # This will format the output in the correct order
    # Format is @dataclass-style: Classname(attr=value, attr2=value2, ...)
    def __repr__(self) -> str:
        return "{}({})".format(type(self).__name__, ", ".join([f"{key}={value!r}" for key, value in self.__dict__.items()]))
