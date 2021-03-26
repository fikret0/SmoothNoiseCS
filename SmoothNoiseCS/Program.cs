using System;
using System.Text;
using System.Threading;

namespace SmoothNoiseCS
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 80;
            int height = 25;

            Console.OutputEncoding = Encoding.UTF8;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float noise = SmoothNoise.GenerateNoise(1, 3, 0.8f, 0.8f);

                    int roundedNoise = (int)Math.Round(noise);

                    if (roundedNoise == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (roundedNoise == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.SetCursorPosition(x, y);
                    Console.Write("O");
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
