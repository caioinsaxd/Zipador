using Zipador.Services;

namespace Zipador.Commands;

public class CompressCommand
{
    public static void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: zipador compress <source-folder> -o <output.zip>");
            return;
        }

        string? source = null;
        string? output = null;

        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i];

            if (arg == "-o" && i + 1 < args.Length)
            {
                output = args[i + 1];
                i++;
            }
            else if (arg.StartsWith("-o"))
            {
                output = arg.Substring(2);
            }
            else if (!arg.StartsWith("-") && source == null)
            {
                source = arg;
            }
        }

        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(output))
        {
            Console.WriteLine("Error: Source folder and output file are required.");
            Console.WriteLine("Usage: zipador compress <source-folder> -o <output.zip>");
            return;
        }

        try
        {
            var service = new ArchiveService();
            service.Compress(source, output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}