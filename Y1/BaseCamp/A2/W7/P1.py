import os
import sys


def load_txt_file(file_name):
    file_content = {}

    with open(os.path.join(sys.path[0], file_name), newline='', encoding="utf8") as file_obj:
        for line in file_obj.readlines():
            items = line.split()
            _month = int(items[0])
            # day = int(items[1])
            _year = int(items[2])
            _average_temp = float(items[3])

            if _year not in file_content:
                file_content[_year] = {}
            if _month not in file_content[_year]:
                file_content[_year][_month] = []
            file_content[_year][_month].append(_average_temp)

    return file_content


def fahrenheit_to_celsius(fahrenheit: float) -> float:
    return (fahrenheit - 32) * 5 / 9


def average_temp_per_month(temperatures_per_year: dict) -> list:
    averages = []
    for _month, _temps in temperatures_per_year.items():
        averages.append((_month, sum(_temps) / len(_temps)))
    return averages


def average_temp_per_year(temperatures: dict) -> list:
    averages = []
    for _year in temperatures:
        total_this_year = 0
        year_length = 0
        for _month in temperatures[_year]:
            for temp in temperatures[_year][_month]:
                year_length += 1
                total_this_year += temp
        averages.append((_year, total_this_year / year_length))
    return averages


if __name__ == "__main__":
    content = load_txt_file("NLAMSTDM.txt")
    # user_input = input("[1] Print the average temperatures per year (Fahrenheit)\n"
    #                    "[2] Print the average temperatures per year (Celsius)\n"
    #                    "[3] Print the warmest and coldest year as tuple based on the average temperature\n"
    #                    "[4] Print the warmest month of a year based on the input year of the user\n"
    #                    "[5] Print the coldest month of a year based on the input year of the user\n"
    #                    "[6] Print a list of tuples where the first element of each tuple is the year and the second"
    #                    "element of the tuple is a dictionary with months as the keys and the average temperature"
    #                    "(in Celsius) of each month as the value\n")
    user_input = input("Input: ")
    if user_input == "1":
        # for year_average in average_temp_per_year(content):
        #     print(f"{year_average[0]}, {year_average[1]}")
        print(average_temp_per_year(content))
    elif user_input == "2":
        celcius_averages = []
        # for year_average in average_temp_per_year(content):
        #     print(f"({year_average[0]}, {fahrenheit_to_celsius(year_average[1])})")
        celcius_temps = list(map(lambda x: fahrenheit_to_celsius(x[1]), average_temp_per_year(content)))
        index = 0
        for year in average_temp_per_year(content):
            celcius_averages.append((year[0], celcius_temps[index]))
            index += 1
        print(celcius_averages)
    elif user_input == "3":
        warmest_year = None
        coldest_year = None
        max_temp = None
        min_temp = None
        for average_temp in average_temp_per_year(content):
            if max_temp is None or average_temp[1] > max_temp:
                warmest_year = average_temp
                max_temp = average_temp[1]
            if min_temp is None or average_temp[1] < min_temp:
                coldest_year = average_temp
                min_temp = average_temp[1]
        print(f"({warmest_year[0]}, {coldest_year[0]})")
    elif user_input == "4":
        months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                  "November", "December")
        user_input = int(input("Year: "))
        warmest_month = None
        warmest_temp = None
        for month in average_temp_per_month(content[user_input]):
            if warmest_temp is None or month[1] > warmest_temp:
                warmest_month = months[month[0] - 1]
                warmest_temp = month[1]
        print(warmest_month)
    elif user_input == "5":
        months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                  "November", "December")
        user_input = int(input("Year: "))
        coldest_month = None
        coldest_temp = None
        for month in average_temp_per_month(content[user_input]):
            if coldest_temp is None or month[1] < coldest_temp:
                coldest_month = months[month[0] - 1]
                coldest_temp = month[1]
        print(coldest_month)
    elif user_input == "6":
        years = []
        years_celcius = []
        for year in content:
            this_years_months = {}
            # for month in content[year]:
            #     this_years_months[month] = sum(content[year][month]) / len(content[year][month])
            for month, temps in content[year].items():
                this_years_months[month] = sum(temps) / len(temps)
            years.append((year, this_years_months))
        for year in years:
            temps = {}
            for month, temp in year[1].items():
                temps[month] = fahrenheit_to_celsius(temp)
            years_celcius.append((year[0], temps))
        print(years_celcius)
