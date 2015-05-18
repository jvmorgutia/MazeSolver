using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolveRec
{
    class MazeHelper
    {
        public static Color RED = Color.FromArgb(255, 255, 0, 0);
        public static Color GREEN = Color.FromArgb(255, 0, 255, 0);
        public static Color BLUE = Color.FromArgb(255, 0, 0, 255);
        public static Color BLACK = Color.FromArgb(255, 0, 0, 0);
        public static Color WHITE = Color.FromArgb(255, 255, 255, 255);

        public static Node FindStartingLocation(Bitmap maze)
        {
            if (maze == null)
                return null;
            for (int i = 1; i < maze.Height; i++)
            {
                for (int j = 1; j < maze.Width; j++)
                {
                    if (maze.GetPixel(i, j) == BLUE)
                    {
                        return new Node(i, j, 0);
                    }
                }
            }
            return null;
        }
        public static string GenerateKey(int x, int y)
        {
            return x.ToString() + y.ToString();
        }
  

        //todo some more universal starting apps
    }
}
