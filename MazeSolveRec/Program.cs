using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolveRec
{
    
    class Program
    {
    
        static void Main(string[] args)
        {

            if (args.Length < 2)
                PrintErrorMessage(ErrorType.Format);
            if (!IsValidArgument(args[0]) || !IsValidArgument(args[1]))
            {
                PrintErrorMessage(ErrorType.InvalidArg);
            }
            Bitmap image = new Bitmap(args[0]);
            MazeSolver solver = new MazeSolver(image);
            solver.SaveImage(args[1]);
                
        }
        private static bool IsValidArgument(string arg)
        {
            // TODO better file validation
            if (arg.EndsWith(".bmp") || arg.EndsWith(".bmp") || arg.EndsWith(".png"))
                return true;
            return false;
        }

        public static void PrintErrorMessage(ErrorType error)
        {
            switch (error) {
                case ErrorType.Format:
                    Console.WriteLine("Argument format is incorrect. Re-run the program.\n");
                    break;
                case ErrorType.InvalidArg:
                    Console.WriteLine("Arguments could not be validated. Re-run the program.\n");
                    break;
                case ErrorType.Unknown:
                    Console.WriteLine("An unknown error has occured. The program will now exit\n");
                    break;
            }
            System.Environment.Exit(1);
        }
    }
}
