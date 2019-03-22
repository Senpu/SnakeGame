using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class defines most of game's logic
namespace SnakeGame
{
    class Snake
    {
        public static int coordinateX = 21;
        public static int coordinateY = 11;
        decimal gameSpeed = 150m;

        bool isBorderHit = false;

        Food Food = new Food();

        // This method prints a character in a middle of a field when the game starts.
        public void DrawSnake()
        {
            Console.SetCursorPosition(coordinateX, coordinateY);
            Console.Write('o');
        }
       
        // This method defines general game loop and control handling.
        public void Game()
        {
            ConsoleKey moveKey = Console.ReadKey().Key;
            do
            {      
                // With switch statement we use arrows to control the character
                switch (moveKey)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        Console.Write(" ");
                        coordinateY--;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        Console.Write(" ");
                        coordinateY++;
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        Console.Write(" ");
                        coordinateX--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(coordinateX, coordinateY);
                        Console.Write(" ");
                        coordinateX++;
                        break;
                }

                DrawSnake();
               
                isBorderHit = BorderHit(coordinateX, coordinateY);

                // And if yes, this statement stops the game with a message.
                if (isBorderHit)
                {
                    Program.isGameRunning = false;
                    Console.SetCursorPosition(15, 9);
                    Console.WriteLine("Game Over!");
                    Console.SetCursorPosition(13, 10);
                    Console.WriteLine($"Your score is: {Food.score}");
                }     

                // This method setting the food on the field.
                Food.FoodSetter();

                // This statement allows developer to control the game speed.
                if (Console.KeyAvailable) moveKey = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (Program.isGameRunning);


        }

        // This method tracks if border was hit.
        private bool BorderHit(int x, int y)
        {
            if (x == 0 || x == 43 || y == 0 || y == 23) return true; return false;
        }

    }
}
