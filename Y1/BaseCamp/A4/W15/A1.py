def rec_print_folders(n: int, pref: str, root: list) -> None:
    if n == 0:
        print("Folder_0", end="")
    print('>' * n + pref)
    for item in root:
        if isinstance(item, list):
            rec_print_folders(n + 1, "Folder_" + str(n + 1), item)
        else:
            if n == 0:
                print(" " + item)
            else:
                print("-" * n + " " + item)


def rec_count_files(root: list) -> int:
    file_count = 0
    for item in root:
        if isinstance(item, list):
            file_count += rec_count_files(item)
        else:
            file_count += 1
    return file_count


if __name__ == "__main__":
    test_cases = [
        ['file_1', []],
        ['file_1', 'file_2', ['file_1']],
        ['file_1', 'file_2', ['file_3', 'file_4', 'file_5'], ['file_6', ['file_7', 'file_8'], ['file_9'], 'file_9',
                                                              ['file_10']], []],
        ['file_1', ['file_3', ['file_2', ['file_10', ['file_9', 'file_8']]]], []],
        [[], [[], [[]]]]
    ]

    for case in test_cases:
        rec_print_folders(0, '', case)
        print('Number of files in case: ', case, ' is ', rec_count_files(case))
