part1 = [[0 for _ in range(1000)] for _ in range(1000)]
part2 = [[0 for _ in range(1000)] for _ in range(1000)]

instructions = open("2015/Input.txt").readlines()
for instruction in instructions:
    instruction = instruction.replace("turn ", "").replace("through ", "").strip().split(" ")
    start = list(map(int, instruction[1].split(",")))
    end = list(map(int, instruction[2].split(",")))
    for row in range(start[0], end[0] + 1):
        for col in range(start[1], end[1] + 1):
            match instruction[0]:
                case "on": 
                    part1[row][col] = 1
                    part2[row][col] += 1
                case "off":
                    part1[row][col] = 0
                    part2[row][col] -= 1 if part2[row][col] >= 1 else 0
                case "toggle": 
                    part1[row][col] = 1 if part1[row][col] == 0 else 0
                    part2[row][col] += 2

print(sum(sum(part1,[])), sum(sum(part2,[])))