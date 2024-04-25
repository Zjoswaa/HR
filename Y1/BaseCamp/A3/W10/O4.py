def censor_file(original_lines: list[str], censored_words: list, output_file_name: str):
    try:
        with open(output_file_name, "w") as file:
            for line in original_lines:
                censored_line = ""
                for word in line.split(" "):
                    if word in censored_words:
                        censored_line += "*" * len(word) + " "
                    else:
                        censored_line += word + " "
                file.write(censored_line.removesuffix(" "))
    except FileNotFoundError:
        print(f"Failed to write to \"{output_file_name}\"")


if __name__ == "__main__":
    input_file_name = input("Input file name: ")
    input_file_lines = []
    try:
        with open(input_file_name, "r") as file:
            for line in file:
                input_file_lines.append(line.removesuffix("\n"))
        file.close()
    except FileNotFoundError:
        print(f"File \'{input_file_name}\" not found")

    censored_words_file_name = input("Censored words file name: ")
    censored_words = []
    try:
        with open(censored_words_file_name, "r") as file:
            for line in file:
                censored_words.append(line.removesuffix("\n"))
        file.close()
    except FileNotFoundError:
        print(f"File \'{censored_words_file_name}\" not found")

    output_file_name = input("Output file name: ")
    censor_file(input_file_lines, censored_words, output_file_name)
