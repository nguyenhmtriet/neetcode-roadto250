// See https://aka.ms/new-console-template for more information

using System.Text;

var input = new[] { "neet", "code", "love", "you" };

input = new[] { "" };

input = new string[] { };

input = new[] { "The quick brown fox", "jumps over the", "lazy dog", "1234567890", "abcdefghijklmnopqrstuvwxyz" };

// input = new[] { "we", "say", ":", "yes", "!@#$%^&*()" };

var encoded = Encode(input);
var decoded = Decode(encoded);

Console.WriteLine($"Input: [{string.Join(", ", input)}]");
Console.WriteLine($"Encode - Output = {encoded}");
Console.WriteLine($"Decode - Output = [{string.Join(", ", decoded)}]");
return;

string Encode(IList<string> strs)
{
    if (strs.Count == 0) return null;

    var builder = new StringBuilder();

    foreach (var str in strs)
    {
        builder.Append($"{str.Length}#{str}");
    }
    
    return builder.ToString();
}

List<string> Decode(string s)
{
    if (s == null) return new List<string>();;

    if (string.IsNullOrWhiteSpace(s))
    {
        return new List<string> { s };
    }

    var result = new List<string>();
    var span = s.AsSpan();
    for (var index = 0; index < s.Length;)
    {
        var c = s[index];
        var beginPowerIndex = index;
        while (char.IsDigit(c) && c != '#')
        {
            c = s[++beginPowerIndex];
        }

        var lengthCharacterNumber = beginPowerIndex - index;
        var lengthStrValue = int.Parse(span.Slice(index, lengthCharacterNumber));
        var str = span.Slice(beginPowerIndex + 1, lengthStrValue);
        result.Add(str.ToString());
        index++;
        index += lengthStrValue + lengthCharacterNumber; 
    }

    return result;
}