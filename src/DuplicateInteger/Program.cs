// See https://aka.ms/new-console-template for more information

bool HasDuplicate(int[] nums) {
    var length = nums.Length;
    if (length <= 1) return false;

    var head = 0;
    while (head <= length - 2) {
        var cur = head + 1;

        while (cur <= length - 1) {
            if (nums[head] == nums[cur]) {
                return true;
            }

            cur++;
        }
            
        head++;
    }

    return false;
}

int[] nums = [1, 2, 3, 3];
Console.WriteLine(HasDuplicate(nums) ? "The array has duplicates." : "The array does not have duplicates.");











