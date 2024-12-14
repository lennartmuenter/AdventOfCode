var input = File.ReadAllText("../../../../Day09/Day09.txt");
var part1 = new List<int>();
var part2 = new List<(int, int)>();
var id1 = 0;
var id2 = 0;
for (var i = 0; i < input.Length; i++)
{
    var val = int.Parse(input[i].ToString());
    if (val > 0) part2.Add((val, i % 2 == 0 ? id2++ : -1));
    if (i % 2 == 0)
    {
        for(var j = 0; j < val; j++)
        {
            part1.Add(id1);
        }
        id1++;
    }
    else
    {
        for (var j = 0; j < val; j++)
        {
            part1.Add(-1);
        }
    }
}

while (part1.Contains(-1))
{
    part1[part1.IndexOf(-1)] = part1[^1];
    part1.RemoveAt(part1.Count - 1);
}

var searchIndex = part2.Count - 1;
while (searchIndex >= 0)
{
    for (var i = 0; i < searchIndex; i++)
    {
        if (part2[i].Item2 != -1) continue;
        if (part2[searchIndex].Item2 == -1) break;

        if (part2[i].Item1 == 0)
        {
            part2.RemoveAt(i);
            searchIndex--;
            continue;
        }

        if (part2[i].Item1 - part2[searchIndex].Item1 < 0) continue;
        part2[i] = (part2[i].Item1 - part2[searchIndex].Item1, part2[i].Item2);
        var tmp = part2[searchIndex];
        part2[searchIndex] = (part2[searchIndex].Item1, -1);
        part2.Insert(i, tmp);
        searchIndex++;
        break;
    }

    searchIndex--;
}

var sumPart1 = 0L;
for (var i = 0; i < part1.Count; i++)
{
    sumPart1 += i * part1[i];
}

var sumPart2 = 0L;
var index = 0;
for (var i = 0; i < part2.Count; i++)
{
    if (part2[i].Item2 == -1)
    {
        index += part2[i].Item1;
        continue;
    }

    for (var j = 0; j < part2[i].Item1; j++)
    {
        sumPart2 += index * part2[i].Item2;
        index++;
    }
}

Console.WriteLine(sumPart1);
Console.WriteLine(sumPart2);