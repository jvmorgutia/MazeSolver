using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace MazeSolver
{
    class Program
    {
        static string source_name;
        static string destination_name;
        static void Main(string[] args)
        {
            if (args.Length < 2 )
            {
                PrintError();
            }
            else
            {
                if (FilenameIsValid(args[0]))
                    source_name = args[0];
                if (FilenameIsValid(args[1]))
                    destination_name = args[1];
                Bitmap source_img = new Bitmap(source_name);
           

                DateTime start, end; 
                start = DateTime.Now;
                //MARKS ALL PIXELS OF THE IMAGE RED
             
                int blackpix = 0;

                bool lastColorIsBlack = true;


                for (int i = 0; i < source_img.Width; i ++){
                    lastColorIsBlack = true;
                    for(int j = 0; j < source_img.Height; j++){
                       
                        if (source_img.GetPixel(i, j) == System.Drawing.Color.Black)
                        {
                            Console.Write("1");
                            if (blackpix != 0)
                            {
                                source_img.SetPixel(i, j - blackpix, Color.Green);
                                
                            }

                        }
                        else
                        {
                            lastColorIsBlack = false;
                        }
                            
                    }
                }
                end = DateTime.Now;
                Console.WriteLine(end - start);
                source_img.Save(destination_name);
            }

            
        }


        public static bool FilenameIsValid(string arg)
        {
            if (arg.EndsWith(".bmp") || arg.EndsWith(".bmp") || arg.EndsWith(".png"))
                return true;
            return false;
        }
        private static void PrintError()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Incorrect Syntax - Please try again\n");
            Console.WriteLine("\tmaze.exe \"source.[bmp,png,jpg]\" \"destination.[bmp,png,jpg]\"\n");
            Console.WriteLine("==========================");
        }
    }
}
