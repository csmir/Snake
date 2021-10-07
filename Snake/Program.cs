using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace Snake
{
    /// <summary>
    /// Direction the bot goes in.
    /// </summary>
    public enum Direction
    {
        Up,

        Down,

        Left,

        Right,

        None
    }

    public class Program
    {
        /// <summary>
        /// The timer handling the snake movement.
        /// </summary>
        private static Timer Timer 
            = new(150) { AutoReset = true, Enabled = true };

        /// <summary>
        /// The direction the snake should take.
        /// </summary>
        private static Direction Dir 
            = Direction.None;

        /// <summary>
        /// The snake itself.
        /// </summary>
        private static Snake Snake;

        /// <summary>
        /// The food the snake should pick up.
        /// </summary>
        public static Food Food 
            = new(Console.WindowWidth, Console.WindowHeight, '^');

        static void Main(string[] args)
        {
#pragma warning disable
            Console.SetWindowSize(50, 25);
#pragma warning restore
            Snake = new Snake(new Point((Console.WindowWidth / 2), (Console.WindowHeight / 2)), 1, '*');
            Snake.Draw();

            Food.Draw();
            Timer.Elapsed += Movement;
            Console.CursorVisible = false;

            while (true)
            {
                var ch = Console.ReadKey(true).Key;
                if (ch == ConsoleKey.Q) break;


                switch (ch)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Dir = Direction.Up;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Dir = Direction.Down;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Dir = Direction.Left;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Dir = Direction.Right;
                        break;
                }
            }
            Console.CursorVisible = true;
        }

        private static void Movement(object sender, ElapsedEventArgs e)
        { 
            Snake.Move(Dir);
        }
    }
}
