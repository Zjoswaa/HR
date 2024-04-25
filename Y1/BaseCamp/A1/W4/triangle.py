n = 4

# Using for loop
s = ""
for i in range(n):
    for j in range(i):
        s += " "
    for j in range(i, n):
        s += "*"
    s += "\n"
print(s)

# Using while loop
s = ""
i = 0
while i < n:
    j = 0
    while j < i:
        s += " "
        j += 1
    j = i
    while j < n:
        s += "*"
        j += 1
    s += "\n"
    i += 1
print(s)
