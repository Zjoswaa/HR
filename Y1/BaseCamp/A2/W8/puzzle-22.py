# Start at 0, 0
position = {"x": 0, "y": 0}
times_passed_seven = 0

numbers = [
    [0, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9],
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 0]
]

# print(numbers[position["y"]][position["x"]])

steps = [
    "⬆", "⮕", "⬇", "⬅", "⬆", "⮕", "⬇", "⬅", "⬆", "⮕", "⬇", "⬅", "⬆", "⮕", "⬇", "⬅", "⬆", "⮕", "⬇",
    "⬅", "⬆", "⬆", "⮕", "⮕", "⬇", "⬇", "⬅", "⬅", "⬆", "⬆", "⮕", "⮕", "⬇", "⬇", "⬅", "⬅", "⬆", "⬆",
    "⮕", "⮕", "⬇", "⬇", "⬅", "⬅", "⬆", "⬆", "⮕", "⮕", "⬇", "⬇", "⬅", "⬅", "⬆", "⬆", "⬆", "⬆", "⮕",
    "⮕", "⮕", "⮕", "⬇", "⬇", "⬇", "⬇", "⬅", "⬅", "⬅", "⬅", "⬆", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⮕",
    "⬇", "⬇", "⬇", "⬇", "⬅", "⬅", "⬅", "⬅", "⬆", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⮕", "⬇", "⬇", "⬇",
    "⬇", "⬅", "⬅", "⬅", "⬅", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⬇", "⬇",
    "⬇", "⬇", "⬇", "⬇", "⬅", "⬅", "⬅", "⬅", "⬅", "⬅", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⬆", "⬆", "⬆",
    "⮕", "⮕", "⮕", "⬇", "⬇", "⬇", "⬇", "⬇", "⬇", "⬅", "⬅", "⬅", "⬅", "⬅", "⬅", "⬆", "⮕", "⮕", "⮕",
    "⮕", "⮕", "⮕", "⮕", "⮕", "⮕", "⬆", "⬆", "⬆", "⬆", "⬆", "⮕", "⮕", "⮕", "⮕", "⮕", "⮕", "⮕", "⮕"
]

for step in steps:
    if step == "⬅":
        position["x"] = max(0, position["x"] - 1)
    elif step == "⮕":
        position["x"] = min(17, position["x"] + 1)
    elif step == "⬆":
        position["y"] = min(6, position["y"] + 1)
    elif step == "⬇":
        position["y"] = max(0, position["y"] - 1)
    if numbers[position["y"]][position["x"]] == 7:
        times_passed_seven += 1

print(f"Times we passed 7: {times_passed_seven}")
