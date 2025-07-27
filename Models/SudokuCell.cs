// --- File: Models/SudokuCell.cs ---
// Represents a single cell on the Sudoku board.
// Note: In C#, properties are used instead of simple variables.
// INotifyPropertyChanged would be used for more complex data binding scenarios.
namespace CyberSudoku.MAUI.Models;

public class SudokuCell
{
    public int? Value { get; set; }
    public HashSet<int> Notes { get; set; } = new HashSet<int>();
    public bool IsGiven { get; set; }
    public bool IsHighlighted { get; set; }
    public bool IsIncorrect { get; set; }
}

// --- File: Models/Difficulty.cs ---
// Defines the difficulty levels of the puzzles.
namespace CyberSudoku.MAUI.Models;

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Expert
}
