def double_factorial(x: int):
    result = 1
    while x > 0:
        result *= x
        x -= 2
    return result


print(double_factorial(12))

target = 309507830817335656049298470680700967937489104438845343615082865631241726318359375

for x in range(120):
    for y in range(120):
        if double_factorial(x) + double_factorial(y) == target:
            print(x + y)
