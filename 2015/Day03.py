def mapping(value):
    if value == "^": return (-1, 0)
    elif value == ">": return (0, 1)
    elif value == "v": return (1, 0)
    elif value == "<": return (0, -1)
    
instructions = open("2015/Input.txt").read()

point = (0,0)
instructions.split()
instructions = list(mapping(value) for value in instructions)
part1 = set()

part2santa = set()
santa = (0,0)
part2robo = set()
robo = (0,0)

for index in range(0, len(instructions)):
    part1.add(point)
    point = (point[0] + instructions[index][0], point[1] + instructions[index][1])
    if index % 2 == 0:
        part2santa.add(santa)
        santa = (santa[0] + instructions[index][0], santa[1] + instructions[index][1])
    else:
        part2robo.add(robo)
        robo = (robo[0] + instructions[index][0], robo[1] + instructions[index][1])
    
print(len(part1))
print(len(part2santa | part2robo))