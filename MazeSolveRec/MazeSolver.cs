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
        private Color START, FINISH, WALL, PATH;
        private Node startNode;

        private Dictionary<int, Node> nodeKeeper;
        private PixelColor[,] pixelColor;
        private Queue<Node> queue;

        public MazeSolver(Bitmap bitmap, Color START, Color FINISH, Color WALL, Color PATH)
        {
            this.bitmap = bitmap;
            this.START = START;
            this.FINISH = FINISH;
            this.WALL = WALL;
            this.PATH = PATH;
            
            nodeKeeper = new Dictionary<int,Node>();
            pixelColor = new PixelColor[bitmap.Height,bitmap.Width];
            queue = new Queue<Node>();
            
            BitmapToMaze();
            Solve();
           
        }
        private bool Solve()
        {
           // int count = 0;
            Node currentNode = null;
            while(queue.Count > 0){
                 currentNode = queue.Dequeue();
                 bitmap.SetPixel(currentNode.Y, currentNode.X, PATH);
             //     count++;
                 //if (count == 150)
                 //{
                 //    SaveImage("Temp.png");
                 //    count = 0;
                 //}

                //nodeKeeper[Node.GenerateKey(currentNode.X, currentNode.Y)].IsQueued = false;

                if (pixelColor[currentNode.X, currentNode.Y] == PixelColor.Finish)
                {
                    Console.Write("FOUND A PATH");
                    WritePathToBitmap(currentNode);
                    return true;
                }
                foreach(Node neighborNode in GetNeighbors(currentNode)){
                    if (!neighborNode.IsVisited && pixelColor[neighborNode.X, neighborNode.Y] != PixelColor.Wall)
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

            } WritePathToBitmap(currentNode);

            return false;

        }
        private void BitmapToMaze(){
            for(int i = 0; i < bitmap.Height; i++){
                for(int j = 0; j < bitmap.Width; j++){
                    //Gets the color of every pixel in the bitmap
                    Color pixel_color = bitmap.GetPixel(j, i);
                    
                    if (pixel_color == START)
                    {
                        pixelColor[i, j] = PixelColor.Start;
                        if (startNode == null)
                        {
                            startNode = new Node(i, j);
                            startNode.IsVisited = true;
                            nodeKeeper.Add(Node.GenerateKey(i,j), startNode);
                            queue.Enqueue(startNode);
                        }
                    }
                    else if (pixel_color == FINISH)                   
                        pixelColor[i, j] = PixelColor.Finish;                    
                    else if (pixel_color == WALL)
                        pixelColor[i, j] = PixelColor.Wall;
                    else
                        pixelColor[i, j] = PixelColor.Blank;
                }
            }
            Console.WriteLine("CONVERTED SUCCESS");
        }

        private void WritePathToBitmap(Node endNode)
        {    
            //List<Node> pathMap = new List<Node>();
            while (endNode.Parent != null)
            {
                bitmap.SetPixel(endNode.Parent.Y, endNode.Parent.X, Color.Cyan);
                endNode = endNode.Parent;
            }
        }

       public List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();
            if(node.X > 0 && node.X < (bitmap.Height - 1) && node.Y > 0 && node.Y < (bitmap.Width - 1) ){
                int top_key = Node.GenerateKey(node.X, node.Y + 1);
                int bottom_key = Node.GenerateKey(node.X, node.Y - 1);
                int left_key = Node.GenerateKey(node.X - 1, node.Y);
                int right_key = Node.GenerateKey(node.X + 1, node.Y);

                //TOP
                if (nodeKeeper.ContainsKey(top_key)) 
                    neighbors.Add(nodeKeeper[top_key]);
                else
                {
                    Node top = new Node(node.X,node.Y + 1);
                    neighbors.Add(top);
                    nodeKeeper.Add(top_key, top);
                }
                //LEFT
                if (nodeKeeper.ContainsKey(left_key))
                    neighbors.Add(nodeKeeper[left_key]);
                else
                {
                    Node left = new Node(node.X - 1, node.Y);
                    neighbors.Add(left);
                    nodeKeeper.Add(left_key, left);
                }
                //BOTTOM
                if (nodeKeeper.ContainsKey(bottom_key)) 
                    neighbors.Add(nodeKeeper[bottom_key]);
                else
                {
                    Node bottom = new Node(node.X, node.Y - 1);
                    neighbors.Add(bottom);
                    nodeKeeper.Add(bottom_key, bottom);
                }
               
                //RIGHT
                if (nodeKeeper.ContainsKey(right_key))
                    neighbors.Add(nodeKeeper[right_key]);
                else
                {
                    Node right = new Node(node.X + 1, node.Y);
                    neighbors.Add(right);
                    nodeKeeper.Add(right_key, right);
                }
            }
            return neighbors;
        }

        public void SaveImage(string destination){
            bitmap.Save(destination);
        }
    }
}
