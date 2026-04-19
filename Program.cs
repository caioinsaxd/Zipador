using Zipador.Commands;

namespace Zipador;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

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
                ListCommand.Execute(commandArgs);
                break;
            case "help":
            case "--help":
            case "-h":
                ShowHelp();
                break;
            default:
                Console.WriteLine($"Unknown command: {command}");
                Console.WriteLine();
                ShowHelp();
                Environment.Exit(1);
                break;
        }
    }

    private static void ShowHelp()
    {
        Console.WriteLine("Zipador - ZIP/RAR Compression Tool");
        Console.WriteLine();
        Console.WriteLine("Tutorial:");
        Console.WriteLine("  zipador compress <source-folder> -o <output.zip>");
        Console.WriteLine("  zipador extract <archive-file> -o <destination-folder>");
        Console.WriteLine("  zipador list <archive-file>");
        Console.WriteLine("  zipador help");
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine("  zipador compress MyFolder -o archive.zip");
        Console.WriteLine("  zipador extract archive.zip -o ./extracted");
        Console.WriteLine("  zipador list archive.zip");
    }
}