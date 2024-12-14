var left = new List<int>();
var right = new List<int>();
var count = 0;
File.ReadLines("../../../../Day01/Day01.txt").ToList().ForEach(x => x.Split("   ").ToList().ForEach(x =>
{
    if (count % 2 == 0)
    {
        left.Add(int.Parse(x));
    }
    else
    {
        right.Add(int.Parse(x));
    }

    count++;
}));

left.Sort();
right.Sort();

var occurances = new Dictionary<int, int>();
foreach (var x in right.GroupBy(x => x))
{
    occurances[x.Key] = x.Count();
}

var sol1 = 0;
var sol2 = 0;
for (var i = 0; i < left.Count; i++)
{
    sol1 += Math.Abs(left[i] - right[i]);
    if (occurances.ContainsKey(left[i]))
    {
        sol2 += occurances[left[i]] * left[i];
    }
}

Console.WriteLine(sol1);
Console.WriteLine(sol2);