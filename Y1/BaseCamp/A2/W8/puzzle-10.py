roman_numbers = {"I": 1, "V": 5, "X": 10, "L": 50, "C": 100, "D": 500, "M": 1000}
sequence = [
    "DXXXIV", "MXXVII", "CLXXVII", "CMXXV", "CCCXIII", "CDLXXXIII", "MCCCL", "MCCLXV",
    "MDXX", "DCLIII", "DCCCLVII", "MDCXC", "VII", "MLXI", "MCDXVIII", "DCCXXXVIII",
    "LVIII", "MDCLXXIII", "MCDLXXXVI", "MCCCLXXXIV", "XCII", "DLXXXV", "DCLXXXVII",
    "DCCCXCI", "DCXXXVI", "MCLXXX", "DXVII", "CCXXVIII", "MCCXIV", "CCCXCVIII",
    "DCCIV", "CCLXXIX", "DCXIX", "MCCXXXI", "CXCIV", "CIX", "DCCCXL", "MCXLVI", "DCCLV",
    "CXLIII", "MCCCLXVII", "CMLIX", "MCCLXXXII", "MCLXIII", "MDCLVI", "CCLXII", "MDLXXI",
    "DCCCXXIII", "CDLXVI", "MCDXXXV", "MXLIV", "MXCV", "CCXCVI", "MDIII", "CXXVI", "DCCXXI",
    "MCCCXVI", "DCCCVI", "MDXXXVII", "DCCLXXXIX", "MDCXXII", "MLXXVIII", "MCDLXIX", "DCLXX",
    "CDXLIX", "CMVIII", "MCDLII", "MDCV", "CCCXXX", "CMLXXVI", "CCCLXXXI", "MDLIV", "MCXXIX",
    "MX", "MCCXLVIII", "MCDI", "MCXCVII", "MCCCXXXIII", "MCXII", "CDXV", "CMXLII", "MDLXXXVIII",
    "DLI", "CCCLXIV", "CCXLV", "DCCCLXXIV", "CCCXLVII", "XLI", "XXIV", "CDXXXII", "DCCLXXII",
    "CCXI", "DLXVIII", "LXXV", "MDCXXXIX", "CLX", "DCII", "MCCXCIX", "CMXCIII"
]


def roman_to_decimal(roman_number: str) -> int:
    result = 0
    for i in range(len(roman_number)):
        if i < len(roman_number) - 1:
            if roman_numbers[roman_number[i]] < roman_numbers[roman_number[i + 1]]:
                result -= roman_numbers[roman_number[i]]
            else:
                result += roman_numbers[roman_number[i]]
        else:
            result += roman_numbers[roman_number[i]]
    return result


sorted_list = sorted([roman_to_decimal(x) for x in sequence])
print(sorted_list)
# Every step is +17, missing value is 500 = D
