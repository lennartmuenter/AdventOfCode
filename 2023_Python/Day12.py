from functools import cache

@cache
def getPossibilities(input, numbers, result = 0):
    if not numbers:
        return '#' not in input
    current, numbers = numbers[0], numbers[1:]
    for index in range(len(input) - sum(numbers) - len(numbers) - current + 1):
        if '#' in input[:index]:
            break
        if (next := index + current) <= len(input) and '.' not in input[index : next] and input[next : next + 1] != '#':
            result += getPossibilities(input[next + 1:], numbers)
    return result

lines = list(map(str.split, open('12.txt').read().splitlines()))

count = {
    1: 0,
    2: 0
}
for e, (input, numbers) in enumerate(lines):
    numbers = tuple(map(int, numbers.split(',')))
    count[1] += getPossibilities(input, numbers)
    count[2] += getPossibilities('?'.join([input] * 5), numbers * 5)
    
print(count)