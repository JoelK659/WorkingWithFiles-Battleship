# Battleship Game (C#)

## Overview
This project is a console-based implementation of the classic **Battleship** game written in C#. The game allows the player to place guesses on the ship placements of a pre-generated board, with a limited number of guesses.

## Features
- One-player Battleship gameplay
- Hit and miss tracking
- Game state saved and loaded using files

## Technologies Used
- C#
- .NET Console Application
- File I/O (reading and writing text files)

## How It Works
The program stores game information in external files to maintain persistence. These files may include:
- Ship locations
- Attack history
- Saved game state

When the game starts, it reads existing data from files if available. During gameplay, updates are written back to files to save progress.

## Running the Program
1. Clone or download the repository.
2. Open the project in Visual Studio or another C# IDE.
3. Build the solution.
4. Run the console application.
5. Open YourBoard.txt in the file path: `WorkingWithFiles-Battleship\bin\Debug\net8.0-windows`

## Future Improvements
- Computer AI opponent
- Improved input validation
- Randomized Ship Placements
- Two-Player Capabilities
- Enhanced save/load system

## Note
Created as a C# programming project demonstrating object-oriented design and file handling.
