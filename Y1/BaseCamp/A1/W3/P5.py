nums = list(range(1, 11))
print("  ", end="")
for i in nums:
    print(f"{i:4}", end="")
print("\n")

for i in nums:
    print(f"{i:2}", end="")
    for j in range(1, 11):
        print(f"{(i * j):4}", end="")
    print("\n")
