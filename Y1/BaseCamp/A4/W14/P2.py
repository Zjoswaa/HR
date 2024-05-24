import time


def measure_time(func):
    def wrapper(*args, **kwargs):
        start_time = time.time()
        res = func(*args, **kwargs)
        end_time = time.time()
        return f"{res}\n{func.__name__} took: {end_time - start_time} seconds"
    return wrapper


@measure_time
def sort(items: list):
    return sorted(items)


if __name__ == "__main__":
    print(sort([3, 1, 37, 18, 4]))
