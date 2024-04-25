from itertools import chain, combinations

apples = set()
pears = set()

fruits = {
    "Attica": 157,
    "Belle": 165,
    "Clearance": 174,
    "Dormado": 166,
    "Elite": 193,
    "Fruity": 193,
    "Grandissimo": 204,
    "Heavenly": 165,
    "Irido": 163,
    "Jacobine": 141,
    "Kiki": 205,
    "Lentegoud": 218,
    "Mathille": 223,
    "Novum": 164,
    "Ottobel": 154
}


def powerset(iterable):
    s = list(iterable)
    return chain.from_iterable(combinations(s, r) for r in range(len(s)+1))


for fruit_set in powerset(fruits):
    average = 0
    for fruit in fruit_set:
        average += fruits[fruit]
    if len(fruit_set) != 0:
        average /= len(fruit_set)
        if average == 161:
            for fruit in fruit_set:
                apples.add(fruit)
        if average == 206:
            for fruit in fruit_set:
                pears.add(fruit)


print(f"Apples: {apples} : {len(apples)}")
print(f"Pears: {pears} : {len(pears)}")
