# Connect 4

Description: We are setting out to develop a desktop application called as "Connect 4" which will enable two users to engage in this classic game. This application will be crafted using C# to provide a dynamic and interactive gaming experience. Tailored for 2-player gameplay where they engage in a battle of wits to achieve a line of four of their symbols in a row, column, or diagonal on the game board. This application will boast a suite of features designed to deliver a seamless and enjoyable gaming session.

The main class and the functionality of this program is as follows:

ConnectFour class: This is the main class which represents the logic of the game. It initializes the game board, manages player details, handles player turns, checks for win conditions, and manages the game loop.
Initialization: The game board is declared as a 6*7 grid with 6 rows and 7 columns using a two-dimensional character array. Both the Players provide their names, and the first letter of their names is used as their unique symbols on the board. If the first letter of both the players are same then ensure the second player gets a unique symbol.
Game Loop (PlayGame()): The game will be played alternatively between 2 players. Players choose a column to drop their symbol into. Check for win conditions and a full board to determine the end of the game.
Win Condition Checking (CheckWin()): Win conditions can be checked by verifying four consecutive symbols in horizontal, vertical, and diagonal directions.
Console Output (PrintBoard()): Prints the game board with colored symbols for each player. Displays messages about the player's turns and the status of the game.
User Interface (Main()): Provides a simple text-based menu for starting the game or quitting the application. Handles user input to initiate the game or exit from the game.
Installation Guidelines: To run the Connect 4 game, we need to follow the below installation process:

Installing Visual Studio: We have to first download and install Visual Studio if we have not installed the software already.
Create new project: To create a new project, open the Visual Studio and click on the "Create a New Project" console. Then, Choose C# as the programming language.
Build the code for Connect 4 game: Plan and write a code for Connect 4 game.
Execute and test the code: Build the project to ensure there are no errors. Next, Run the application and we should see the initial greeting and options to start the game or quit the game.
Play the game: Follow the prompts to start the game or quit. During the game, enter column numbers (1-7) to drop the player's symbol into a column.
