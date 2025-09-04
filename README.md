# NLogConsoleApp — Beginner-friendly README

**One‑line:** A tiny .NET 8 console app that demonstrates how to add and configure NLog for structured logging (console + file), how to log at different levels, and how to log exceptions.

---

## Table of contents

1. [What this repository contains](#what-this-repository-contains)
2. [Prerequisites](#prerequisites)
3. [Quick start (dotnet CLI)](#quick-start-dotnet-cli)
4. [Quick start (Visual Studio)](#quick-start-visual-studio)
5. [How the sample works (walkthrough)](#how-the-sample-works-walkthrough)
6. [NLog.config — what to change](#nlogconfig---what-to-change)
7. [Add NLog to your own project](#add-nlog-to-your-own-project)
8. [Optional: use Microsoft.Extensions.Logging / DI](#optional-use-microsoftextensionslogging--di)
9. [Troubleshooting & tips](#troubleshooting--tips)
10. [Contributing / License / Contact](#contributing--license--contact)

---

## What this repository contains

* `NLogConsoleApp/` — a tiny example console app (Program.cs) using NLog to log events and exceptions.
* `NLog.config` — XML configuration file that defines targets (console + file) and rules.
* `NLog-Tutorial.sln` — solution file (open with Visual Studio or use dotnet CLI).

> See the `NLogConsoleApp` project for the concrete code that demonstrates: creating a `Logger`, logging at different levels, reading user input and logging a result, and catching+logging exceptions.

---

## Prerequisites

* **.NET 8 SDK** installed (or a matching SDK version that the solution targets).
* Visual Studio 2022 or later (recommended) *or* any editor/IDE + `dotnet` CLI.
* Internet connection to restore NuGet packages

---

## Quick start (dotnet CLI)

1. Clone the repository:

```bash
git clone https://github.com/artnsm/nlog-tutorial.git
cd nlog-tutorial
```

2. Restore packages and build:

```bash
dotnet restore
dotnet build
```

3. Run the sample project (from repo root):

```bash
dotnet run --project NLogConsoleApp
```

4. Try it:

* The app will prompt: `Enter two numbers to divide:`
* Provide two integers (e.g. `12` and `3`) — you should see the console output and log entries.

By default this project includes an `NLog.config` that writes to both console and a file (check the file path in `NLog.config`).

---

## Quick start (Visual Studio)

1. Open `NLog-Tutorial.sln` in Visual Studio 2022 or later.
2. Let NuGet restore packages automatically.
3. Set `NLogConsoleApp` as the startup project and run (F5 / Ctrl+F5).

---

## How the sample works (walkthrough)

Key points in the sample application:

* A logger is created (typical pattern):

```csharp
private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

logger.Info("Application started");
```

* The app asks for two numbers, parses them, performs a division, logs the input and the result, then exits.
* If parsing or division fails (e.g. invalid input, divide-by-zero), the exception is caught and logged with the exception object — so stack trace and details are included in the log.

This is a minimal but practical pattern for instrumenting an application: small number of well-placed `Info/Debug/Error` calls and always log exceptions with the exception object.

---

## `NLog.config` — what to change

`NLog.config` controls *where* logs go (targets), *what* gets logged (rules/levels), and *how* they look (layout).

Typical things you might want to update:

* **Targets**: console, file, database, etc. (for this example the default is console + file).
* **File path**: adjust file target `fileName` to a folder where your app can write (e.g. `logs/app.log`).
* **Log level**: change the rule `minLevel` to `Info`, `Debug`, `Warn`, etc.
* **Layout**: use `${longdate}|${level}|${logger}|${message} ${exception:format=ToString}` or JSON layouts for structured logs.

**Minimal example `NLog.config` snippet** (replace or compare with the one in this repo):

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <targets>
    <target name="console" xsi:type="Console" />
    <target name="file" xsi:type="File" fileName="logs/app.log" layout="${longdate}|${level:uppercase=true}|${logger}|${message} ${exception:format=ToString}" />
  </targets>

  <rules>
    <!-- all logs to file -->
    <logger name="*" minlevel="Debug" writeTo="file" />
    <!-- show Info+ in console -->
    <logger name="*" minlevel="Info" writeTo="console" />
  </rules>
</nlog>
```

**Important:** In Visual Studio set the `NLog.config` file's property **Copy to Output Directory** to `Copy if newer` (or `Copy always`) so the config is available at runtime.

---

## Add NLog to your own project

From your project directory you can add the packages using the `dotnet` tool:

```bash
dotnet add package NLog
dotnet add package NLog.Extensions.Logging
```

The `NLog.Extensions.Logging` package integrates NLog with the Microsoft logging abstractions (ILogger).

If you prefer using Visual Studio: open **Manage NuGet Packages** for your project and install **NLog** and **NLog.Extensions.Logging**.

---

## Optional: use Microsoft.Extensions.Logging / DI (recommended for larger apps)

If you're writing a larger console app or service and use the `Host` pattern / dependency injection, integrate NLog like this:

```csharp
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging => {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Debug);
    })
    .UseNLog() // from NLog.Extensions.Logging
    .Build();
```

This approach gives you typed `ILogger<T>` injections and works well for apps that already use `Host`/DI.

---

## Troubleshooting & tips

* If you don't see file logs, check the file path in `NLog.config` and make sure the app has write permission to that folder.
* If NLog appears ignored, ensure `NLog.config` is copied to output (see note above) or explicitly load it with `LogManager.LoadConfiguration("NLog.config");` early in `Main()`
* When debugging logging rules, set `throwConfigExceptions="true"` on the `<nlog>` element temporarily so configuration errors are visible.
* Consider using JSON layout for structured logs if you plan to ship logs into a log aggregator.

---

## Contributing

1. Fork the repository
2. Create a branch `fix/readme-typo` or `enhance/readme-setup` etc.
3. Edit README or sample code
4. Submit a pull request describing what you changed and why

---

## License

This repository is provided for educational purposes. (Add a license file if you want to make this explicit.)

---

## Contact

If you want changes to the README (shorter/longer / more code examples / PR for copying the new README into the repo), tell me what to emphasize and I’ll update it.

*Happy logging!*
