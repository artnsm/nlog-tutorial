using System;
using NLog;

namespace NLogConsoleApp
{
    class Program
    {
        // Create a static logger instance for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Application entry point. Handles user input, performs division, and logs events.
        /// </summary>
        /// <param name="args">Command-line arguments (not used)</param>
        static void Main(string[] args)
        {
            logger.Info("Application started"); // Log application start

            try
            {
                // Prompt user for input
                Console.WriteLine("Enter two numbers to divide:");
                Console.Write("First number: ");
                int x = int.Parse(Console.ReadLine()); // Read first number
                logger.Debug($"First number entered: {x}");

                Console.Write("Second number: ");
                int y = int.Parse(Console.ReadLine()); // Read second number
                logger.Debug($"Second number entered: {y}");

                var result = x / y; // Perform division
                logger.Debug($"Division result: {result}");
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                // Log any exception that occurs during division
                logger.Error(ex, "Something went wrong during division");
            }

            logger.Warn("This is a warning example"); // Log a warning message
            logger.Fatal("This is a fatal error example"); // Log a fatal error message

            logger.Info("Application ended"); // Log application end
        }
    }
}
