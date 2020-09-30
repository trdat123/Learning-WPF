using System;

namespace base_project
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---Small calculator---");
            System.Console.Write("Enter x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            System.Console.Write("Enter y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            var sum = x + y;
            var sub = x - y;
            var mul = x * y;
            var div = x / y;
            System.Console.WriteLine("x + y = " + sum);
            System.Console.WriteLine("x - y = " + sub);
            System.Console.WriteLine("x * y = " + mul);
            System.Console.WriteLine("x / y = " + div);
        }
    }
}
