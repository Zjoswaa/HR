import sys


def head(filename: str):
    try:
        with open(filename) as file:
            lines = []
            for line in file:
                lines.append(line.removesuffix("\n"))
            for line_index in range(min(10, len(lines))):
                print(lines[line_index])
        file.close()
    except FileNotFoundError:
        print(f"Error reading file: \"{filename}\"")


if __name__ == "__main__":
    try:
        head(sys.argv[1])
    except IndexError:
        print("Please provide a file name as argument")
