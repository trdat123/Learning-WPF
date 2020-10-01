using System;
using System.IO;

namespace base_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read a text file in MyDocuments folder and print to the console
            string read = File.ReadAllText(@"c:\Users\Tr Dat\Documents\New Text Document.txt");
            System.Console.WriteLine(read);
        }
    }
}
