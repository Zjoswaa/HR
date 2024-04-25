coins = {1: 2.30, 2: 3.06, 5: 3.92, 10: 4.10, 20: 5.74, 50: 7.80, 100: 7.50, 200: 8.50}

highest_value = 0

for coin_1_value, coin_1_weight in coins.items():
    for coin_2_value, coin_2_weight in coins.items():
        for coin_3_value, coin_3_weight in coins.items():
            for coin_4_value, coin_4_weight in coins.items():
                for coin_5_value, coin_5_weight in coins.items():
                    for coin_6_value, coin_6_weight in coins.items():
                        if coin_1_weight + coin_2_weight + coin_3_weight + coin_4_weight + coin_5_weight + coin_6_weight == 30.2:
                            if coin_1_value + coin_2_value + coin_3_value + coin_4_value + coin_5_value + coin_6_value > highest_value:
                                highest_value = coin_1_value + coin_2_value + coin_3_value + coin_4_value + coin_5_value + coin_6_value
                                print(f"{coin_1_weight} {coin_1_value}, {coin_2_weight} {coin_2_value}, {coin_3_weight} {coin_3_value}, {coin_4_weight} {coin_4_value}, {coin_5_weight} {coin_5_value}, {coin_6_weight} {coin_6_value}")

print(highest_value)
