using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MazeCraze
{
    
    class Program
    {
        public static Color RED = Color.FromArgb(255, 255, 0, 0);
        public static Color GREEN = Color.FromArgb(255, 0, 255, 0);
        public static Color BLUE = Color.FromArgb(255, 0, 0, 255);
        public static Color BLACK = Color.FromArgb(255, 0, 0, 0);
        static void Main(string[] args)
        {

            //-----------------------
            //Validate Arguments
            if (args.Length < 2)
                Printer.PrintError(ErrorType.Format);
            if (!IsValidArgument(args[0]) || !IsValidArgument(args[1]))
            {
                Printer.PrintError(ErrorType.InvalidArg);
            }
            //------------------------

            Bitmap image = new Bitmap(args[0]);
            MazeSolver solver = new MazeSolver(image, RED,  BLUE, BLACK, GREEN);
            solver.SaveImage(args[1]);
                
        }
        private static bool IsValidArgument(string arg)
        {
            // TODO better file validation
            if (arg.EndsWith(".bmp") || arg.EndsWith(".bmp") || arg.EndsWith(".png"))
                return true;
            return false;
        }
    }
}
