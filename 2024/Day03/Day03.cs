using System.Text.RegularExpressions;

var countPart1 = 0;
var countPart2 = 0;
var input = File.ReadAllText("../../../../Day03/Day03.txt").Replace("\n", "");
var matches = Regex.Matches(input, @"(do[(][)]|don't[(][)]|mul[(]([0-9]+),([0-9]+)[)])");
var current = "do()";
foreach (Match match in matches)
{
    if (match.Groups[1].Value.StartsWith('d'))
    {
        current = match.Groups[1].Value;
        continue;
    }

    var number = int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
    countPart1 += number;
    if (current == "do()") countPart2 += number;
}

Console.WriteLine(countPart1);
Console.WriteLine(countPart2);