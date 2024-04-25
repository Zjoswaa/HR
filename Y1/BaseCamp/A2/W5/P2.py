base_fare = 4.0
fare = 0.25


def calculate_fare(distance):
    if int(distance * 1000 / 140) < distance * 1000 / 140:
        return ((int(distance * 1000 / 140) + 1) * fare) + base_fare
    else:
        return ((int(distance * 1000 / 140)) * fare) + base_fare


if __name__ == "__main__":
    print("Distance traveled: ", end="")
    print(f"Total fare: {calculate_fare(float(input()))} EUR")
