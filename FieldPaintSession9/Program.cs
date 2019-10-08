using System;

namespace Bertleblip
{
    class DisplayClass
    {
        public static void Main(string[] args)
        {
            // Grid with some live and some dead cells
            // Look at that original grid
            // Change grid so at the end, we have the next generation of cells
            // that follow the rules of Conway's Game of Life

            // set up initial game of life
            GameOfLife game = new GameOfLife(15, 20);


            while (true)
            {
                // display grid
                // - be able to read/see grid from game of life class
                // - tell if an individual cell is alive or dead
                // loop over grid
                // print it out
                for (int i = 0; i < game.Height; i++)
                {
                    for (int j = 0; j < game.Width; j++)
                    {
                        if (game.grid[i, j])
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }

                // go to next generation
                // - run rules of game of life
                // - update that grid so we're on the next generation
                game.GoNextGen();

                // loop all of that, maybe with a delay
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            Console.ReadLine();
        }
    }

    public class GameOfLife
    {
        public bool[,] grid;
        public int Width;
        public int Height;

        public GameOfLife(int setHeight, int Width)
        {
            grid = new bool[setHeight, Width];
            this.Width = Width;
            Height = setHeight;
            var rand = new Random();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if(rand.Next(5) == 1)
                    {
                        grid[i, j] = true;
                    }
                }
            }
            //grid[1, 1] = true;
            //grid[2, 1] = true;
            //grid[3, 1] = true;
        }

        private bool isAlive(int x, int y)
        {
            // if x and y are in the grid, return the grid value
            // otherwise, return false
            if (x >= 0 && x < Height && y >= 0 && y < Width)
            {
                return grid[x, y];
            }
            else
            {
                return false;
            }
        }

        public void GoNextGen()
        {
            // create new grid that is empty or all false
            // look at the original grid, cell by cell
            // for each cell, do the rules of GoL
            //   
            // write the result into the new grid
            // copy the new grid over the old grid

            bool[,] newGrid = new bool[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int neighbors = 0;

                    if (isAlive(i - 1, j) == true) { neighbors += 1; }
                    if (isAlive(i - 1, j - 1) == true) { neighbors += 1; }
                    if (isAlive(i - 1, j + 1) == true) { neighbors += 1; }
                    if (isAlive(i , j - 1) == true) { neighbors += 1; }
                    if (isAlive(i , j + 1) == true) { neighbors += 1; }
                    if (isAlive(i + 1, j - 1) == true) { neighbors += 1; }
                    if (isAlive(i + 1, j) == true) { neighbors += 1; }
                    if (isAlive(i + 1, j + 1) == true) { neighbors += 1; }

                    if(grid[i,j] == true && (neighbors == 2 || neighbors == 3))
                    {
                        // should be alive
                        newGrid[i, j] = true;
                    }
                    else if(grid[i, j] == false && neighbors == 3)
                    {
                        // should be alive
                        newGrid[i, j] = true;
                    }
                }
            }

            grid = newGrid;

        }
    }
}
