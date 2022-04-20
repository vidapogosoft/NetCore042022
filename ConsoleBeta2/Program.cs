using System;

namespace ConsoleBeta2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cual es su nombre?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Bienvenido, {name}, el dia {currentDate:d} at {currentDate:t}!");
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
