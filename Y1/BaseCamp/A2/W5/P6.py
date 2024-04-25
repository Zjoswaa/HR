def next_verse(vers_number: int) -> str:
    song = ""
    days = ["1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th"]
    gifts = ["A partridge in a pear tree",
             "Two turtledoves",
             "Three French hens",
             "Four calling birds",
             "Five gold rings (five golden rings)",
             "Six geese a-laying",
             "Seven swans a-swimming",
             "Eight maids a-milking",
             "Nine ladies dancing",
             "Ten lords a-leaping",
             "Eleven pipers piping",
             "Twelve drummers drumming"]
    song += f"On the {days[vers_number - 1]} day of Christmas, my true love sent to me "
    for vers in range(vers_number, 0, -1):
        if not vers - 1:
            if vers_number == 1:
                song += gifts[vers - 1]
            else:
                song += " And " + gifts[vers - 1]
        else:
            if vers == vers_number:
                song += gifts[vers - 1]
            else:
                song += ", " + gifts[vers - 1]

    return song


if __name__ == "__main__":
    for vers in range(1, 13):
        print(next_verse(vers))
