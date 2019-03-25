using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class is enering point of the game.
namespace SnakeGame
{
    class Program
    {
        // A variable which determines game status.
        static public bool isGameRunning = true;
    
        static void Main(string[] args)
        {
            // Setting Encoding to display all symbols properly.
            Console.OutputEncoding = Encoding.UTF8;

            // Declaring instances of classes we are going to use.           
            var snake = new Snake();
            var food = new Food();
           
            PlayingField.FieldBuilder();
            food.FoodUpdater();
            snake.DrawSnakeOnce();
            snake.Game();

            Console.ReadKey();
            
        }
        
    }
}
