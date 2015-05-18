using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolveRec
{
    class Node
    {
        private int x;
        private int y;
        private int weight;
        private string key;

        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public int Weight { get; set; }
        public string Key
        {
            get { return key; }
        }
        
        public Node(int x, int y, int weight)
        {
            this.x = x;
            this.y = y;
            Weight = weight;
            key = x.ToString() + y.ToString();
        }
    }

}
