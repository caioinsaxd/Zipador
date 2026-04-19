using Zipador.Services;

namespace Zipador.Commands;

public class ListCommand
{
    public static void Execute(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: zipador list <archive-file>");
            return;
        }

        string archive = args[0];

        try
        {
            var service = new ArchiveService();
            service.List(archive);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}