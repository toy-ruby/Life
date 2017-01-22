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
            string[] testCoords = { "2,4", "0 1", "4: 2" };    // DEBUG
            setupGrid(currentGrid, testCoords);
            printGrid(currentGrid);         
        }

        static void initializeGrid(int[,] grid)
        {
            for (int i = 0; i < Math.Sqrt(grid.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(grid.Length); j++)
                {
                    grid[i, j] = 0;
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

        static void calculateNextGrid(int[,] grid)
        {
            
        }

        static void setupGrid(int[,] grid, string[] coords = null)
        {
            if(coords != null)
            {
                foreach(string coord in coords)
                {
                    char[] delimiter = " ,:".ToCharArray();
                    int x = Convert.ToInt32(coord.Split(delimiter, 2)[0]);
                    int y = Convert.ToInt32(coord.Split(delimiter, 2)[1]);
                    grid[x, y] = 1;
                }
            }
            return;
        }
    }
}
