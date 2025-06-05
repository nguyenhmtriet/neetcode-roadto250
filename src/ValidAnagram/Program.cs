// See https://aka.ms/new-console-template for more information

bool IsAnagram(string s, string t) {
    var head = 0;
    
    if (s.Length != t.Length) {
        return false;
    }

    var group = new List<string>(s.Length);
    var length = s.Length;
    var count = 0;

    while (head <= length - 1) {
        var cur = 0;
        var origin = head;
 
        while (cur <= length - 1) {
            if (s[head] == t[cur]) {
                cur++;
                head++;
                count++;
                continue;
            }

            if (count >= 3)
            {
                group.AddRange(s[origin..head].ToString());
            }

            head = origin;
            if (count == 0) cur++;
            count = 0;
        }
        
        if (count >= 3)
        {
            group.AddRange(s[origin..head].ToString());
            origin = 
        }
        
        head = origin;
        count = 0;
        head++;
    }

    return true;
}

var isAnagram = IsAnagram("racecar", "carrace");

Console.WriteLine(isAnagram ? "true" : "false");