def count_words(words: list[str]):
    occurences = {}
    for word in words:
        current_word = word.replace("!", "").replace(",", "").replace("-", "").replace(".", "").lower()
        if current_word not in occurences:
            occurences[current_word] = 1
        else:
            occurences[current_word] += 1

    highest = max(occurences.values())
    lowest = min(occurences.values())
    most_occuring_words = []
    least_occuring_words = []

    for word in occurences:
        if occurences[word] == highest:
            most_occuring_words.append(word)
        if occurences[word] == lowest:
            least_occuring_words.append(word)

    print(f"Most: {most_occuring_words}")
    print(f"Least: {least_occuring_words}")


if __name__ == "__main__":
    file_name = input("Input file name: ")
    try:
        words = []
        with open(file_name) as file:
            for line in file:
                for word in line.split(" "):
                    words.append(word.removesuffix("\n"))
        file.close()
        count_words(words)

    except FileNotFoundError:
        print(f"File \"{file_name}\" not found")
