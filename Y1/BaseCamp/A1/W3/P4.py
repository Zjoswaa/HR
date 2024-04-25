print("°C  °F")
for i in range(10, 101, 10):
    print(f"{i}".ljust(4), end="")
    print(f"{int((float(i) * (9/5)) + 32)}")
