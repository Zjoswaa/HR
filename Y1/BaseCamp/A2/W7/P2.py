import os
import sys
import csv


def load_csv_file(file_name):
    with open(os.path.join(sys.path[0], file_name), newline='', encoding="utf8") as csv_file:
        file_content = list(csv.reader(csv_file, delimiter=","))
    return file_content


def get_headers(file_content):
    return file_content[0]


def search_by_type(file_content, show_type):
    return list(filter(lambda x: x[1] == show_type, file_content[1:]))


def search_by_director(file_content, director):
    return list(filter(lambda x: x[3] == director, file_content[1:]))


def get_directors(file_content):
    unique_directors = set()
    for item in file_content[1:]:
        if len(item[3].replace(", ", ",").split(",")) == 1:
            unique_directors.add(item[3])
        else:
            _to_add = ""
            for _director in item[3].replace(", ", ",").split(","):
                _to_add += _director + ", "
            unique_directors.add(_to_add[:-2])
    return sorted(unique_directors)


if __name__ == "__main__":
    # print(search_by_type(load_csv_file("netflix_titles.csv"), "Movie"))
    # print(search_by_director(load_csv_file("netflix_titles.csv"), "Julien Leclercq"))
    # print(get_directors(load_csv_file("netflix_titles.csv")))
    user_input = input("Input: ")
    if user_input == "1":
        print(len(search_by_type(load_csv_file("netflix_titles.csv"), "TV Show")))
    elif user_input == "2":
        print(len(search_by_type(load_csv_file("netflix_titles.csv"), "Movie")))
    elif user_input == "3":
        movie_directors = []
        show_directors = []
        both_directors = set()
        for movie in search_by_type(load_csv_file("netflix_titles.csv"), "Movie"):
            if movie[3] != "" and movie[3].replace(", ", ",").split(",") not in movie_directors:
                movie_directors.append(movie[3].replace(", ", ",").split(","))
        for show in search_by_type(load_csv_file("netflix_titles.csv"), "TV Show"):
            if show[3] != "" and show[3].replace(", ", ",").split(",") not in show_directors:
                show_directors.append(show[3].replace(", ", ",").split(","))
        for directors_list in movie_directors:
            if directors_list in show_directors:
                if len(directors_list) == 1:
                    both_directors.add(directors_list[0])
                else:
                    to_add = ""
                    for director in directors_list:
                        to_add += director + ", "
                    both_directors.add(to_add[:-2])
        print(sorted(both_directors))
    elif user_input == "4":
        directors = []
        content = load_csv_file("netflix_titles.csv")
        movies = search_by_type(content, "Movie")
        shows = search_by_type(content, "TV Show")
        for director in get_directors(load_csv_file("netflix_titles.csv")):
            director_movies = search_by_director(content, director)
            movies_directed = 0
            shows_directed = 0
            for movie in movies:
                if movie in director_movies:
                    movies_directed += 1
            for show in shows:
                if show in director_movies:
                    shows_directed += 1
            directors.append((director, movies_directed, shows_directed))
        print(directors)
