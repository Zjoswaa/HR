position_knight = {"x": 0, "y": 0}
position_queen = {"x": 0, "y": 0}
possible_positions = 0
board_size = 8


def knight_hits_queen(position_knight, position_queen):
    move_calc = [(-2, 1), (-2, -1), (-1, 2), (-1, -2), (1, 2), (1, -2), (2, 1), (2, -1)]
    for x_dif, y_dif in move_calc:
        if position_knight["x"] + x_dif == position_queen["x"] and position_knight["y"] + y_dif == position_queen["y"]:
            return True
    return False


def position_check(position_knight, position_queen, possible_positions):
    # check horizontal & vertical attack queen or same square
    if position_knight["x"] == position_queen["x"] or position_knight["y"] == position_queen["y"]:
        return possible_positions
    # check diagonal attack queen
    if abs(position_knight["x"] - position_queen["x"]) == abs(position_knight["y"] - position_queen["y"]):
        return possible_positions
    # check attack knight
    if not knight_hits_queen(position_knight, position_queen):
        possible_positions += 1
    return possible_positions


for x_k in range(8):
    for y_k in range(8):
        for x_q in range(8):
            for y_q in range(8):
                position_knight["x"] = x_k
                position_knight["y"] = y_k
                position_queen["x"] = x_q
                position_queen["y"] = y_q
                possible_positions = position_check(position_knight, position_queen, possible_positions)

print(f"{possible_positions}")
