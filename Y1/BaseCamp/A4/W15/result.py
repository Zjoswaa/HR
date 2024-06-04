class Result:
    def __init__(self, student_id: int, course_id: int, mark: int, achieved: str):
        self.student_id: int = student_id
        self.course_id: int = course_id
        self.mark: int = mark
        self.achieved: str = achieved

    # Representation method
    # This will format the output in the correct order
    # Format is @dataclass-style: Classname(attr=value, attr2=value2, ...)
    def __repr__(self) -> str:
        return "{}({})".format(type(self).__name__, ", ".join([f"{key}={value!r}" for key, value in self.__dict__.items()]))
