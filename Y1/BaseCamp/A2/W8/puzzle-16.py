# regexr.com/7ucvo

text = ("Computers en computing hebben een enorme invloed gehad op vrijwel elk aspect van ons dagelijks leven. "
        "Van communicatie tot entertainment, van zakelijke operaties tot wetenschappelijk onderzoek, de impact van "
        "computers is onmiskenbaar. In dit artikel zullen we een diepgaande blik werpen op verschillende aspecten van "
        "computing en hoe het onze wereld heeft gevormd. Een van de belangrijkste aspecten van computing is de evolutie "
        "van hardware. Van de allereerste mechanische rekenmachines tot de huidige krachtige supercomputers, hebben " 
        "hardware-innovaties de rekenkracht en snelheid van computers exponentieel vergroot. Dit heeft geleid tot de "
        "ontwikkeling van complexe systemen die in staat zijn tot taken die voorheen ondenkbaar waren. Naast hardware is "
        "software een essentieel onderdeel van computing. Software omvat een breed scala aan programma's, "
        "besturingssystemen en applicaties die de functionaliteit van computers bepalen. Van eenvoudige teksteditors tot "
        "geavanceerde data-analyse tools, software speelt een cruciale rol in het mogelijk maken van verschillende "
        "computertaken. Een ander belangrijk aspect van computing is netwerken en internet. De opkomst van het internet "
        "heeft de wereld met elkaar verbonden op een manier die voorheen ondenkbaar was. Het stelt mensen in staat om "
        "informatie te delen, te communiceren en samen te werken over grote afstanden. Dit heeft geleid tot een "
        "revolutie in communicatie, handel en sociale interactie. Naast de vele voordelen heeft computing ook "
        "uitdagingen met zich meegebracht. Cyberbeveiliging is bijvoorbeeld een groeiende zorg, omdat hackers "
        "voortdurend op zoek zijn naar manieren om systemen binnen te dringen en gevoelige informatie te stelen. Het is "
        "van vitaal belang dat organisaties en individuen zich bewust zijn van deze bedreigingen en passende "
        "maatregelen nemen om zichzelf te beschermen. De toekomst van computing belooft spannende ontwikkelingen. "
        "Kunstmatige intelligentie en machine learning worden steeds geavanceerder en hebben het potentieel om "
        "verschillende industrieën te transformeren, van gezondheidszorg tot transport. Quantum computing staat "
        "ook op het punt om een revolutie teweeg te brengen in de manier waarop we problemen oplossen en complexe "
        "berekeningen uitvoeren. In conclusie heeft computing een diepgaande impact gehad op onze samenleving en zal "
        "het blijven evolueren en innoveren in de komende jaren. Het is belangrijk voor individuen en organisaties om "
        "de nieuwste ontwikkelingen bij te houden en zich aan te passen aan de veranderende landschap van computing. "
        "Alleen door dit te doen, kunnen we optimaal profiteren van de vele voordelen die computing te bieden heeft.")

text = text.replace(".", "")
text = text.replace(",", "")

long_word_count = 0  # 6 or more characters

for word in text.split(" "):
    if len(word) > 5 and word.find("-") == -1 and word.find("'") == -1:
        print(word, end=" ")
        long_word_count += 1

print(f"\nValid words with more than 5 characters: {long_word_count}")

# TODO What
