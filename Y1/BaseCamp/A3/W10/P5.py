def remove_comments(lines, output_file_name):
    new_lines = []
    for line in lines:
        comment_found = False
        new_line = ""
        for char in line:
            if not comment_found:
                if char == "#":
                    comment_found = True
                else:
                    new_line += char
        new_lines.append(new_line)

    try:
        with open(output_file_name, "w") as file:
            for line in new_lines:
                file.write(line)
        file.close()
    except FileNotFoundError:
        print(f"Failed to write to \"{input_file_name}\"")


if __name__ == "__main__":
    input_file_name = input("File to read: ")
    lines = []
    try:
        with open(input_file_name) as file:
            for line in file:
                lines.append(line)
        file.close()
    except FileNotFoundError:
        print(f"File \"{input_file_name}\" not found")

    output_file_name = input("File to save: ")
    remove_comments(lines, output_file_name)
