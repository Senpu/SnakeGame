using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        // A variable which determines game status.
        static public bool isGameRunning = true;
    
        static void Main(string[] args)
        {
            // Declaring instances of classes we are going to use.
            var Field = new PlayingField();            
            var Snake = new Snake();
            var Food = new Food();
           
            Field.FieldBuilder();
            Snake.DrawSnake();
            Food.FoodSetter();
            Snake.Game();

            Console.ReadKey();
        }
        
    }
}
