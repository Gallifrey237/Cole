using System;
using System.Collections.Generic;

namespace Cole
{
    class Program
    {

        private static Dictionary<string, string> searchReplaceDic = new Dictionary<string, string>();
        private static ConsoleKeyInfo keyInfo;
        private static string path;
        private static string inputFile;
        static void Main(string[] args)
        {

            Console.WriteLine("Please insert the file path + file");
            path = Console.ReadLine();

            using (System.IO.StreamReader stream = new System.IO.StreamReader(path))
            {
                inputFile = stream.ReadToEnd();
            }

            Console.WriteLine("First Input is the searching string");
            Console.WriteLine("Secound Input is the to replacing string");

            string tmpSearchString = string.Empty;
            string tmpRelaceString = string.Empty;


            bool repeat = true;
            do
            {

                Console.WriteLine("Search String:");
                tmpSearchString = Console.ReadLine();

                Console.WriteLine("Relace String:");
                tmpRelaceString = Console.ReadLine();

                Console.WriteLine("Press F to cancel the input and repeat");
                Console.WriteLine("Press R to continue adding");
                Console.WriteLine("Press X to finish...");

                while (keyInfo.Key != ConsoleKey.C && keyInfo.Key != ConsoleKey.X && keyInfo.Key != ConsoleKey.R)
                {
                    keyInfo = Console.ReadKey();
                }

                if (keyInfo.Key == ConsoleKey.C)
                {
                    repeat = true;
                }
                else if (keyInfo.Key == ConsoleKey.X)
                {
                    searchReplaceDic.Add(tmpSearchString, tmpRelaceString);
                    repeat = false;
                }
                else if (keyInfo.Key == ConsoleKey.R)
                {
                    searchReplaceDic.Add(tmpSearchString, tmpRelaceString);
                    repeat = true;
                }

            } while (repeat);


            foreach (var seachReplacePair in searchReplaceDic)
            {
                inputFile = inputFile.Replace(seachReplacePair.Key, seachReplacePair.Value);
            }

            try
            {
                path = path.Remove(path.LastIndexOf("\\"));
                path += "\\newFile.xml";
                
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
                {
                    writer.Write(inputFile);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}
