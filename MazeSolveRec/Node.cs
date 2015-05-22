using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCraze
{
    class Node
    {
        private int x;
        private int y;
        private bool isVisited;
        private bool isQueued;

        private Node parent;

        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public bool IsVisited
        {
            get { return isVisited; }
            set { isVisited = value; }
        }
        public bool IsQueued
        {
            get { return isQueued; }
            set { isQueued = value; }
        }
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            isVisited = false;
            isQueued = false;
        }
        public static int GenerateKey(int i, int j)
        {
            return Convert.ToInt32(i.ToString() + j.ToString());
        }
   
      
    

        
    }

}
