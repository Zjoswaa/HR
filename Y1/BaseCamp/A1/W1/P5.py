nums = input()
sum = 0
for i in range(0, len(nums)):
    if i == 0:
        print(f"{nums[i]}", end="")
    else:
        print(f"+{nums[i]}", end="")
    sum += int(nums[i])
print(f"={sum}")
