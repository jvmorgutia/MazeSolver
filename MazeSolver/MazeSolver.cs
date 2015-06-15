using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeCraze
{
    class MazeSolver
    {
        private Bitmap bitmap;
        private Color start_color, finish_color, wall_color, path_color;
        private Node startNode;
        /**
        *
        * I understand that memory is not necessarily conserved when creating a 2D array 
        * (especially if we have a big image!) however, in attempts to create a solution that would 
        * use less memory (a Dictionary of nodes along the possible path) I noticed a dramatic decrease in 
        * performance. 
        * 
        * Since most of the pixels on the image are blank, I decided to use this implementation as
        * the best solution for this problem.
        * 
        **/
        private Node[,] maze;
        private Queue<Node> queue;

        public MazeSolver(Bitmap bitmap, Color start_color, Color finish_color, Color wall_color, Color path_color)
        {
            this.bitmap = bitmap;
            this.start_color = start_color;
            this.finish_color = finish_color;
            this.wall_color = wall_color;
            this.path_color = path_color;

            maze = new Node[bitmap.Height, bitmap.Width];
            queue = new Queue<Node>();
            BitmapToMaze();
        }
        public bool FindPath()
        {
            Node currentNode = null;
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                currentNode.IsQueued = false;
                if (currentNode.Pixel == PixelColor.Finish)
                {
                    //A path is found!
                    WritePathToBitmap(currentNode);
                    return true;
                }
                foreach (Node neighborNode in GetNeighbors(currentNode))
                {
                    if (!neighborNode.IsVisited && neighborNode.Pixel != PixelColor.Wall)
                    {
                        neighborNode.Parent = currentNode;
                        if (!neighborNode.IsQueued)
                            queue.Enqueue(neighborNode);

                        neighborNode.IsQueued = true;
                    }
                }
                currentNode.IsVisited = true;
            }
            //A path was not found.
            return false;
        }
        //Converts a pixel into a Node object and inserts it into Node[,] maze.
        private void BitmapToMaze()
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    //Gets the color of every pixel in the bitmap
                    Color pixel_color = bitmap.GetPixel(j, i);

                    if (pixel_color == start_color)
                    {
                        maze[i, j] = new Node(i, j, PixelColor.Start);
                        if (startNode == null)
                        {
                            maze[i, j].IsVisited = true;
                            startNode = maze[i, j];
                            queue.Enqueue(startNode);
                        }
                    }
                    else if (pixel_color == finish_color)
                        maze[i, j] = new Node(i, j, PixelColor.Finish);
                    else if (pixel_color == wall_color)
                        maze[i, j] = new Node(i, j, PixelColor.Wall);
                    else
                        maze[i, j] = new Node(i, j, PixelColor.Blank);
                }
            }
        }

        private void WritePathToBitmap(Node endNode)
        {
            while (endNode.Parent != null)
            {
                bitmap.SetPixel(endNode.Y, endNode.X, path_color);
                endNode = endNode.Parent;
            }
        }

        private List<Node> GetNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();
            if (currentNode.X > 0 && currentNode.X < (bitmap.Height - 1) && currentNode.Y > 0 && currentNode.Y < (bitmap.Width - 1))
            {
                neighbors.Add(maze[currentNode.X, currentNode.Y + 1]);//TOP
                neighbors.Add(maze[currentNode.X, currentNode.Y - 1]);//BOTTOM
                neighbors.Add(maze[currentNode.X - 1, currentNode.Y]);//LEFT
                neighbors.Add(maze[currentNode.X + 1, currentNode.Y]);//RIGHT
            }
            return neighbors;
        }

        public bool TrySaveImage(string destination)
        {
            try
            {
                bitmap.Save(destination);
                return true;
            }
            catch (System.Runtime.InteropServices.ExternalException e)
            {  
                return false;
            }
        }
    }
}
