using System;
using System.IO;

namespace base_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //List all file in your MyDocuments folder
            string[] filePaths = Directory.GetFiles(@"c:\Users\Tr Dat\Documents\");
            foreach (var file in filePaths)
            {
                System.Console.WriteLine(file);
            }
        }
    }
}
