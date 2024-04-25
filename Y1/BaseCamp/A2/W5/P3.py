def check_triangle(side_a, side_b, side_c) -> bool:
    return not (side_a >= side_b + side_c or side_b >= side_a + side_c or side_c >= side_a + side_b)


if __name__ == "__main__":
    print("Side A: ", end="")
    try:
        side_a = int(input().replace(" ", ""))
    except ValueError:
        print("Invalid input")
        side_a = 0
    print("Side B: ", end="")
    try:
        side_b = int(input().replace(" ", ""))
    except ValueError:
        print("Invalid input")
        side_b = 0
    print("Side C: ", end="")
    try:
        side_c = int(input().replace(" ", ""))
    except ValueError:
        print("Invalid input")
        side_c = 0
    print("Possible triangle") if check_triangle(side_a, side_b, side_c) else print("Impossible triangle")
