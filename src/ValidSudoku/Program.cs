// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var input = new[]
{
    new[] { '1', '2', '.', '.', '3', '.', '.', '.', '.' },
    new[] { '4', '.', '.', '5', '.', '.', '.', '.', '.' },
    new[] { '.', '9', '8', '.', '.', '.', '.', '.', '3' },
    new[] { '5', '.', '.', '.', '6', '.', '.', '.', '4' },
    new[] { '.', '.', '.', '8', '.', '3', '.', '.', '5' },
    new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    new[] { '.', '.', '.', '.', '.', '.', '2', '.', '.' },
    new[] { '.', '.', '.', '4', '1', '9', '.', '.', '8' },
    new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' },
};

input = new[]
{
    new[] { '1', '2', '.', '.', '3', '.', '.', '.', '.' },
    new[] { '4', '.', '.', '5', '.', '.', '.', '.', '.' },
    new[] { '.', '9', '5', '.', '.', '.', '.', '.', '3' },
    new[] { '5', '.', '.', '.', '6', '.', '.', '.', '4' },
    new[] { '.', '.', '.', '8', '.', '3', '.', '.', '5' },
    new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    new[] { '.', '.', '.', '.', '.', '.', '2', '.', '.' },
    new[] { '.', '.', '.', '4', '1', '9', '.', '.', '8' },
    new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};

input = new[]
{
    new[] { '1', '2', '.', '.', '3', '.', '.', '.', '.' },
    new[] { '4', '.', '.', '5', '.', '.', '.', '.', '.' },
    new[] { '.', '9', '7', '.', '.', '.', '9', '.', '3' },
    new[] { '5', '.', '.', '.', '6', '.', '.', '.', '4' },
    new[] { '.', '.', '.', '8', '.', '3', '.', '.', '5' },
    new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    new[] { '.', '.', '.', '.', '.', '.', '2', '.', '.' },
    new[] { '.', '.', '.', '4', '1', '9', '.', '.', '8' },
    new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};


var output = IsValidSudoku(input);

Console.WriteLine($"Output = {output}");

return;

bool IsValidSudoku(char[][] board)
{
    const int BoxRow = 3;
    const int BoxColumn = 3;
    const int Length = BoxRow * BoxRow;
    const int RowLen = BoxRow * BoxRow;
    const int ColLen = BoxRow * BoxRow;
    var subBoxes = Enumerable.Range(0, Length).Select(_ => new SubBox()).ToArray();
    var hashSetRow = new HashSet<char>();
    var dictHashSetCol = Enumerable.Range(0, Length).ToDictionary(i => i, _ => new HashSet<char>());
    for (int rowIdx = 0; rowIdx < RowLen; rowIdx++)
    {
        for (int colIdx = 0; colIdx < ColLen; colIdx++)
        {
            var number = board[rowIdx][colIdx];
            if (number == '.') continue;
            
            var isNotExistedInCol = dictHashSetCol[colIdx].Add(number);
            if (!isNotExistedInCol) return false;

            var isNotExistedInRow = hashSetRow.Add(number);
            if (!isNotExistedInRow) return false;
            
            var indexBoard = rowIdx * ColLen + colIdx;
            // var boxIndex = indexBoard / BoxRow % BoxColumn;
            var boxIndex = colIdx / BoxColumn + (rowIdx / BoxRow * BoxRow);
            var subBox = subBoxes[boxIndex];
            
            // var subBoxIndex = (indexBoard % RowLen % BoxRow) + rowIdx * BoxRow;
            var subBoxIndex = (indexBoard % ColLen % BoxColumn) + (rowIdx % RowLen % BoxRow) * BoxRow;
            var isNotExistedInSubBox = subBox.AddIndex(number, subBoxIndex);
            if (!isNotExistedInSubBox) return false;
        }
        
        hashSetRow.Clear();
    }
    
    return true;
}

[DebuggerDisplay("{DebuggerDisplay, nq}")]
readonly struct SubBox
{
    private const int FixedRow = 3;
    private const int FixedColumn = 3;
    private readonly HashSet<char> _numbersHashSet;
    private readonly char[] _numbersArray;

    private string DebuggerDisplay
    {
        get
        {
            var numbers = _numbersArray.ToArray();

            return string.Format("{0} | {1} | {2}",
                string.Join(", ", Enumerable.Range(0, FixedColumn).Select(col => numbers[col])),
                string.Join(", ", Enumerable.Range(0, FixedColumn).Select(col => numbers[FixedRow * 1 + col])),
                string.Join(", ", Enumerable.Range(0, FixedColumn).Select(col => numbers[FixedRow * 2 + col])));
        }
    }

    public SubBox()
    {
        _numbersHashSet = new HashSet<char>();
        _numbersArray = new char[FixedRow * FixedColumn];
    }

    public bool AddIndex(char number, int index)
    {
        var row = index / FixedRow;
        var column = index % FixedColumn;
        _numbersArray[column + row * FixedRow] = number;
        return _numbersHashSet.Add(number);
    }
}