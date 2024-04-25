alycite_count = 4
boblact_count = 3
caroloc_count = 2

running_time = 180  # minutes

for i in range(running_time // 10):
    alycite_count *= 2
for i in range(running_time // 13):
    boblact_count *= 2
for i in range(running_time // 7):
    caroloc_count *= 2

print(alycite_count + boblact_count + caroloc_count)
