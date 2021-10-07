using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Snake part class.
    /// </summary>
    public class SnakePart
    {
        /// <summary>
        /// The symbol of this snake part.
        /// </summary>
        public char Symbol { get; private set; }

        /// <summary>
        /// The position of this snake part.
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// The constructor of the <see cref="SnakePart"/> class.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="symbol">The symbol of the snake part.</param>
        public SnakePart(Point position, char symbol)
        {
            Position = position;
            Symbol = symbol;
        }

        /// <summary>
        /// Draws the snake part.
        /// </summary>
        public void Draw()
        {
            if (Position.X == -1 || Position.X == Console.WindowWidth + 1)
                Environment.Exit(0);
            if (Position.Y == -1 || Position.Y == Console.WindowHeight + 1)
                Environment.Exit(0);
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }

        /// <summary>
        /// Erases previous parts of the snake.
        /// </summary>
        public void Erase()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
        }
    }
}
