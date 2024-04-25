def analyze_file(file_name):
    try:
        with open(file_name, "r") as file:
            lines = file.readlines()
            current_line = 0
            for line in lines:
                if line.startswith("def "):
                    function_name = lines[current_line].removeprefix("def ").removesuffix(":\n")
                    if not current_line:
                        print(f"File: {file_name} contains a function [{function_name}] on line [{current_line + 1}] "
                              f"without a preceding comment.")
                    elif not lines[current_line - 1].startswith("#"):
                        print(f"File: {file_name} contains a function [{function_name}] on line [{current_line + 1}] "
                              f"without a preceding comment.")
                current_line += 1

    except FileNotFoundError:
        print(f"Error reading file: \"{file_name}\"")


if __name__ == "__main__":
    input_file_names = input("Files to read: ").split(",")
    for file_name in input_file_names:
        analyze_file(file_name.strip())
