// See https://aka.ms/new-console-template for more information

var input = new[] { 1, 2, 4, 6 };
input = new[] { -1, 0, 1, 2, 3 };

var output = ProductExceptSelf(input);

Console.WriteLine($"Input: [{string.Join(", ", input)}]");
Console.WriteLine($"Output = [{string.Join(", ", output)}]");

return;

int[] ProductExceptSelf(int[] nums)
{
    var result = new List<int>(nums.Length);
    for (int i = 0; i < nums.Length; i++)
    {
        var j = 0;
        result.Add(1);
        while (j < nums.Length)
        {
            if (i == j)
            {
                j++;
                continue;
            }

            result[i] *= nums[j++];
        }
    }

    return result.ToArray();
}