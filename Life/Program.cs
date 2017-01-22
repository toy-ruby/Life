using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter grid size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] currentGrid = new int[size, size];
            int[,] nextGrid = new int[size, size];

            initializeGrid(currentGrid);
            printGrid(currentGrid);
            
        }

        static void initializeGrid(int[,] grid)
        {
            for (int i = 0; i < Math.Sqrt(grid.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(grid.Length); j++)
                {
                    grid[i, j] = 1;
                }
            }
        }

        static void printGrid(int[,] grid)
        {
            // Print out grid
            for (int i = 0; i < Math.Sqrt(grid.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(grid.Length); j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
}
