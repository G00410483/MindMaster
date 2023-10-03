# MindMaster
Color matching puzzle game


This C# code, developed using Microsoft.Maui.Controls, is an interactive mobile app for playing a color-matching puzzle game. Players are presented with a challenge to match a hidden color pattern by selecting colors on a grid. Below are instructions on how to use and customize this app:

Usage:

Prerequisites:

Ensure you have the Microsoft.Maui.Controls framework and required dependencies set up for your development environment.
Running the App:

Build and run the app using a compatible development environment or emulator/simulator.
Game Rules:

The game consists of two grids: GameGrid and GameGrid2. GameGrid contains the player's color selections, while GameGrid2 displays feedback on the correctness of color placements.
The player's goal is to match a hidden color pattern represented by rBV (random BoxView array).
Six color buttons (Btn1 to Btn6) are available for the player to choose colors from: Red, Yellow, Green, Blue, Purple, and Orange.
Game Flow:

Start the game by clicking the "Play" button (StartBtn).
The game grids and color buttons will become visible.
Select colors by clicking the color buttons in BtnStack. Place them on GameGrid.
After each color selection, the app provides feedback on correctness:
A red cell in GameGrid2 indicates the correct color in the correct position.
A white cell in GameGrid2 indicates the correct color but in the wrong position.
Continue selecting colors and receiving feedback until you either win or run out of guesses.
The game ends when you correctly match the pattern or exhaust all guesses.
Game End:

If you successfully match the pattern, a victory message will be displayed.
If you run out of guesses without matching the pattern, you'll receive a defeat message.
Resetting the Game:

Click the "Reset" button (ResetBtn) to start a new game. This clears the grids and generates a new random pattern.
Customization:

To customize this app or adapt it for different color patterns, you can modify the color options in the SetUpRandom method and adjust the number of guesses (currently set to 40) as needed.
You can also customize the UI elements, such as buttons and grid layouts, to match your app's design.
Notes:

This app is provided as a simplified example of a color-matching puzzle game.
Feel free to enhance and extend the code to add more features or complexity to the game.
This code is intended for educational purposes and serves as a starting point for creating similar mobile games using the Microsoft.Maui.Controls framework.
