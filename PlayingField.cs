using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class defines the field of the game. 
namespace SnakeGame
{
    class PlayingField
    {
        // Main building method.
        public void FieldBuilder()
        {
            var width = 42;
            var height = 22;

            //Console.SetWindowSize(width, height);
            Console.Clear();

            // UTF8 encoding to display unicode properly.
            Console.OutputEncoding = Encoding.UTF8;

            // +3 and +4 are needed because a window should be bigger than
            // a field in order to display borders properly.
            Console.SetWindowSize(width + 3, height + 4);
            Console.CursorVisible = false;
            Console.Clear();

            // Using StringBuilder as an easy method to build borders.
            var topBorder = new StringBuilder();
            var spaces = new string(' ', (width - 1));
            var botBorder = new StringBuilder();

            // Building the top border.
            for (int i = 0; i <= width; i++)
            {
                topBorder.Append('\u039E');
            }
            Console.WriteLine(topBorder + " ");

            // Building left and right borders.
            for (int i = 0; i < height; i++)
            {
                Console.Write('\u039E' + spaces + '\u039E' + "\n");
            }

            // Building the bottom border.
            for (int i = 0; i <= width; i++)
            {
                botBorder.Append('\u039E');
            }
            Console.Write(botBorder + " ");

        }
    }
}
