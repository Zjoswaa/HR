inputs = input("Sides: ").strip().split(",")
a = int(inputs[0].split("=")[1])
b = int(inputs[1].split("=")[1])
c = int(inputs[2].split("=")[1])
if a == b and a == c:
    print("Equilateral triangle")
elif a == b or a == c or b == c:
    print("Isosceles triangle")
else:
    print("Scalene triangle")
