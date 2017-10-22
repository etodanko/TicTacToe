using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiks_and_Nolicks
{
    class Player
    {
        public Player()
        {
        }  
        public void Input(char[,] map, char symbol, int x_coor, int y_coor)
        {
            if (map[x_coor, y_coor] == '*')
                map[x_coor, y_coor] = symbol;
            else
            {
                Console.WriteLine("There is already something inputed, choose another point");
            }
        }
    }
    ////////////////////////////////////////////////////////////
    class Program
    {
        static int GameOver(char[,] map)
        {
            // -1 - игра не окончена; 0 - ничья; 1 - победили крестики; 2 - победили нолики

            // Проверка на чью-нибудь победу

            // По горизонтали
            if ((map[0, 0] == 'X' && map[1, 0] == 'X' && map[2, 0] == 'X') ||
                (map[0, 1] == 'X' && map[1, 1] == 'X' && map[2, 1] == 'X') ||
                (map[0, 2] == 'X' && map[1, 2] == 'X' && map[2, 2] == 'X') ||

                // По вертикали
                (map[0, 0] == 'X' && map[0, 1] == 'X' && map[0, 2] == 'X') ||
                (map[1, 0] == 'X' && map[1, 1] == 'X' && map[1, 2] == 'X') ||
                (map[2, 0] == 'X' && map[2, 1] == 'X' && map[2, 2] == 'X') ||

                // По диагонали
                (map[0, 0] == 'X' && map[1, 1] == 'X' && map[2, 2] == 'X') ||
                (map[2, 0] == 'X' && map[1, 1] == 'X' && map[0, 2] == 'X'))
                return 1;


            if ((map[0, 0] == 'O' && map[1, 0] == 'O' && map[2, 0] == 'O') ||
                (map[0, 1] == 'O' && map[1, 1] == 'O' && map[2, 1] == 'O') ||
                (map[0, 2] == 'O' && map[1, 2] == 'O' && map[2, 2] == 'O') ||

                // По вертикали
                (map[0, 0] == 'O' && map[0, 1] == 'O' && map[0, 2] == 'O') ||
                (map[1, 0] == 'O' && map[1, 1] == 'O' && map[1, 2] == 'O') ||
                (map[2, 0] == 'O' && map[2, 1] == 'O' && map[2, 2] == 'O') ||

                // По диагонали
                (map[0, 0] == 'O' && map[1, 1] == 'O' && map[2, 2] == 'O') ||
                (map[2, 0] == 'O' && map[1, 1] == 'O' && map[0, 2] == 'O'))
                return 2;

            // Проверка на ничью
            int count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (map[i,j] != '*')
                        count++;
            // Заполнено все поле
            if (count == 9)
                return 0;

            return -1;
        }
        static void MapInput(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '*';
                }
            }
        }
        static void ShowMap(char [,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        ////////////////////////////////////////////////////////// main ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            const int height = 3;
            const int width = 3;
            int x_coor, y_coor;
            char[,] map = new char[height, width];
            MapInput(map);
            ShowMap(map);
            Console.WriteLine("Players1 symbol is X /n Players2 symbol is O");
            Player player1 = new Player();
            Player player2 = new Player();
            char Players1_symbol = 'X';
            char Players2_symbol = 'O';

            
            while ( GameOver(map) == -1 )
            {
                Players1_Input:
                Console.WriteLine("Enter x coordinate :");
                x_coor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y coordinate :");
                y_coor = Convert.ToInt32(Console.ReadLine());
                if (map[x_coor, y_coor] == '*')
                {
                    player1.Input(map, Players1_symbol, x_coor, y_coor);
                    ShowMap(map);
                }
                else
                {
                    Console.WriteLine("There is already a symbol, try another point!");
                    ShowMap(map);
                    //geniy koda
                    goto Players1_Input;
                }

                if (GameOver(map) != -1)
                    break;

                Players2_Input:
                Console.WriteLine("Enter x coordinate :");
                x_coor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter y coordinate :");
                y_coor = Convert.ToInt32(Console.ReadLine());
                if (map[x_coor, y_coor] == '*')
                {
                     player2.Input(map, Players2_symbol, x_coor, y_coor);
                    ShowMap(map);
                }
                else
                {
                    Console.WriteLine("There is already a symbol, try another point!");
                    ShowMap(map);
                    goto Players2_Input;
                }

                if (GameOver(map) != -1)
                    break;
            }
            if (GameOver(map) == 1)
                Console.WriteLine("Player 1 - winner winner chicken dinner");
            if (GameOver(map) == 2)
                Console.WriteLine("Player 2 - winner winner chicken dinner");
            if (GameOver(map) == 0)
                Console.WriteLine("No one has won");


            ShowMap(map);


            Console.ReadLine();

        }
    }
}
