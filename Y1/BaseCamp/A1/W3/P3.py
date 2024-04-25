width = int(input("Width: "))
height = int(input("Height: "))
counter = 0
for i in range(height):
    for j in range(width):
        print(counter, end=" ")
        counter = (counter + 1) % 10
    print()
