holidays = [[27, 4, "Koningsdag"], [5, 5, "Bevrijdingsdag"], [5, 12, "Sinterklaas"], [25, 12, "Kerstmis"]]
inputs = input("Date: ").strip().split(",")
month = int(inputs[0].split(":")[1])
day = int(inputs[1].split(":")[1])

for holiday in holidays:
    if holiday[1] == month and holiday[0] == day:
        print(holiday[2])
        exit(0)
print("No holiday found on given input")
