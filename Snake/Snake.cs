using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// The snake class.
    /// </summary>
    public class Snake
    {
        /// <summary>
        /// Length of the snake.
        /// </summary>
        private int Length { get; set; }

        /// <summary>
        /// Symbol of the snake.
        /// </summary>
        public char Symbol { get; private set; }

        private SnakePart[] SnakeBody;
        private SnakePart Head 
            => SnakeBody.First();
        private SnakePart Tail 
            => SnakeBody.Last();

        /// <summary>
        /// Constructor for the <see cref="Snake"/> class.
        /// </summary>
        /// <param name="startingPoint">The starting point of this snake.</param>
        /// <param name="length">The length of the snake.</param>
        /// <param name="symbol">The symbol of the snake.</param>
        public Snake(Point startingPoint, int length, char symbol = '*')
        {
            Symbol = symbol;

            Length = length;

            SnakeBody = Enumerable
                .Range(0, length)
                .Select(x => new SnakePart(startingPoint, symbol))
                .ToArray();
        }

        /// <summary>
        /// Draws the snake.
        /// </summary>
        public void Draw()
        {
            foreach (var part in SnakeBody)
                part.Draw();
        }

        /// <summary>
        /// Moves the snake in a direction.
        /// </summary>
        /// <param name="direction">The direction to move the snake in.</param>
        public void Move(Direction direction)
        {
            if (SnakeBody.Any(x => x != SnakeBody[0] && x.Position == Head.Position))
                Environment.Exit(0);
            if (Head.Position == Program.Food.Position)
                Length += 1;
            if (SnakeBody.Length != Length)
            {
                Console.Clear();
                Program.Food
                    = new(Console.WindowWidth, Console.WindowHeight, '^');
                Program.Food.Draw();
                SnakeBody = Enumerable
                    .Range(0, Length)
                    .Select(x => new SnakePart(Head.Position, Symbol))
                    .ToArray();
            }
            Point point = new();

            switch (direction)
            {
                case Direction.Up:
                    point = new Point(Head.Position.X, Head.Position.Y - 1);
                    break;
                case Direction.Down:
                    point = new Point(Head.Position.X, Head.Position.Y + 1);
                    break;
                case Direction.Left:
                    point = new Point(Head.Position.X - 1, Head.Position.Y);
                    break;
                case Direction.Right:
                    point = new Point(Head.Position.X + 1, Head.Position.Y);
                    break;
            }
            SnakePart head = new(point, Symbol);
            Tail.Erase();
            for (var i = SnakeBody.Length - 1; i > 0; i--)
                SnakeBody[i] = SnakeBody[i - 1];
            SnakeBody[0] = head;
            Draw();
        }
    }
}
