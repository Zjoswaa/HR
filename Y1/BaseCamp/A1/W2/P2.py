year = int(input("Year: "))
if not year % 400:
    print("Leap year")
elif not year % 100:
    print("Not a leap year")
elif not year % 4:
    print("Leap year")
else:
    print("Not a leap year")
