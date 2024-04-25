def nth_root(num, n):
    return num**(1/n)


def calculate_interest(start, end, period):
    return nth_root((end / start), period) - 1


def calculate_end_value(begin, interest, period):
    return begin * (1 + interest)**period


print(calculate_interest(1000, 1305.3, 10) * 100)
