if __name__ == "__main__":
    input_file_name = input("Input file name: ")
    try:
        with open(input_file_name, "r") as file:
            file_content = file.read().split("\n")
            file.close()
    except FileNotFoundError:
        print(f"File \"{input_file_name}\" not found")

    output_file_name = input("Output file name: ")
    try:
        line_number = 1
        with open(output_file_name, "w") as file:
            for line in file_content:
                file.write(f"{line_number}. {line}")
                if line_number != len(file_content):  # Only put a newline after lines that are not the last line
                    file.write("\n")
                line_number += 1
        file.close()
    except FileNotFoundError:
        print(f"File \"{output_file_name}\" not found")
