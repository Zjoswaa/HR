import sys


def tail(filename: str):
    try:
        with open(filename) as file:
            filedata = file.readlines()
            if len(filedata) < 10:
                for line in filedata:
                    print(line, end="")
            else:
                for line in filedata[-10:]:
                    print(line, end="")
        print()
        file.close()
    except FileNotFoundError:
        print(f"Error reading file: \"{filename}\"")


if __name__ == "__main__":
    try:
        tail(sys.argv[1])
    except IndexError:
        print("Please provide a file name as argument")
