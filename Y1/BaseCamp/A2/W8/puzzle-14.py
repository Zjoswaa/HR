from datetime import date, timedelta


# print(datetime.datetime.now().weekday())


def daterange(start_date, end_date):
    for i in range(int((end_date - start_date).days)):
        yield start_date + timedelta(i)


def count_friday_13s(start_date, end_date):
    friday_13_count = 0
    for day in daterange(start_date, end_date):
        if day.weekday() == 4 and day.day == 13:
            friday_13_count += 1
    return friday_13_count


print(count_friday_13s(date(2000, 1, 1), date(2099, 12, 31)))
