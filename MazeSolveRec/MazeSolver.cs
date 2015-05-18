using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolveRec
{
    private enum Pixel{
        Start,
        Finish,
        Blank,
        Wall    
    }
    class MazeSolver
    {
        private Bitmap maze;
        private Node startingNode;
        private Pixel[] pMaze;

        private Dictionary<string, Node> map;

        public Bitmap Maze
        {
            get { return maze; }
        }

        public MazeSolver(Bitmap maze)
        {
            this.maze = maze;

            startingNode = MazeHelper.FindStartingLocation(maze);
            map = new Dictionary<string, Node>();
            map.Add(startingNode.Key, startingNode);
        }
        private void FindNeighbors(Node currentNode)
        {
            int x = currentNode.X;
            int y = currentNode.Y;
            int weight = currentNode.Weight;

            if (x > 0 && x + 1 < maze.Width && y > 0 && y + 1 < maze.Height)
            {
                if (maze.GetPixel(x + 1, y) != MazeHelper.BLACK && !map.ContainsKey(MazeHelper.GenerateKey(x + 1, y)))
                {
                    Node rightNode = new Node(x + 1, y, weight + 1);
                    map.Add(rightNode.Key, rightNode);
                    FindNeighbors(rightNode);
                }
                if (maze.GetPixel(x - 1, y) != MazeHelper.BLACK && !map.ContainsKey(MazeHelper.GenerateKey(x - 1, y)))
                {
                    Node leftNode = new Node(x - 1, y, weight + 1);
                    map.Add(leftNode.Key, leftNode);
                    FindNeighbors(leftNode);
                }
                if (maze.GetPixel(x, y - 1) != MazeHelper.BLACK && !map.ContainsKey(MazeHelper.GenerateKey(x, y - 1)))
                {
                    Node downNode = new Node(x, y - 1, weight + 1);
                    map.Add(downNode.Key, downNode);
                    FindNeighbors(downNode);
                }
                if (maze.GetPixel(x, y + 1) != MazeHelper.BLACK && !map.ContainsKey(MazeHelper.GenerateKey(x, y + 1)))
                {
                    Node upNode = new Node(x, y + 1, weight + 1);
                    map.Add(upNode.Key, upNode);
                    FindNeighbors(upNode);
                }
            }
            maze.SetPixel(x, y, MazeHelper.GREEN);
        }

        

        public void SaveImage(string destination){
            maze.Save(destination);
        }
    }
}
