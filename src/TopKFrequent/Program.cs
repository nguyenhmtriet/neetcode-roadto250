// See https://aka.ms/new-console-template for more information

var input = new[] { 1, 2, 2, 3, 3, 3 };
var kInput = 2;

// input = new[] { 7, 7 };
// kInput = 1;

// input = new[] { 1, 2 };
// kInput = 2;

// input = new[] { 1, 1, 1, 2, 2, 3 };
// kInput = 2;

var output = TopKFrequent(input, kInput);

Console.WriteLine($"TopKFrequent Output = [{string.Join(", ", output)}]");

return;

int[] TopKFrequent(int[] nums, int k)
{
    var dict = new Dictionary<int, int>();
    var largestFrequency = 0;
    var result = new List<int>();
    for (var i = 0; i < nums.Length; i++)
    {
        var number = nums[i];
        if (!dict.TryAdd(number, 1))
        {
            dict[number]++;
        }
    }

    var sorted = dict.ToList();
    sorted.Sort(new Comparer());
    return sorted.Take(k).Select(kp => kp.Key).ToArray();
}

class Comparer : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        if (x.Value == y.Value) return 0;
        
        return x.Value < y.Value ? 1 : -1;
    }
}