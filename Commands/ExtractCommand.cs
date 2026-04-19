using Zipador.Services;

namespace Zipador.Commands;

public class ExtractCommand
{
    public static void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: zipador extract <archive-file> -o <destination-folder>");
            return;
        }

        string? archive = null;
        string? destination = null;

        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i];

            if (arg == "-o" && i + 1 < args.Length)
            {
                destination = args[i + 1];
                i++;
            }
            else if (arg.StartsWith("-o"))
            {
                destination = arg.Substring(2);
            }
            else if (!arg.StartsWith("-") && archive == null)
            {
                archive = arg;
            }
        }

        if (string.IsNullOrEmpty(archive) || string.IsNullOrEmpty(destination))
        {
            Console.WriteLine("Error: Archive file and destination folder are required.");
            Console.WriteLine("Usage: zipador extract <archive-file> -o <destination-folder>");
            return;
        }

        try
        {
            var service = new ArchiveService();
            service.Extract(archive, destination);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}