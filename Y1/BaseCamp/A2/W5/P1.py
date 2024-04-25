import random

min_num = 1
max_num = 100
exercise_count = 10
correct = 0


def arithmetic_operation(arithmetic_type):
    first_number = random.randint(min_num, max_num)
    second_number = random.randint(min_num, max_num)

    if arithmetic_type == "summation":
        print(f"{first_number} + {second_number} = ", end="")
        return int(input()) == first_number + second_number
    elif arithmetic_type == "multiplication":
        print(f"{first_number} * {second_number} = ", end="")
        return int(input()) == first_number * second_number
    else:
        print(f"{first_number} - {second_number} = ", end="")
        return int(input()) == first_number - second_number


if __name__ == "__main__":
    exercise_type = input("Arithmetic operation: ")
    for exercise in range(exercise_count):
        if arithmetic_operation(exercise_type):
            correct += 1

    print(f"You had {correct} correct and {exercise_count - correct} incorrect answers in \"{exercise_type}\"")
