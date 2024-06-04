def factorial(n: int) -> int:
    answer = n
    while n > 1:
        n -= 1
        answer *= n
    return answer


def rec_factorial(n: int) -> int:
    if n <= 1:
        return 1
    else:
        return n * rec_factorial(n - 1)
