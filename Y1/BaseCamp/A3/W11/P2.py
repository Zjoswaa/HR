import csv


def read_from_csv(file_name: str) -> list:
    with open(file_name, "rt", newline="", encoding="utf-8") as file:
        reader = csv.reader(file)
        return list(reader)


def write_to_csv(data: list, file_name: str):
    with open(file_name, "wt", newline="", encoding="utf-8") as file:
        writer = csv.writer(file)
        writer.writerows(data)


def print_request(file_name: str):
    game_data = read_from_csv(file_name)
    series_col = list(game_data[0]).index("Series")
    name_col = list(game_data[0]).index("Game")
    country_col = list(game_data[0]).index("Country")
    details_col = list(game_data[0]).index("Details")

    israel_ban_count = 0
    country_ban_count = {}
    assassins_creed_games = set()
    germany_bans = []
    rdr_bans = []
    for row in game_data[1:]:
        if row[country_col] in ["Israel", "Isra\u00EBl"]:  # israël
            israel_ban_count += 1
        if row[country_col] not in country_ban_count:
            country_ban_count[row[country_col]] = 1
        else:
            country_ban_count[row[country_col]] += 1
        if row[series_col] == "Assassin's Creed":
            assassins_creed_games.add(row[name_col])
        if row[country_col] == "Germany" and (row[name_col], row[details_col]) not in germany_bans:
            germany_bans.append((row[name_col], row[details_col]))
        if row[name_col] == "Red Dead Redemption" and (row[name_col], row[details_col]) not in rdr_bans:
            rdr_bans.append((row[country_col], row[details_col]))

    print(f"Games banned in Israel: {israel_ban_count}")
    print(f"Country with most games banned: {max(zip(country_ban_count.values(), country_ban_count.keys()))[1]}")
    print(f"Unique Assassin's Creed games banned: {len(assassins_creed_games)}")
    print(f"Games banned in Germany: {germany_bans}")
    print(f"Countries where Red Dead Redemption is banned: {rdr_bans}")


def make_modifications(file_name: str):
    game_data = read_from_csv(file_name)
    name_col = list(game_data[0]).index("Game")
    country_col = list(game_data[0]).index("Country")
    status_col = list(game_data[0]).index("Ban Status")
    genre_col = list(game_data[0]).index("Genre")

    for row in game_data[1:]:
        if row[country_col] == "Germany":
            game_data.remove(row)
        if row[name_col] == "Silent Hill VI: Homecoming":
            row[name_col] = "Silent Hill Remastered"
        if row[country_col] == "Brazil" and row[name_col] == "Bully":
            row[status_col] = "Ban Lifted"
        if row[name_col] == "Manhunt II" and row[genre_col] == "Stealth":
            row[genre_col] = "Action"

    write_to_csv(game_data, file_name)


def add_item(file_name: str):
    game_data = read_from_csv(file_name)

    game_id = input("ID: ")
    game_name = input("Name: ")
    game_series = input("Series: ")
    game_country = input("Country: ")
    game_details = input("Details: ")
    game_category = input("Category: ")
    game_status = input("Status: ")
    game_wikipedia = input("Wikipedia: ")
    game_image = input("Image: ")
    game_summary = input("Summary: ")
    game_developer = input("Developer: ")
    game_publisher = input("Publisher: ")
    game_genre = input("Genre: ")
    game_homepage = input("Homepage: ")

    game_data.append([game_id, game_name, game_series, game_country, game_details, game_category, game_status,
                      game_wikipedia, game_image, game_summary, game_developer, game_publisher, game_genre,
                      game_homepage])

    write_to_csv(game_data, file_name)


def print_overview(file_name: str):
    game_data = read_from_csv(file_name)
    name_col = list(game_data[0]).index("Game")
    country_col = list(game_data[0]).index("Country")

    overview = {}
    for row in game_data[1:]:
        if row[country_col] not in overview:
            overview[row[country_col]] = [row[name_col]]
        elif row[name_col] not in overview[row[country_col]]:
            overview[row[country_col]].append(row[name_col])

    for country, games in overview.items():
        print(f"{country} - {len(games)}")
        for game in games:
            print(f"- {game}")


def search_by_country(file_name: str):
    game_data = read_from_csv(file_name)
    name_col = list(game_data[0]).index("Game")
    country_col = list(game_data[0]).index("Country")
    details_col = list(game_data[0]).index("Details")

    search_term = input("Country name: ")

    for row in game_data[1:]:
        if row[country_col].lower() == search_term.lower():
            print(f"{row[name_col]} - {row[details_col]}")


def main(file_name: str):
    while True:
        user_input = input("[I] Print request info from assignment\n[M] Make modification based on assignment\n"
                           "[A] Add new game to list\n[O] Overview of banned games per country\n"
                           "[S] Search the dataset by country\n[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "i":
            print_request(file_name)
        elif user_input.lower() == "m":
            make_modifications(file_name)
        elif user_input.lower() == "a":
            add_item(file_name)
        elif user_input.lower() == "o":
            print_overview(file_name)
        elif user_input.lower() == "s":
            search_by_country(file_name)


if __name__ == "__main__":
    main("bannedvideogames.csv")
