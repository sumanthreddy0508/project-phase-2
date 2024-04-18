using System;

public class ConnectFour
{
    // Constants for board dimensions.
    private const int Rows = 6;// Number of rows in the Connect Four board
    private const int Columns = 7;// Number of columns in the Connect Four board
    // The game board, represented as a two-dimensional array of characters.
    private char[,] board = new char[Rows, Columns];
    // Player information: names, symbols for the board, and colors for console output
    private string player1;
    private string player2;
    private string currentPlayer;
    private char player1Symbol;  // Symbols will be determined based on player names
    private char player2Symbol;
    private ConsoleColor player1Color = ConsoleColor.Red;// Console color for player 1's symbol
    private ConsoleColor player2Color = ConsoleColor.Blue; // Console color for player 2's symbol
    private char currentSymbol;// Symbol of the current player
    private ConsoleColor currentColor;// Console color of the current player.
    // Constructor that initializes a new game by clearing the board.
    public ConnectFour()
    {
        ClearBoard();
    }
    // Method to reset the board to its initial empty state.
    private void ClearBoard()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                board[i, j] = '.';// '.' represents an empty slot on the board.
            }
        }
    }
    // Initialize player details: get names and assign unique symbols and initial colors
    public void InitializePlayers()
    {
        Console.WriteLine("Enter Player 1's name: \n");
        player1 = Console.ReadLine();
        player1Symbol = Char.ToUpper(player1[0]);// Use the first letter of player 1's name as their symbol

        Console.WriteLine("\nEnter Player 2's name: \n");
        player2 = Console.ReadLine();

        // Ensure unique symbols
        player2Symbol = GetUniqueSymbol(player2, player1Symbol);// Ensure player 2 has a unique symbol.
        // Set the starting player.
        currentPlayer = player1;
        currentSymbol = player1Symbol;
        currentColor = player1Color;
        Console.WriteLine();  // Ensures the game starts on a new line.
    }
    // Ensures that player 2 gets a unique symbol if their name starts with the same letter as player 1
    private char GetUniqueSymbol(string name, char otherSymbol)
    {
        char symbol = Char.ToUpper(name[0]);
        if (symbol == otherSymbol)
        {
            int i = 1;  // Start checking from the second character
            while (i < name.Length && Char.ToUpper(name[i]) == otherSymbol)
            {
                i++;
            }
            return i < name.Length ? Char.ToUpper(name[i]) : 'X';  // Default if no unique character found
        }
        return symbol;
    }
    // Main game loop: manage turns, handle user input, and check for game end conditions
    public void PlayGame()
    {
        InitializePlayers();
        bool gameRunning = true;
        while (gameRunning)
        {
            PrintBoard();
            Console.WriteLine($"{currentPlayer}'s turn ({currentSymbol}). Enter column (1-7) or '0' to restart: \n");
            int column;
            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.WriteLine("\nRestarting game...\n");
                ClearBoard();  // Clear the board
                InitializePlayers();  // Reinitialize players
                continue;
            }
            else if (int.TryParse(input, out column) && column >= 1 && column <= Columns)
            {
                if (PlaceDisc(column - 1))  // Adjust index for 0-based array
                {
                    if (CheckWin(currentSymbol))
                    {
                        PrintBoard();
                        Console.WriteLine($"{currentPlayer} ({currentSymbol}) wins!\n");
                        gameRunning = false;
                    }
                    else if (IsBoardFull())
                    {
                        PrintBoard();
                        Console.WriteLine("\nThe game is a draw!\n");
                        gameRunning = false;
                    }
                    SwitchPlayer();
                }
                else
                {
                    Console.WriteLine("\nInvalid move. Column is full. Try again.\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 7.\n");
            }
        }
    }
    // Display the game board with player colors.
    private void PrintBoard()
    {
        Console.WriteLine();  // Ensures the board is printed on a new line.
        // Print column numbers from 1 to 7
        Console.Write("  ");
        for (int j = 1; j <= Columns; j++)// Print column headers (1 to 7)
        {
            Console.Write(j + " ");
        }
        Console.WriteLine("\n");

        // Print the board with colors
        for (int i = 0; i < Rows; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < Columns; j++)
            {
                if (board[i, j] == player1Symbol)
                {
                    Console.ForegroundColor = player1Color;// Set color for player 1's symbols.
                }
                else if (board[i, j] == player2Symbol)
                {
                    Console.ForegroundColor = player2Color;// Set color for player 2's symbols.
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(board[i, j] + " ");
                Console.ResetColor();// Reset to default color for empty slots
            }
            Console.WriteLine("|");
        }
        Console.WriteLine();
    }
    // Attempt to place a disc in the chosen column. Return true if successful
    private bool PlaceDisc(int column)
    {
        for (int i = Rows - 1; i >= 0; i--)// Start from the bottom row and move up.
        {
            if (board[i, column] == '.') 
            {
                board[i, column] = currentSymbol;// Place the disc.
                return true;
            }
        }
        return false;// Return false if the column is full.
    }
    // Switch the current player and update related symbols and colors.
    private void SwitchPlayer()
    {
        if (currentPlayer == player1)
        {
            currentPlayer = player2;
            currentSymbol = player2Symbol;
            currentColor = player2Color;
        }
        else
        {
            currentPlayer = player1;
            currentSymbol = player1Symbol;
            currentColor = player1Color;
        }
        Console.WriteLine();  // Ensures the switch message starts on a new line.
    }
    // Check for a win condition across horizontal, vertical, or diagonal lines
    private bool CheckWin(char playerSymbol)
    {
        // Horizontal checks
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns - 3; j++)
            {
                if (board[i, j] == playerSymbol && board[i, j + 1] == playerSymbol &&
                    board[i, j + 2] == playerSymbol && board[i, j + 3] == playerSymbol)
                {
                    return true;
                }
            }
        }

        // Vertical checks
        for (int i = 0; i < Rows - 3; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (board[i, j] == playerSymbol && board[i + 1, j] == playerSymbol &&
                    board[i + 2, j] == playerSymbol && board[i + 3, j] == playerSymbol)
                {
                    return true;
                }
            }
        }

        // Diagonal checks
        // Ascending diagonal check
        for (int i = 3; i < Rows; i++)
        {
            for (int j = 0; j < Columns - 3; j++)
            {
                if (board[i, j] == playerSymbol && board[i - 1, j + 1] == playerSymbol &&
                    board[i - 2, j + 2] == playerSymbol && board[i - 3, j + 3] == playerSymbol)
                {
                    return true;
                }
            }
        }

        // Descending diagonal check
        for (int i = 3; i < Rows; i++)
        {
            for (int j = 3; j < Columns; j++)
            {
                if (board[i, j] == playerSymbol && board[i - 1, j - 1] == playerSymbol &&
                    board[i - 2, j - 2] == playerSymbol && board[i - 3, j - 3] == playerSymbol)
                {
                    return true;
                }
            }
        }

        return false;
    }


    private bool IsBoardFull()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (board[i, j] == '.')// Check if any slot is still empty
                {
                    return false;
                }
            }
        }
        return true;// Return true if all slots are filled.
    }
}

class Program
{
    static void Main()
    {
        // Initial greeting and options for the player
        Console.WriteLine("Welcome to Connect Four.\n");
        Console.WriteLine("Press 1 to Start the game.\n");
        Console.WriteLine("Press 2 to Quit the application.\n");
        Console.WriteLine("Enter your choice :  \n");
        string input = Console.ReadLine();// Get user input and handle game start or application exit.
        Console.WriteLine();  // Ensure that the game starts or ends on a new line after input.
        

        switch (input)
        {
            case "1":
                ConnectFour game = new ConnectFour();
                game.PlayGame();// Start playing the game.
                break;
            case "2":
                Console.WriteLine("Thank you for playing.\n");
                return; // Exit the application.
            default:
                Console.WriteLine("Invalid option, please restart the application and select a valid option.\n");
                break;
        }
    }
}