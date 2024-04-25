def is_valid_date(_date):
    as_list = list(_date)
    if len(as_list) != 10:
        return False
    if as_list[4] != '-' or as_list[7] != '-':
        return False
    for index in [0, 1, 2, 3, 5, 6, 8, 9]:
        if not as_list[index].isnumeric():
            return False
    return True


date = input("Input Date: ")
if not is_valid_date(date):
    print("Input format ERROR. Correct Format: YYYY-MM-DD")
else:
    date = date.split("-")
    if int(date[1]) == 12 and int(date[2]) == 31:
        print(f"Next Date: {int(date[0]) + 1}-01-01")
    elif (int(date[1]) in [1, 3, 5, 7, 8, 10] and int(date[2]) == 31) or (int(date[1]) in [4, 6, 9, 11] and int(date[2]) == 30):
        if int(date[1]) + 1 <= 9:
            print(f"Next Date: {date[0]}-0{int(date[1]) + 1}-01")  # Extra 0 before month
        else:
            print(f"Next Date: {date[0]}-{int(date[1]) + 1}-01")
    elif int(date[1] == 2) and int(date[2]) == 28:
        print(f"Next Date: {date[0]}-03-01")
    else:
        if int(date[2]) + 1 <= 9:
            print(f"Next Date: {date[0]}-{date[1]}-0{int(date[2]) + 1}")  # Extra 0 before day
        else:
            print(f"Next Date: {date[0]}-{date[1]}-{int(date[2]) + 1}")
