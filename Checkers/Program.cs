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
            {1, 1, 0, 1, 0, 1, 0, 1 },
            {1, 0, 1, 0, 1, 0, 1, 0 },
            {0, 1, 0, 1, 0, 1, 0, 1 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0 },
            {2, 0, 2, 0, 2, 0, 2, 0 },
            {0, 2, 0, 2, 0, 2, 0, 2 },
            {2, 0, 2, 0, 2, 0, 2, 0 }
        };
        #region Координаты
        static int[] cursor = { 7, 7 };
        static int[] check = { 0, 0 };

        static int GetCursor(string xy)
        {
            if (xy == "x") return cursor[0];
            else if (xy == "y") return cursor[1];
            else return -1;
        }

        static void SetCursor(int x, int y)
        {
            cursor[0] = x;
            cursor[1] = y;
        }

        static int GetCheck(string xy)
        {
            if (xy == "x") return check[0];
            else if (xy == "y") return check[1];
            else return -1;
        }

        static void SetCheck()
        {
            check[0] = cursor[0];
            check[1] = cursor[1];
        }
        #endregion



        static void DrawField()
        {
            Console.Clear();
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

                    if(GetCheck("x") == i && GetCheck("y") == j)
                    {
                        if(map[i, j] > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("o|");
                        }
                        else Console.Write(" |");
                    }
                    else
                    {
                        if (map[i, j] == 1)
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
                    }
                    

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        static void Main(string[] args)
        {
            while(true)
            {
                DrawField();
                ReadCursor();
            }
        }


        static void ReadCursor()
        {
            ConsoleKey keydown = Console.ReadKey().Key;
            if(keydown == ConsoleKey.W && GetCursor("x") > 0)
            {
                SetCursor(GetCursor("x") - 1, GetCursor("y") );
            }
            else if (keydown == ConsoleKey.D && GetCursor("y") < 7)
            {
                SetCursor(GetCursor("x"), GetCursor("y") + 1);
            }
            else if(keydown == ConsoleKey.S && GetCursor("x") < 7)
            {
                SetCursor(GetCursor("x") + 1, GetCursor("y"));
            }
            else if(keydown == ConsoleKey.A && GetCursor("y") > 0)
            {
                SetCursor(GetCursor("x"), GetCursor("y") - 1);
            }
            else if(keydown == ConsoleKey.Spacebar)
            {
                SetCheck();
            }
        }
    }
}
