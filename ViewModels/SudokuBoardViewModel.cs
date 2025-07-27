// --- File: ViewModels/SudokuBoardViewModel.cs ---
// Manages the state and logic for the Sudoku board.
// Implements INotifyPropertyChanged to update the UI automatically.
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CyberSudoku.MAUI.Models;
using CyberSudoku.MAUI.Services;

namespace CyberSudoku.MAUI.ViewModels;

public class SudokuBoardViewModel : INotifyPropertyChanged
{
    // Backing fields for properties
    private SudokuCell[][] _grid;
    private bool _isGenerating;

    public SudokuCell[][] Grid
    {
        get => _grid;
        set { _grid = value; OnPropertyChanged(); }
    }
    
    public bool IsGenerating
    {
        get => _isGenerating;
        set { _isGenerating = value; OnPropertyChanged(); }
    }

    public ICommand NewGameCommand { get; }
    
    private readonly SudokuGenerator _generator = new SudokuGenerator();

    public SudokuBoardViewModel()
    {
        NewGameCommand = new Command<Difficulty>(StartNewGame);
        StartNewGame(Difficulty.Easy);
    }

    public void StartNewGame(Difficulty difficulty)
    {
        IsGenerating = true;
        Task.Run(() =>
        {
            var newPuzzle = _generator.Generate(difficulty);
            var newGrid = new SudokuCell[9][];
            for (int r = 0; r < 9; r++)
            {
                newGrid[r] = new SudokuCell[9];
                for (int c = 0; c < 9; c++)
                {
                    int value = newPuzzle[r, c];
                    newGrid[r][c] = new SudokuCell
                    {
                        Value = value == 0 ? null : value,
                        IsGiven = value != 0
                    };
                }
            }
            // Update UI on the main thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Grid = newGrid;
                IsGenerating = false;
            });
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

