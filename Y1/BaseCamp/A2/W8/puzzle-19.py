import sympy, math

prime_list = [x for x in range(1000) if sympy.isprime(x)]

total = math.inf

for A in prime_list:
    for B in prime_list:
        for C in prime_list:
            if A*B+C == 777925:
                if A+B+C < total:
                    total = A+B+C
                    A1, B2, C3 = A, B, C

print(f"A: {A1} B: {B2} C: {C3}")
print(f"Total: {total}")
