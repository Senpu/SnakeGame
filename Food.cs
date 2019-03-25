﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class is responsible for food generation, food eaten events and the score counter.
namespace SnakeGame
{
    class Food
    {
        public int foodX;
        public int foodY;
        public int score = -1;
        public char food = '@';

        bool isFoodEaten = true;

        Random random = new Random();

        // This method generates random coordinates for food.
        private void FoodGenerator(out int foodX, out int foodY)
        {
            foodX = random.Next(1, 40);
            foodY = random.Next(1, 20);
        }
        
        // And this method set food on the field using those coordinates generated by method FoodGenerator.
        // It also increment score variable for every food eaten.
        public void FoodUpdater()
        {
            if (isFoodEaten)
            {
             A: FoodGenerator(out foodX, out foodY);

                if ((foodX == Snake.coordinateX[score + 1]) && (foodY == Snake.coordinateY[score + 1]))
                {
                    goto A;
                }
                else
                {
                    Console.SetCursorPosition(foodX, foodY);
                    Console.Write(food);

                    // Inreasing score and speed every time food was eaten. 
                    Snake.gameSpeed *= .888m;
                    score++;
                }


            }
            isFoodEaten = IfFoodWasEaten(foodX, foodY, Snake.coordinateX[0], Snake.coordinateY[0]);
        }
        

        // This method tracks if food was eaten so methods FoodGenerator and FoodSetter could spawn a new one.
        private bool IfFoodWasEaten(int foodX, int foodY, int coordinateX, int coordinateY)
        {
            if (coordinateX == foodX && coordinateY == foodY)
                return true;
            else
                return false;
        }
    }
}
