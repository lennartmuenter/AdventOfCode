var countPart1 = 0;
var countPart2 = 0;
File.ReadLines("../../../../Day02/Day02.txt").ToList().ForEach(line =>
{
    var numbers = line.Split(" ").Select(int.Parse).ToList();
    if (numbers.First() > numbers.Last()) numbers.Reverse();

    if (CheckRow(numbers) > 0)
    {
        countPart1++;
        countPart2++;
        return;
    }

    for (var index = 0; index < numbers.Count; index++)
    {
        var tmp = numbers.ToList();
        tmp.RemoveAt(index);

        if (CheckRow(tmp) <= 0) continue;
        countPart2++;
        return;
    }
});
Console.WriteLine(countPart1);
Console.WriteLine(countPart2);
return;

int CheckRow(List<int> numbers)
{
    for (var index = 0; index < numbers.Count - 1; index++)
    {
        if (numbers[index] >= numbers[index + 1] || numbers[index] + 3 < numbers[index + 1])
        {
            return 0;
        }
    }

    return 1;
}
