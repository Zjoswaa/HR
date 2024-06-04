def find_in_list(n: any, lst: list) -> bool:
    return n in lst


def rec_find_in_list(n: any, lst: list) -> bool:
    if not lst:
        return False

    if lst[0] == n:
        return True
    return rec_find_in_list(n, lst[1:])
