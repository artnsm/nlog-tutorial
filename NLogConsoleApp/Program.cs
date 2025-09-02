using System;
using NLog;

namespace NLogConsoleApp
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Application started");

            try
            {
                Console.WriteLine("Enter two numbers to divide:");
                Console.Write("First number: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Second number: ");
                int y = int.Parse(Console.ReadLine());

                var result = x / y;
                logger.Debug($"Division result: {result}");
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Something went wrong during division");
            }

            logger.Warn("This is a warning example");
            logger.Fatal("This is a fatal error example");

            logger.Info("Application ended");
        }
    }
}
