import re

words = open("2015/Input.txt").readlines()
part1 = 0
part2 = 0
for line in words:
    if(len(re.findall("[a,e,i,o,u]", line)) >= 3 and len(re.findall("(\\w)\\1", line)) >= 1 and len(re.findall("(ab)|(cd)|(pq)|(xy)", line)) == 0): part1 += 1
    if(len(re.findall("(\\w\\w).*\\1", line)) >= 1 and len(re.findall("(\\w).\\1", line)) >= 1): part2 += 1
print(part1, part2)