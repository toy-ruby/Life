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
            bool quit = false;

            // get dimension of SQUARE grid
            Console.Write("Enter grid size: ");
            int size = Convert.ToInt32(Console.ReadLine());

            while (!quit)
            {
                int[,] currentGrid = new int[size, size];
                int[,] nextGrid = new int[size, size];
                string[] coords = { "0 0", "2 1", "3 2", "2 2", "2 3", "1 3", "2 3", "1 4" };

                initializeGrid(currentGrid);
                //setupGrid(currentGrid);
                setupGrid(currentGrid, coords);

                printGrid(currentGrid);
                calculateNextGrid(currentGrid, nextGrid);
                printGrid(nextGrid);

                if (Console.ReadLine() != "")
                {
                    quit = true;
                }
            }
        }

        static void initializeGrid(int[,] grid)
        {
            // set grid to 0s
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
            for (int j = 0; j < Math.Sqrt(grid.Length); j++)
            {
                for (int i = 0; i < Math.Sqrt(grid.Length); i++)
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

        static void calculateNextGrid(int[,] currGrid, int[,] nextGrid)
        {
            int[] currentIndex = new int[2];
            uint xMax = Convert.ToUInt16(currGrid.GetLength(0) - 1);
            uint yMax = Convert.ToUInt16(currGrid.GetLength(1) - 1);
            for (int x = 0; x < currGrid.GetLength(0); x++)
            {
                for (int y = 0; y < currGrid.GetLength(0); y++)
                {
                    int count = 0;
                    if (x > 0)
                    {
                        // left one
                        if (currGrid[x - 1, y] == 1) count++;
                    }
                    if (x < currGrid.GetLength(0) - 1)
                    {
                        // right one
                        if (currGrid[x + 1, y] == 1) count++;
                    }
                    if (y > 0)
                    {
                        // up one
                        if (currGrid[x, y - 1] == 1) count++;
                    }
                    if (y < currGrid.GetLength(1) - 1)
                    {
                        // down one
                        if (currGrid[x, y + 1] == 1) count++;
                    }
                    if (x > 0 && y > 0)
                    {
                        // up & left one
                        if (currGrid[x - 1, y - 1] == 1) count++;
                    }
                    if (x < currGrid.GetLength(0) - 1 && y < currGrid.GetLength(1) - 1)
                    {
                        // down & right one
                        if (currGrid[x + 1, y + 1] == 1) count++;
                    }
                    if (x > 0 && y < currGrid.GetLength(1) - 1)
                    {
                        // down & left one
                        if (currGrid[x - 1, y + 1] == 1) count++;
                    }
                    if (x < currGrid.GetLength(0) - 1 && y > 0)
                    {
                        // up & right
                        if (currGrid[x + 1, y - 1] == 1) count++;
                    }

                    switch (count)
                    {
                        case 8:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            continue;
                        case 7:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            continue;
                        case 6:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            continue;
                        case 5:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            continue;
                        case 4:
                            nextGrid[x, y] = 0;
                            break;
                        case 3:
                            if (currGrid[x, y] == 0)
                            {
                                nextGrid[x, y] = 1;
                            }
                            nextGrid[x, y] = 1;
                            break;
                        case 2:
                            nextGrid[x, y] = currGrid[x, y];
                            break;
                        case 1:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            continue;
                        case 0:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            break;
                        default:
                            if (currGrid[x, y] == 1) nextGrid[x, y] = 0;
                            break;
                    }
                }
            }
        }

        static bool isLeft(int[] ind)
        {
            if (ind[0] == 0) return true;
            return false;
        }

        static bool isRight(int[] ind)
        {
            if (ind[1] == 0) return true;
            return false;
        }

        static bool isTop(int[] ind, int len)
        {
            if (ind[0] == len) return true;
            return false;
        }

        static bool isBottom(int[] ind, int len)
        {
            if (ind[0] == len) return true;
            return false;
        }
    }
}