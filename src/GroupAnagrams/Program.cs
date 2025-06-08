// See https://aka.ms/new-console-template for more information

var input1 = new[] { "act", "pots", "tops", "cat", "stop", "hat" };
var input2 = new[] { "hhhhu", "tttti", "tttit", "hhhuh", "hhuhh", "tittt" };
var input3 = new[] { "bdddddddddd", "bbbbbbbbbbc" };
var output = GroupAnagrams(input2);
Console.WriteLine("GroupAnagrams output = [{0}]",
    string.Join(", ", output.Select(x => "[" + string.Join(", ", x) + "]")));

return;

List<List<string>> GroupAnagrams(string[] strs)
{
    var groupedAnagrams = new List<List<Dictionary<char, int>>>();
    var result = new List<List<string>>();
    for (var i = 0; i < strs.Length; i++)
    {
        var hash = new Dictionary<char, int>();
        var str = strs[i];
        for (var c = 0; c < str.Length; c++)
        {
            if (!hash.TryAdd(str[c], 0))
            {
                hash[str[c]]++;
            }
        }

        if (groupedAnagrams.Count == 0)
        {
            groupedAnagrams.Add(new List<Dictionary<char, int>>(new[] { hash }));
            result.Add(new List<string>(new[] { str }));
            continue;
        }

        var found = false;
        for (var g = 0; g < groupedAnagrams.Count; g++)
        {
            var group = groupedAnagrams[g];
            var copiedGroup = group.ToList();
            foreach (var dict in copiedGroup)
            {
                if (dict.Count != hash.Count) continue;

                found = true;
                foreach (var keyPair in dict)
                {
                    if (!hash.TryGetValue(keyPair.Key, out var count) || keyPair.Value != count)
                    {
                        found = false;
                        continue;
                    }
                }
            }

            if (found)
            {
                group.Add(hash);
                result[g].Add(str);
                break;
            }
        }

        if (!found)
        {
            groupedAnagrams.Add(new List<Dictionary<char, int>>(new[] { hash }));
            result.Add(new List<string>(new[] { str }));
        }
    }

    return result;
}