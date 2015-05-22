using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCraze
{
    public enum ErrorType
    {
        Format,
        InvalidArg,
        NoPathFound,
        Unknown
    }
    public class Printer
    {
        public static void PrintError(ErrorType error)
        {
            switch (error)
            {
                case ErrorType.Format:
                    Console.WriteLine("Argument format is incorrect. Re-run the program.\n");
                    break;
                case ErrorType.InvalidArg:
                    Console.WriteLine("Arguments could not be validated. Re-run the program.\n");
                    break;
                case ErrorType.NoPathFound:
                    Console.WriteLine("Error: No path was found");
                    break;
                case ErrorType.Unknown:
                    Console.WriteLine("An unknown error has occured. The program will now exit\n");
                    break;               
            }
        }
    }
}
