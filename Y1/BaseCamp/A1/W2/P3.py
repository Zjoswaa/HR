shapes = ["Triangle", "Square", "Pentagon", "Hexagon", "Heptagon", "Octagon", "Nonagon", "Decagon"]
sides = int(input("Sides: "))
print("Amount of sides is out of range") if sides not in range(3, 11) else print(shapes[sides - 3])
