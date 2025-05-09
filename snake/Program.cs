using System;
using System.Collections.Generic;

namespace Snake
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Snake! Press Enter to start.");
            Console.ReadLine();
        }

        static int[] Spawnpoints()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            var rand = new Random();
            int snakeSpawnX = rand.Next(0, width);
            int snakeSpawnY = rand.Next(0, height);
            int appleSpawnX = rand.Next(0, width);
            int appleSpawnY = rand.Next(0, height);
            return new int[] { snakeSpawnX, snakeSpawnY, appleSpawnX, appleSpawnY };
        }

        static void Draw()
        {
            Console.CursorVisible = false;;
            Console.Clear();
            
        }
    }
}
