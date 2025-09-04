# NLogConsoleApp Tutorial

This repository demonstrates how to use [NLog](https://nlog-project.org/) for logging in a C# console application targeting **.NET 8**. It is designed as a learning resource for developers interested in structured logging, exception handling, and basic user input in .NET.

## Features

- Logging at multiple levels: Info, Debug, Warn, Error, and Fatal
- Exception handling with error logging
- User input and division operation
- NLog configuration via `NLog.config` (logs to console and file)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later
- Internet connection to restore NuGet packages

## Getting Started

1. **Clone the repository**

2. **Restore NuGet packages**
- Open the solution in Visual Studio and let it restore packages automatically
- Or run:
     ```sh
     dotnet restore
     ```

3. **Run the application**
- Enter two numbers when prompted to see logging in action.

## How It Works

- The application prompts the user for two numbers, divides them, and logs each step.
- All major events (start, end, user input, result, errors) are logged using NLog.
- Logging configuration is managed in `NLog.config`, which by default writes logs to both the console and a file.

## Learning Points

- How to set up and configure NLog in a .NET application
- How to log messages and exceptions at different severity levels
- How to handle user input and errors gracefully

## Customization

- Edit `NLog.config` to change log targets, formats, or rules.
- Extend `Program.cs` to add more logging scenarios or business logic.

## License

This project is provided for educational purposes.

---

Happy coding!