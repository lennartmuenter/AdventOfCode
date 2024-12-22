instructions = open("2015/Input.txt").readlines()
circut = dict()

last = None

instructions = [i.strip().split(" ") for i in instructions]
while len(instructions) != 0:
    for instruction in instructions:
        if instruction[0].isnumeric() and instruction[1] == "AND" and instruction[2] in circut:
            circut[instruction[4]] = int(instruction[0]) & circut[instruction[2]]
            instructions.remove(instruction)
            last = instruction
        elif instruction[0].isnumeric(): 
            circut[instruction[2]] = int(instruction[0])
            instructions.remove(instruction)
            last = instruction
        elif instruction[0] == "NOT" and instruction[1] in circut:
            circut[instruction[3]] = 0b1111111111111111 - circut[instruction[1]]
            instructions.remove(instruction)
            last = instruction
        elif instruction[1] == "AND" and instruction[0] in circut and instruction[2] in circut:
            circut[instruction[4]] = circut[instruction[0]] & circut[instruction[2]]
            instructions.remove(instruction)
            last = instruction
        elif instruction[1] == "OR" and instruction[0] in circut and instruction[2] in circut:
            circut[instruction[4]] = circut[instruction[0]] | circut[instruction[2]]
            instructions.remove(instruction)
            last = instruction
        elif instruction[1] == "LSHIFT" and instruction[0] in circut:
            circut[instruction[4]] = circut[instruction[0]] << int(instruction[2])
            instructions.remove(instruction)
            last = instruction
        elif instruction[1] == "RSHIFT" and instruction[0] in circut:
            circut[instruction[4]] = circut[instruction[0]] >> int(instruction[2])
            instructions.remove(instruction)
            last = instruction
    if(last == ['o', 'AND', 'q', '->', 'r']):exit()
  
            
    print(circut)