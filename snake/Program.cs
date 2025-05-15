using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public static class Snake
    {
        private static int _fruitEaten = 0;
        private static Random _rand = new Random();
        public static void Main()
        {
            Console.WriteLine("Welcome to snake! Press any key to start.");
            Console.ReadKey();
            var segment = new Segment
            {
                SnakeX = _rand.Next(4, Console.WindowWidth - 4),
                SnakeY = _rand.Next(4, Console.WindowHeight - 4)
            };
            var apple = new Apple
            {
                AppleX = _rand.Next(4, Console.WindowWidth - 4),
                AppleY = _rand.Next(4, Console.WindowHeight - 4)
            };
            
            var snake = new List<Segment> { segment };
            
            while (true)
            {
                snake.Insert(0, Move(snake[0]));
                var tail = snake[^1];
                
                if (snake[0].SnakeX == apple.AppleX && snake[0].SnakeY == apple.AppleY)
                {
                    snake.Add(tail);
                }
                
                apple = EatApple(apple, snake[0]);
                snake.RemoveAt(_fruitEaten + 1);
                Draw(apple, snake);

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                
                Thread.Sleep(snake[0].Direction is 'l' or 'r' ? 25 : 50);
            }
        }

        private class Segment
        {
            public int SnakeX;
            public int SnakeY;
            public char Direction;
        }

        private class Apple
        {
            public int AppleX;
            public int AppleY;
        }

        private static Segment Move(Segment moveSegment)
        {
            var segment = new Segment { Direction = moveSegment.Direction, SnakeX = moveSegment.SnakeX, SnakeY = moveSegment.SnakeY };
            
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.E:
                        segment.Direction = 'u';
                        break;
                    case ConsoleKey.D:
                        segment.Direction = 'd';
                        break;
                    case ConsoleKey.S:
                        segment.Direction = 'l';
                        break;
                    case ConsoleKey.F:
                        segment.Direction = 'r';
                        break;
                    default:
                        break;
                }
            }
            switch (segment.Direction)
            {
                case 'u':
                    segment.SnakeY--;
                    break;
                case 'd':
                    segment.SnakeY++;
                    break;
                case 'l':
                    segment.SnakeX--;
                    break;
                case 'r':
                    segment.SnakeX++;
                    break;
                default:
                    break;
            }
            return segment;
        }
        private static void Draw(Apple apple, List<Segment> snake)
        {
            Console.CursorVisible = false;
            Console.Clear();
            DrawBox();
            foreach (var segment in snake)
            {
                Console.SetCursorPosition(segment.SnakeX, segment.SnakeY);
                switch (segment.Direction)
                {
                    case 'u':
                        Console.Write("🞁");
                        break;
                    case 'd':
                        Console.Write("🞃");
                        break;
                    case 'l':
                        Console.Write("🞀");
                        break;
                    case 'r':
                        Console.Write("🞂");
                        break;
                    default:
                        Console.Write("fuck you");
                        break;
                }
            }
            Console.SetCursorPosition(apple.AppleX, apple.AppleY);
            Console.Write("🍏");
            Console.SetCursorPosition(0, Console.WindowHeight);
        }
        private static void DrawBox()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" ");
            Console.Write(" ");
            Console.Write(" ");
            for (var i = 0; i < Console.WindowWidth - 6; i++)
            {
                Console.Write("▄");
            }
            Console.SetCursorPosition(0, 3);
            for (var i = 3; i < Console.WindowHeight - 3; i++)
            {
                Console.Write("   █");
                Console.SetCursorPosition(Console.WindowWidth - 4, i);
                Console.WriteLine("█");
            }
            Console.Write(" ");
            Console.Write(" ");
            Console.Write(" ");
            for (var i = 0; i < Console.WindowWidth - 6; i++)
            {
                Console.Write("▀");
            }
        }
        private static Apple EatApple(Apple apple, Segment segment)
        {
            if (segment.SnakeX != apple.AppleX || segment.SnakeY != apple.AppleY) return apple;
            _fruitEaten++;
            
            apple.AppleX = _rand.Next(4, Console.WindowWidth - 4);
            apple.AppleY = _rand.Next(4, Console.WindowHeight - 4);

            return apple;
        }
    }
}
/* todo
 set snake position as variable
   increase variable by whatever direction is currently "true" 
   save last x ("fruit eaten") snakepos variables **OR** add last snakepos to list when fruit eaten
   clear console and write snakepos variables and fruit 
   profit?????
   */
