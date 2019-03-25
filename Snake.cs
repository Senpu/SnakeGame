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
        public static int[] coordinateX = new int[50];
        public static int[] coordinateY = new int[50];       

        static Snake()
        {
            coordinateX[0] = 21;
            coordinateY[0] = 11;
        }
        
        // Using decimal in order to operate game's speed properly.

        public static decimal gameSpeed = 200m;

        bool isBorderHit = false;
        
        Food food = new Food();

        // This method prints a character in a middle of a field when the game starts.
        public void DrawSnakeOnce()
        {
            Console.SetCursorPosition(Snake.coordinateX[0], Snake.coordinateY[0]);
            Console.Write('\u0398');
        }

        
        public void DrawSnake(int foodEaten, int[] coordinateXIn, int[] coordinateYIn, out int[] coordinateXOut, out int[] coordinateYOut)
        {
            // Drawing the head of the snake.
            Console.SetCursorPosition(coordinateXIn[0], coordinateYIn[0]);
            Console.Write('\u0398');

            // Drawing the body of the snake. 
            for (int i = 1; i < foodEaten + 1; i++)
            {
                Console.SetCursorPosition(coordinateXIn[i], coordinateYIn[i]);
                Console.Write('o');
            }

            // Erasing the last part of the snake.
            Console.SetCursorPosition(coordinateXIn[foodEaten + 1], coordinateYIn[foodEaten + 1]);
            Console.Write(' ');

            // This loop is needed to move tail after the head properly.
            for (int i = foodEaten + 1; i > 0; i--)
            {
                coordinateXIn[i] = coordinateXIn[i - 1];
                coordinateYIn[i] = coordinateYIn[i - 1];
            }

            // Returning coordinates.
            coordinateXOut = coordinateXIn;
            coordinateYOut = coordinateYIn;
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
                        Console.SetCursorPosition(coordinateX[0], coordinateY[0]);
                        Console.Write(" ");
                        coordinateY[0]--;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(coordinateX[0], coordinateY[0]);
                        Console.Write(" ");
                        coordinateY[0]++;
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(coordinateX[0], coordinateY[0]);
                        Console.Write(" ");
                        coordinateX[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(coordinateX[0], coordinateY[0]);
                        Console.Write(" ");
                        coordinateX[0]++;
                        break;
                }

                DrawSnake(food.score, coordinateX, coordinateY, out coordinateX, out coordinateY);

                // This method setting and updating the food.
                food.FoodUpdater();

                // This statement checks if food was generated inside snake's body.
                if (!(food.food == '@'))
                    food.FoodUpdater();

                isBorderHit = BorderHit(coordinateX[0], coordinateY[0]);

                // And if yes, this statement stops the game with a message.
                if (isBorderHit)
                {
                    Program.isGameRunning = false;
                    Console.Clear();
                    Console.SetCursorPosition(17, 10);
                    Console.WriteLine("Game Over!");
                    Console.SetCursorPosition(14, 11);
                    Console.WriteLine($"Your score is: {food.score - 1}");
                    Console.SetCursorPosition(14, 12);
                    Console.WriteLine("Press Esc to exit.");
                }

                // This statement allows developer to control the game speed.
                if (Console.KeyAvailable) moveKey = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (Program.isGameRunning);


        }

        // This method tracks if border was hit.
        private bool BorderHit(int x, int y)
        {
            if (x == 0 || x == 43 || y == 0 || y == 23)
                return true;
            else
                return false;
        }

    }
}
