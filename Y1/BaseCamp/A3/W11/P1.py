import json


def read_from_json(file_name: str) -> dict:
    with open(file_name, "r", encoding="utf-8") as file:
        return json.load(file)


def write_to_json(data: dict, file_name: str):
    with open(file_name, "w", encoding="utf-8") as file:
        json.dump(data, file, ensure_ascii=False, indent=2)


def print_overview():
    movie_data = read_from_json("movies.json")
    movies_in_2004_count = 0
    science_fiction_movies_count = 0
    keanu_reeves_movies = []
    sylvester_stallone_movies = []
    for item in movie_data:
        # print(f"Title: {item["title"]}, Release year: {item["year"]}, Cast: {item["cast"]}, Genres: {item["genres"]}")
        if item["year"] == 2004:
            movies_in_2004_count += 1
        if "science fiction" in [x.lower() for x in item["genres"]]:
            science_fiction_movies_count += 1
        if "keanu reeves" in [x.lower() for x in item["cast"]]:
            keanu_reeves_movies.append(item)
        if "sylvester stallone" in [x.lower() for x in item["cast"]] and 1995 <= item["year"] <= 2005:
            sylvester_stallone_movies.append(item)
    print(f"Movies released in 2004: {movies_in_2004_count}")
    print(f"Science Fiction movies: {science_fiction_movies_count}")
    print(f"Movies with Keanu Reeves: {keanu_reeves_movies}")
    print(f"Movies with Sylvester Stallone (1995-2005): {sylvester_stallone_movies}")


def make_modifications():
    movie_data = read_from_json("movies.json")
    oldest_movie = movie_data[0]["year"]
    for item in movie_data:
        if item["title"].lower() == "gladiator" and item["year"] == 2000:
            item["year"] = 2001
        if item["year"] < oldest_movie:
            oldest_movie = item["year"]
        if "Natalie Portman" in item["cast"]:
            item["cast"].remove("Natalie Portman")
            item["cast"].append("Nat Portman")
        if "Kevin Spacey" in item["cast"]:
            item["cast"].remove("Kevin Spacey")

    # Change the oldest movie to one year earlier
    for item in movie_data:
        if item["year"] == oldest_movie:
            item["year"] -= 1

    write_to_json(movie_data, "movies.json")


def search_by_title():
    movie_data = read_from_json("movies.json")
    title = input("Title to search: ")
    for item in movie_data:
        if title.lower() in item["title"].lower():
            print(item)


def change_by_title():
    movie_data = read_from_json("movies.json")
    title = input("Title to change: ")
    new_movie = None
    for item in movie_data:
        if item["title"] == title:
            new_title = input(f"New title for \"{title}\": ")
            item["title"] = new_title
            while True:
                try:
                    new_year = input(f"New release year for \"{title}\": ")
                    item["year"] = int(new_year)
                    break
                except ValueError:
                    print("Invalid year")
                    continue
            new_movie = item

    if new_movie is None:
        print(f"Movie \"{title}\" not found")
    else:
        print(new_movie)
    write_to_json(movie_data, "movies.json")


def main():

    while True:
        user_input = input("[I] Movie information overview\n[M] Make modification based on assignment\n"
                           "[S] Search a movie title\n[C] Change title and/or release year by search on title\n"
                           "[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "i":
            print_overview()
        elif user_input.lower() == "m":
            make_modifications()
        elif user_input.lower() == "s":
            search_by_title()
        elif user_input.lower() == "c":
            change_by_title()


if __name__ == "__main__":
    main()
