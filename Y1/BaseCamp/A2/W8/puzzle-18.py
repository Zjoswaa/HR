people = {}

transactions = [
    "Alice to Bob: 10 astrocoin",
    "Ben to Carol: 15 belgacoin",
    "Charlie to Dave: 20 chinacoin",
    "David to Eve: 8 deltacoin",
    "Emma to Frank: 12 extracoin",
    "Fred to Grace: 25 astrocoin",
    "George to Harry: 18 belgacoin",
    "Helen to Ivan: 30 chinacoin",
    "Ingrid to Jack: 22 deltacoin",
    "Jack to Kate: 14 extracoin",
    "Kate to Leo: 9 astrocoin",
    "Leo to Mary: 17 belgacoin",
    "Mary to Nathan: 11 chinacoin",
    "Nathan to Olivia: 20 deltacoin",
    "Olivia to Paul: 16 extracoin",
    "Paul to Quinn: 13 astrocoin",
    "Quinn to Rachel: 19 belgacoin",
    "Rachel to Sam: 10 chinacoin",
    "Sam to Tina: 15 deltacoin",
    "Tina to Ulysses: 21 extracoin",
    "Ulysses to Victor: 18 astrocoin",
    "Victor to Wendy: 23 belgacoin",
    "Wendy to Xavier: 25 chinacoin",
    "Xavier to Yara: 11 deltacoin",
    "Yara to Zach: 20 extracoin",
    "Zach to Alice: 10 astrocoin",
    "Alice to Carol: 15 belgacoin",
    "Ben to Dave: 20 chinacoin",
    "Charlie to Eve: 8 deltacoin",
    "David to Frank: 12 extracoin",
    "Emma to Grace: 25 astrocoin",
    "Fred to Harry: 18 belgacoin",
    "George to Ivan: 30 chinacoin",
    "Helen to Jack: 22 deltacoin",
    "Ingrid to Kate: 14 extracoin",
    "Jack to Leo: 9 astrocoin",
    "Kate to Mary: 17 belgacoin",
    "Leo to Nathan: 11 chinacoin",
    "Mary to Olivia: 20 deltacoin",
    "Nathan to Paul: 16 extracoin",
    "Olivia to Quinn: 13 astrocoin",
    "Paul to Rachel: 19 belgacoin",
    "Quinn to Sam: 10 chinacoin",
    "Rachel to Tina: 15 deltacoin",
    "Sam to Ulysses: 21 extracoin",
    "Tina to Victor: 18 astrocoin",
    "Ulysses to Wendy: 23 belgacoin",
    "Victor to Xavier: 25 chinacoin",
    "Wendy to Yara: 11 deltacoin",
    "Xavier to Zach: 20 extracoin",
    "Zach to Alice: 10 astrocoin",
    "Alice to Bob: 15 belgacoin",
    "Ben to Carol: 20 chinacoin",
    "Charlie to Dave: 8 deltacoin",
    "David to Eve: 12 extracoin",
    "Emma to Frank: 25 astrocoin",
    "Fred to Grace: 18 belgacoin",
    "George to Harry: 30 chinacoin",
    "Helen to Ivan: 22 deltacoin",
    "Ingrid to Jack: 14 extracoin",
    "Jack to Kate: 9 astrocoin",
    "Kate to Leo: 17 belgacoin",
    "Leo to Mary: 11 chinacoin",
    "Mary to Nathan: 20 deltacoin",
    "Nathan to Olivia: 16 extracoin",
    "Olivia to Paul: 13 astrocoin",
    "Paul to Quinn: 19 belgacoin",
    "Quinn to Rachel: 10 chinacoin",
    "Rachel to Sam: 15 deltacoin",
    "Sam to Tina: 21 extracoin",
    "Tina to Ulysses: 18 astrocoin",
    "Ulysses to Victor: 23 belgacoin",
    "Victor to Wendy: 25 chinacoin",
    "Wendy to Xavier: 11 deltacoin",
    "Xavier to Yara: 20 extracoin",
    "Yara to Zach: 15 astrocoin",
    "Zach to Alice: 19 belgacoin",
    "Alice to Carol: 14 chinacoin",
    "Wendy to Xavier: 11 deltacoin",
    "Xavier to Yara: 20 extracoin",
    "Yara to Zach: 15 astrocoin",
    "Zach to Alice: 19 belgacoin",
    "Alice to Carol: 14 chinacoin",
    "Carol to Dave: 11 deltacoin",
    "Dave to Eve: 20 extracoin",
    "Eve to Frank: 15 astrocoin",
    "Frank to Grace: 19 belgacoin",
    "Grace to Harry: 14 chinacoin",
    "Harry to Ivan: 11 deltacoin",
    "Ivan to Jack: 20 extracoin",
    "Jack to Kate: 15 astrocoin",
    "Kate to Leo: 19 belgacoin",
    "Leo to Mary: 14 chinacoin",
    "Mary to Nathan: 11 deltacoin",
    "Nathan to Olivia: 20 extracoin",
    "Olivia to Paul: 15 astrocoin",
    "Paul to Quinn: 19 belgacoin",
    "Quinn to Rachel: 14 chinacoin",
    "Rachel to Sam: 11 deltacoin"
]


def do_transaction(transaction: str):
    person_from = transaction.split(":")[0].strip().split(" ")[0]
    person_to = transaction.split(":")[0].strip().split(" ")[2]
    amount = int(transaction.split(":")[1].strip().split(" ")[0])
    coin = transaction.split(":")[1].strip().split(" ")[1]
    print(f"From {person_from} to {person_to}: {amount} {coin}")
    if person_from not in people:
        people[person_from] = {"astrocoin": 100, "belgacoin": 100, "chinacoin": 100, "deltacoin": 100, "extracoin": 100}
    if person_to not in people:
        people[person_to] = {"astrocoin": 100, "belgacoin": 100, "chinacoin": 100, "deltacoin": 100, "extracoin": 100}
    if people[person_from][coin] >= amount:
        people[person_from][coin] -= amount
        people[person_to][coin] += amount
    else:
        people[person_to][coin] += people[person_from][coin]
        people[person_from][coin] = 0



def calculate_capital(coins: dict) -> int:
    total = 0
    for coin, amount in coins.items():
        if coin == "astrocoin":
            total += 13 * amount
        elif coin == "belgacoin":
            total += 17 * amount
        elif coin == "chinacoin":
            total += 19 * amount
        elif coin == "deltacoin":
            total += 11 * amount
        elif coin == "extracoin":
            total += 15 * amount
    return total


for transaction in transactions:
    do_transaction(transaction)
# print(people)

richest_person = None
highest_capital = 0

for person, coins in people.items():
    capital = calculate_capital(coins)
    if capital > highest_capital:
        richest_person = person
        highest_capital = capital

print(f"Richest person: {richest_person} (€{highest_capital}) {people[richest_person]}")
