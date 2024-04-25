human_years = int(input("Human years: "))
if human_years < 0:
    print("Only positive numbers are allowed")
elif human_years <= 2:
    print(f"Dog years {human_years * 10.5}")
else:
    print(f"Dog years {((human_years - 2) * 4) + 21}")
