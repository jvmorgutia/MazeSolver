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
        FileNotFound,
        NoPathFound,
        SaveError,
        Unknown
    }
    public class Printer
    {
        //Calls System.Environment.Exit() after printing an error call to the Console.
        public static void ErrorAndExit(ErrorType error)
        {
            switch (error)
            {
                case ErrorType.Format:
                    Console.WriteLine("Argument format is incorrect. The program will now exit\n");
                    break;
                case ErrorType.InvalidArg:
                    Console.WriteLine("Arguments could not be validated. The program will now exit\n");
                    break;
                case ErrorType.FileNotFound:
                    Console.WriteLine("The specified image could not be found. The program will now exit\n");
                    break;
                case ErrorType.NoPathFound:
                    Console.WriteLine("Error: No path was found.\n");
                    break;
                case ErrorType.SaveError:
                    Console.WriteLine("Error: Path could not be saved. \nPlease Make sure you can write to this location. The program will now exit\n");
                    break;
                case ErrorType.Unknown:
                    Console.WriteLine("An unknown error has occured. The program will now exit\n");
                    break;
            }
            System.Environment.Exit(1);
        }
    }
}
