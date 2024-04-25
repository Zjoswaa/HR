if __name__ == "__main__":
    file_name = input("Input file name: ")
    try:
        words = []
        longest_word_size = 0
        with open(file_name) as file:
            for line in file:
                for word in line.split(" "):
                    words.append(word)
                    if len(word.removesuffix("\n")) > longest_word_size:
                        longest_word_size = len(word.removesuffix("\n"))
        file.close()
        print(f"Length of longest word(s) is [{longest_word_size}] chars")
        print("These are all the words of that length:")
        longest_words = []
        for word in words:
            if len(word.removesuffix("\n")) == longest_word_size:
                longest_words.append((word.removesuffix("\n")))
        print(", ".join(longest_words))

    except FileNotFoundError:
        print(f"File \'{file_name}\" not found")
