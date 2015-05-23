using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCraze
{
    public class Node
    {
        private int x;
        private int y;
        private bool isVisited;
        private bool isQueued;
        private PixelColor pixel;
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
        public PixelColor Pixel
        {
            get { return pixel; }
            set { pixel = value; }
        }
        public Node(int x, int y, PixelColor pixel)
        {
            this.x = x;
            this.y = y;
            this.pixel = pixel;
            isVisited = false;
            isQueued = false;
        }
    }
}
