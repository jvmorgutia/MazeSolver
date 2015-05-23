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

            ValidateArguments(args); //If arguments are invalid, program exits with error.
            Bitmap image = new Bitmap(args[0]);
            MazeSolver mazeSolver = new MazeSolver(image, RED, BLUE, BLACK, GREEN);

            if (!mazeSolver.FindPath()) //Finds a solution, if none is found program exits with error.
                Printer.ErrorAndExit(ErrorType.NoPathFound);
            if (!mazeSolver.TrySaveImage(args[1])) //Attempts to save the image.
                Printer.ErrorAndExit(ErrorType.SaveError);

            Console.WriteLine("Success! Image has been saved."); 
        }
        private static void ValidateArguments(string[] args)
        {
            if (args.Length != 2) //Validate that we have 2 arguments
                Printer.ErrorAndExit(ErrorType.Format);
            if (!ValidImageName(args[0]) || !ValidImageName(args[1]))
                Printer.ErrorAndExit(ErrorType.InvalidArg);
            if (!File.Exists(args[0]))
                Printer.ErrorAndExit(ErrorType.FileNotFound);
        }
        private static bool ValidImageName(string arg)
        {
            if (arg.EndsWith(".bmp") || arg.EndsWith(".jpg") || arg.EndsWith(".png"))
                return true;
            return false;
        }
    }
}
