using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static int[,] map =
        {
            {0, 1, 0, 1, 0, 1, 0, 1 },
            {1, 0, 1, 0, 1, 0, 1, 0 },
            {0, 1, 0, 1, 0, 1, 0, 1 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {2, 0, 2, 0, 2, 0, 2, 0 },
            {0, 2, 0, 2, 0, 2, 0, 2 },
            {2, 0, 2, 0, 2, 0, 2, 0 }
        };

        static int[] cursor = { 7, 7 };

        static int GetCursor(string xy)
        {
            if (xy == "x") return cursor[0];
            else if (xy == "y") return cursor[1];
            else return -1;
        }

        static void DrawField()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.WriteLine("------------------------");
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(GetCursor("x") == i && GetCursor("y") == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(">");
                    }
                    else Console.Write(" ");


                    if(map[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("o|");
                    }
                    else if (map[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("o|");
                    }
                    else Console.Write(" |");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        static void Main(string[] args)
        {
            DrawField();
            Console.ReadKey();
        }
    }
}
