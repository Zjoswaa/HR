# Left bottom is 0 0
king_position = {"x": 0, "y": 0}
zoom_count = 0
board_size = 8

steps = [
    "3O", "4N", "1N", "3N", "5O", "1N", "4W", "1O", "1W", "1N",
    "2N", "5W", "1O", "1O", "3W", "2N", "5Z", "5O", "1O", "3N",
    "5N", "5N", "5O", "4W", "3W", "5W", "3Z", "2O", "2N", "5Z",
    "5W", "3W", "3N", "1W", "2Z", "2W", "4N", "1Z", "3Z", "5W",
    "5W", "1N", "3W", "1N", "3W", "3W", "3N", "4Z", "2N", "4N",
    "2Z", "2O", "4W", "4N", "2W", "4Z", "2W", "5Z", "4Z", "4O",
    "2N", "2O", "2O", "1W", "5O", "3Z", "1O", "4Z", "5Z", "2N",
    "4W", "4W", "4N", "4W", "1O", "1O", "4O", "1Z", "5N", "1N",
    "5O", "5N", "3N", "1O", "5W", "2Z", "3Z", "4N", "1W", "4W",
    "4Z", "1O", "1Z", "3W", "2N", "2Z", "2N", "5Z", "1Z", "5Z",
    "2Z", "2Z", "2O", "2W", "2O", "5W", "3N", "1Z", "4Z", "2Z",
    "4Z", "3N", "2N", "2W", "2Z", "2W", "5N", "4Z", "1N", "4O",
    "4O", "4Z", "1W", "4W", "1O", "2O", "1O", "5W", "2W", "3O",
    "5O", "1N", "1O", "4O", "2N", "3O", "3O", "5Z", "3W", "2N",
    "3W", "5W", "5O", "5O", "5N", "4O", "5N", "2O", "2W", "5N",
    "5N", "3W", "1N", "2O", "3N", "1W", "5N", "1W", "3O", "3W",
    "5W", "5O", "5Z", "5O", "4O", "4N", "4W", "3N", "2W", "1O",
    "3N", "2Z", "2Z", "2W", "2N", "4W", "2O", "2W", "5W", "3W",
    "2Z", "3N", "3N", "3W", "4N", "4Z", "5Z", "5N", "1O", "1N",
    "3Z", "1O", "3O", "4Z", "4O", "5W", "3N", "3N", "2W", "1Z"
]
# steps = ["3O", "4N", "1N", "3N", "5O", "1N", "4W", "1O", "1W", "1N"]


def take_step(step: str):
    global zoom_count
    if step[1] == "N":
        if king_position["y"] + int(step[0]) > (board_size - 1):
            king_position["y"] = board_size - 1
            # print("Zoom")
            zoom_count += 1
            return
        else:
            king_position["y"] += int(step[0])
            return
    elif step[1] == "O":
        if king_position["x"] + int(step[0]) > (board_size - 1):
            king_position["x"] = board_size - 1
            # print("Zoom")
            zoom_count += 1
            return
        else:
            king_position["x"] += int(step[0])
            return
    elif step[1] == "Z":
        if king_position["y"] - int(step[0]) < 0:
            king_position["y"] = 0
            # print("Zoom")
            zoom_count += 1
            return
        else:
            king_position["y"] -= int(step[0])
            return
    elif step[1] == "W":
        if king_position["x"] - int(step[0]) < 0:
            king_position["x"] = 0
            # print("Zoom")
            zoom_count += 1
            return
        else:
            king_position["x"] -= int(step[0])
            return


for step in steps:
    take_step(step)
    # print(king_position)

print(f"Steps taken: {len(steps)}")
print(f"Zooms: {zoom_count}")
print(f"Final King position: {king_position}")

# TODO What
