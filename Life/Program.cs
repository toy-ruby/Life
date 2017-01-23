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
            setupGrid(currentGrid);
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

        static void setupGrid(int[,] grid, string[] coords = null)
        {
            if (coords != null)
            {
                foreach (string coord in coords)
                {
                    char[] delimiter = " ,:".ToCharArray();
                    int x = Convert.ToInt32(coord.Split(delimiter, 2)[0]);
                    int y = Convert.ToInt32(coord.Split(delimiter, 2)[1]);
                    grid[x, y] = 1;
                }
            }
            else
            {
                // Randomly generate set of coordinates for setup
                var rand = new Random();
                int count = rand.Next(0, grid.Length);
                string[] ary = new string[count];
                for (int i = 0; i < count; i++)
                {
                    int x = rand.Next(0, grid.GetLength(0));
                    int y = rand.Next(0, grid.GetLength(0));
                    ary[i] = Convert.ToString(x) + " " + Convert.ToString(y);
                }
                // Recursively call setupGrid with random coords
                setupGrid(grid, ary);
            }
        }

        static void calculateNextGrid(int[,] grid)
        {

        }
    }
}