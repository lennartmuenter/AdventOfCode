var sumPart1 = 0L;
var sumPart2 = 0L;
File.ReadLines("../../../../Day07/Day07.txt").ToList().ForEach(line =>
{
    var list = line.Split(": ").Select(l => l.Split(" ").Select(long.Parse).ToList()).ToList();
    if (Calc(list[0][0], list[1], 0, false)) sumPart1 += list[0][0];
    if (Calc(list[0][0], list[1], 0, true)) sumPart2 += list[0][0];
});
Console.WriteLine(sumPart1);
Console.WriteLine(sumPart2);
return;

bool Calc(long result, List<long> numbers, long current, bool part2)
{
    if (numbers.Count == 0)
    {
        return current == result;
    }

    var newNumbers = numbers.ToList();
    newNumbers.RemoveAt(0);
    var concat = string.Concat(current, numbers[0]);

    return Calc(result, newNumbers, current + numbers[0], part2) ||
           Calc(result, newNumbers, current * numbers[0], part2) ||
           part2 && Calc(result, newNumbers, long.Parse(concat), part2);
}