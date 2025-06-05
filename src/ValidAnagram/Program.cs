// See https://aka.ms/new-console-template for more information

var isAnagram = IsAnagram("racecar", "carrace");
// var isAnagram = IsAnagram("ab", "ba");

Console.WriteLine(isAnagram ? "true" : "false");

return;

bool IsAnagram(string s, string t) {
    var head = 0;
    
    if (s.Length != t.Length) {
        return false;
    }

    var hash1 = new Dictionary<string, int>();
    foreach (var c in s) {
        var key = c.ToString();
        if (!hash1.TryAdd(key, 1)) {
            hash1[key]++;
        }
    }
    
    var hash2 = new Dictionary<string, int>();
    foreach (var c in t) {
        var key = c.ToString();
        if (!hash2.TryAdd(key, 1)) {
            hash2[key]++;
        }
    }
    
    foreach (var kvp in hash1) {
        if (!hash2.TryGetValue(kvp.Key, out var count) || count != kvp.Value) {
            return false;
        }
    }

    return true;
}