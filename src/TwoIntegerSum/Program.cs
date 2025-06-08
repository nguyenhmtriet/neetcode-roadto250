// See https://aka.ms/new-console-template for more information

var nums1 = new int[] { 3, 4, 5, 6 };
var nums2 = new int[] { 4, 5, 6 };
var target = 10;
var result = TwoSum(nums2, 10);
Console.WriteLine("TwoSum output = [{0}]", string.Join(", ", result));

return;

int[] TwoSum(int[] nums, int target)
{
    if (nums.Length < 2)
    {
        return Array.Empty<int>();
    }

    if (nums.Length == 2)
    {
        return new[] { 0, 1 };
    }

    int i;
    var j = 0;
    for (i = 0; i < nums.Length - 1; i++)
    {
        var addend1 = nums[i];
        for (j = i + 1; j < nums.Length; j++)
        {
            var append2 = nums[j];
            if (append2 + addend1 == target)
            {
                return new[] { i, j };
            }
        }
    }
    return new[] { i, j };
}