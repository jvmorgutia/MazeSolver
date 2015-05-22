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

       // private Dictionary<int, Node> nodeKeeper;
        private Node[,] nodeArray;
        private Queue<Node> queue;

        public MazeSolver(Bitmap bitmap, Color start_color, Color finish_color, Color wall_color, Color path_color)
        {
            this.bitmap = bitmap;
            this.start_color = start_color;
            this.finish_color = finish_color;
            this.wall_color = wall_color;
            this.path_color = path_color;
            
           // nodeKeeper = new Dictionary<int,Node>();
           // pixelColor = new PixelColor[bitmap.Height,bitmap.Width];
            nodeArray = new Node[bitmap.Height,bitmap.Width];
            queue = new Queue<Node>();
            
            BitmapToMaze();
            Solve();
           
        }
        public bool Solve()
        {
            Node currentNode = null;
            while(queue.Count > 0){
                 currentNode = queue.Dequeue();
                if (currentNode.Pixel == PixelColor.Finish)
                {
                    Console.Write("FOUND A PATH");
                    WritePathToBitmap(currentNode);
                    return true;
                }
                foreach(Node neighborNode in GetNeighbors(currentNode)){
                    if (!neighborNode.IsVisited && neighborNode.Pixel != PixelColor.Wall)
                    {
                        neighborNode.Parent = currentNode;
                        if (!neighborNode.IsQueued)
                        {
                            queue.Enqueue(neighborNode);
                        }
                        neighborNode.IsQueued = true;                        
                    }
                }
                currentNode.IsVisited = true;
            }
            Printer.PrintError(ErrorType.NoPathFound);
            return false;
        }
        private void BitmapToMaze(){
            for(int i = 0; i < bitmap.Height; i++){
                for(int j = 0; j < bitmap.Width; j++){
                    //Gets the color of every pixel in the bitmap
                    Color pixel_color = bitmap.GetPixel(j, i);

                    if (pixel_color == start_color)
                    {
                        nodeArray[i, j] = new Node(i, j, PixelColor.Start);
                        if (startNode == null)
                        {
                            nodeArray[i, j].IsVisited = true;
                            startNode = nodeArray[i, j];
                            queue.Enqueue(startNode);
                        }
                    }
                    else if (pixel_color == finish_color)
                        nodeArray[i, j] = new Node(i, j, PixelColor.Finish);
                    else if (pixel_color == wall_color)
                        nodeArray[i, j] = new Node(i, j, PixelColor.Wall);
                    else
                        nodeArray[i, j] = new Node(i,j,PixelColor.Blank);
                }
            }
            Console.WriteLine("CONVERTED SUCCESS");
        }

        private void WritePathToBitmap(Node endNode)
        {    
            //List<Node> pathMap = new List<Node>();
            while (endNode.Parent != null ) 
            {
                bitmap.SetPixel(endNode.Y, endNode.X, path_color);
                endNode = endNode.Parent;

            }
        }

       public List<Node> GetNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();
            if(currentNode.X > 0 && currentNode.X < (bitmap.Height - 1) && currentNode.Y > 0 && currentNode.Y < (bitmap.Width - 1) ){
                neighbors.Add(nodeArray[currentNode.X, currentNode.Y + 1]);//TOP
                neighbors.Add(nodeArray[currentNode.X, currentNode.Y - 1]);//BOTTOM
                neighbors.Add(nodeArray[currentNode.X - 1, currentNode.Y]);//LEFT
                neighbors.Add(nodeArray[currentNode.X + 1, currentNode.Y]);//RIGHT
            }
            return neighbors;
        }

        public void SaveImage(string destination){
            bitmap.Save(destination);
        }
    }
}
