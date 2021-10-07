using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// The food class.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// The position of the food item.
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// The symbol of the food item.
        /// </summary>
        public char Symbol { get; private set; }

        /// <summary>
        /// The constructor of the food class.
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <param name="symbol"></param>
        public Food(int maxX, int maxY, char symbol)
        {
            var random = new Random();
            var x = random.Next(maxX);
            var y = random.Next(maxY);

            Position = new(x, y);

            Symbol = symbol;
        }

        /// <summary>
        /// Draws the food.
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Symbol);
            Console.ResetColor();
        }
    }
}
