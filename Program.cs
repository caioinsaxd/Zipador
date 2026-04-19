using Zipador.Commands;

namespace Zipador;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            RunInteractive();
            return;
        }

        RunCommandLine(args);
    }

    private static void RunInteractive()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("       Zipador - ZIP Compression Tool");
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("Type 'help' for commands, 'exit' to quit.");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Zipador> ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            input = input.Trim();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                ShowHelp();
                continue;
            }

            var parts = ParseArguments(input);
            if (parts.Length == 0)
                continue;

            RunCommandLine(parts);
        }
    }

    private static void RunCommandLine(string[] args)
    {
        var command = args[0].ToLowerInvariant();
        var commandArgs = args.Length > 1 ? args[1..] : Array.Empty<string>();

        switch (command)
        {
            case "compress":
                CompressCommand.Execute(commandArgs);
                break;
            case "extract":
                ExtractCommand.Execute(commandArgs);
                break;
            case "list":
            case "--list":
            case "-l":
                ListCommand.Execute(commandArgs);
                break;
            case "help":
            case "--help":
            case "-h":
                ShowHelp();
                break;
            case "exit":
            case "quit":
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Unknown command: {command}");
                Console.WriteLine();
                ShowHelp();
                Environment.Exit(1);
                break;
        }
    }

    private static string[] ParseArguments(string input)
    {
        var args = new List<string>();
        var current = "";
        var inQuotes = false;

        foreach (var c in input)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ' ' && !inQuotes)
            {
                if (!string.IsNullOrEmpty(current))
                {
                    args.Add(current);
                    current = "";
                }
            }
            else
            {
                current += c;
            }
        }

        if (!string.IsNullOrEmpty(current))
            args.Add(current);

        return args.ToArray();
    }

    private static void ShowHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("  compress <folder> -o <output.zip>  Compress a folder to ZIP");
        Console.WriteLine("  extract <archive> -o <folder>      Extract ZIP to folder");
        Console.WriteLine("  list <archive>                     List ZIP contents");
        Console.WriteLine("  help                                Show this help");
        Console.WriteLine("  exit                                Quit");
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine("  compress MyFolder -o archive.zip");
        Console.WriteLine("  extract archive.zip -o ./extracted");
        Console.WriteLine("  list archive.zip");
    }
}