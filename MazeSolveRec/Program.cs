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
        public static Color RED = Color.FromArgb(255, 255, 0, 0);   //Start Color
        public static Color BLUE = Color.FromArgb(255, 0, 0, 255);  //End Color
        public static Color BLACK = Color.FromArgb(255, 0, 0, 0);   //Wall Color
        public static Color GREEN = Color.FromArgb(255, 0, 255, 0); //Path Color
        
        static void Main(string[] args)
        {

            ValidateArguments(args);
            Bitmap image = new Bitmap(args[0]);
            MazeSolver mazeSolver = new MazeSolver(image, RED,  BLUE, BLACK, GREEN);
            mazeSolver.Solve();
            mazeSolver.SaveImage(args[1]);                
        }
        private static void ValidateArguments(string[] args)
        {
            if (args.Length < 2)
                Printer.PrintError(ErrorType.Format);
            if (!File.Exists(args[0]) || !ValidImageName(args[0]) || !ValidImageName(args[1]))
            {
                Printer.PrintError(ErrorType.InvalidArg);
            }
        }
        private static bool ValidImageName(string arg)
        {
            if (arg.EndsWith(".bmp") || arg.EndsWith(".jpg") || arg.EndsWith(".png"))
                return true;
            return false;
        }
    }
}
