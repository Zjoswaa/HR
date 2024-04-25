temperatures = (
    ('1995', '3', ['47.3', '40.0', '38.3', '36.3', '37.4', '40.3', '41.1', '40.5', '41.6', '43.2', '46.2', '45.8',
                   '44.9', '39.4', '40.5', '42.0', '46.5', '46.2', '43.3', '41.7', '40.7', '39.6', '44.2', '47.8',
                   '45.9', '47.3', '39.8', '35.2', '38.5', '40.5', '47.0']),
    ('2010', '3', ['39.2', '36.7', '35.5', '35.2', '35.8', '33.8', '30.7', '33.2', '32.3', '33.3', '37.3', '39.9',
                   '40.8', '42.9', '42.7', '42.6', '44.8', '50.3', '52.2', '55.2', '47.2', '45.0', '48.6', '55.0',
                   '57.4', '50.9', '48.6', '46.2', '49.6', '50.1', '43.6']),
    ('2020', '3', ['43.2', '41.1', '40.0', '43.6', '42.6', '44.0', '44.0', '47.9', '46.6', '50.5', '51.5', '47.7',
                   '44.7', '44.0', '48.9', '45.3', '46.6', '49.7', '47.2', '44.8', '41.8', '40.9', '41.0', '42.7',
                   '43.4', '44.0', '46.4', '45.5', '40.7', '39.5', '40.6'])
)


def different_unique_values(year1, year2):
    unique_year1 = set()
    unique_year2 = set()
    for item in temperatures:
        if item[0] == year1:
            for temperature in item[2]:
                unique_year1.add(temperature)
        elif item[0] == year2:
            for temperature in item[2]:
                unique_year2.add(temperature)
    return len(unique_year1.intersection(unique_year2))


def year_with_highest_temp():
    highest = 0
    highest_year = ""
    for item in temperatures:
        for temperature in item[2]:
            if float(temperature) > highest:
                highest = float(temperature)
                highest_year = item[0]
    return highest_year


def year_with_warmest_month():
    averages = []
    current_index = -1
    highest_average = 0
    highest_index = 0
    for item in temperatures:
        average = 0
        for temperature in item[2]:
            average += float(temperature)
        average /= len(item[2])
        averages.append(average)

    for average in averages:
        current_index += 1
        if average > highest_average:
            highest_average = average
            highest_index = current_index
    return temperatures[highest_index][0]


if __name__ == "__main__":
    print(different_unique_values("1995", "2010"))
    print(different_unique_values("1995", "2020"))
    print(year_with_highest_temp())
    print(year_with_warmest_month())
