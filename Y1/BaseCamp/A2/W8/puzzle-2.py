registers = {chr(i): 100 for i in range(ord('A'), ord('Z')+1)}

instructions = [
    "ADD S,100", "ADD Z,100", "ADD Z,18", "SUB D,P",
    "SUB P,67", "MUL U,M", "MUL M,36", "LOAD P,A",
    "LOAD A,59", "MUL T,Y", "MUL Y,10", "MUL I,X",
    "MUL X,39", "LOAD K,A", "LOAD A,12", "LOAD U,R",
    "LOAD R,11", "MUL V,G", "MUL G,64", "LOAD Q,H",
    "LOAD H,66", "MUL R,H", "MUL H,54", "ADD V,H",
    "ADD H,68", "SUB A,N", "SUB N,81", "LOAD F,U",
    "LOAD U,47", "LOAD X,K", "LOAD K,74", "MUL Q,V",
    "MUL V,34", "SUB J,S", "SUB S,73", "MUL S,B",
    "MUL B,71", "ADD X,Z", "ADD Z,61", "MUL V,F",
    "MUL F,56", "SUB C,O", "SUB O,94", "LOAD Y,F",
    "LOAD F,76", "MUL L,P", "MUL P,13", "MUL B,J",
    "MUL J,88", "MUL U,F", "MUL F,31", "ADD A,Y",
    "ADD Y,35", "ADD M,Q", "ADD Q,54", "SUB O,I",
    "SUB I,94", "LOAD M,Z", "LOAD Z,75", "ADD Q,Y",
    "ADD Y,81", "ADD N,B", "ADD B,71", "SUB S,R",
    "SUB R,35", "MUL P,L", "MUL L,63", "SUB A,R",
    "SUB R,79", "SUB O,T", "SUB T,13", "ADD U,F",
    "ADD F,80", "ADD C,Z", "ADD Z,80", "SUB B,V",
    "SUB V,19", "LOAD A,O", "LOAD O,11", "SUB H,I",
    "SUB I,24", "ADD L,J", "ADD J,18", "ADD F,I",
    "ADD I,77", "ADD V,I", "ADD I,92", "SUB O,W",
    "SUB W,51", "MUL P,D", "MUL D,13", "SUB M,K",
    "SUB K,63", "ADD I,D", "ADD D,42", "ADD T,N",
    "ADD N,12", "ADD A,M", "ADD M,28", "LOAD X,F", "LOAD F,67"
]


def load(register: str, value: str):
    if value.isdigit() or (value[0] == "-" and value[1:].isdigit()):
        registers[register] = int(value)
    else:
        registers[register] = registers[value]


def add(register: str, value: str):
    if value.isdigit() or (value[0] == "-" and value[1:].isdigit()):
        registers[register] += int(value)
    else:
        registers[register] += registers[value]


def sub(register: str, value: str):
    if value.isdigit() or (value[0] == "-" and value[1:].isdigit()):
        registers[register] -= int(value)
    else:
        registers[register] -= registers[value]


def mul(register: str, value: str):
    if value.isdigit() or (value[0] == "-" and value[1:].isdigit()):
        registers[register] *= int(value)
    else:
        registers[register] *= registers[value]


for instruction in instructions:
    instruction_split = instruction.split(" ")
    instruction_split_split = instruction_split[1].split(",")
    if instruction_split[0] == "LOAD":
        load(instruction_split_split[0], instruction_split_split[1])
    elif instruction_split[0] == "ADD":
        add(instruction_split_split[0], instruction_split_split[1])
    elif instruction_split[0] == "SUB":
        sub(instruction_split_split[0], instruction_split_split[1])
    elif instruction_split[0] == "MUL":
        mul(instruction_split_split[0], instruction_split_split[1])

highest_value = ["A", 0]
for register, register_value in registers.items():
    if register_value > highest_value[1]:
        highest_value[1] = register_value
        highest_value[0] = register
print(f"{highest_value[0]} {highest_value[1]}")
