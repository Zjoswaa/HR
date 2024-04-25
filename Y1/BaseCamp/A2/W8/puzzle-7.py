def volume(l, b, h):
    return l*b*h


def area(l, b, h):
    return 2*l*b + 2*l*h + 2*b*h


for L in range(500):
    for B in range(500):
        for H in range(500):
            box_volume = volume(L, B, H)
            box_area = area(L, B, H)
            if box_volume == 60480 and box_area == 9826:
                print(L + B + H)
                exit(0)
