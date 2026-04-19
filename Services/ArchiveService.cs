using System.IO.Compression;

namespace Zipador.Services;

public class ArchiveService
{
    public void Compress(string sourceFolder, string outputPath)
    {
        if (!Directory.Exists(sourceFolder))
            throw new DirectoryNotFoundException($"Source folder not found: {sourceFolder}");
        
        ZipFile.CreateFromDirectory(sourceFolder, outputPath, CompressionLevel.Optimal, false);
        Console.WriteLine($"Created: {outputPath}");
    }

    public void Extract(string archivePath, string destination)
    {
        if (!File.Exists(archivePath))
            throw new FileNotFoundException($"Archive not found: {archivePath}");

        if (!Directory.Exists(destination))
            Directory.CreateDirectory(destination);

        var extension = Path.GetExtension(archivePath).ToLowerInvariant();

        if (extension == ".zip")
        {
            ZipFile.ExtractToDirectory(archivePath, destination, true);
            Console.WriteLine($"Extracted to: {destination}");
        }
        else
        {
            throw new NotSupportedException($"Unsupported archive format: {extension}");
        }
    }

    public void List(string archivePath)
    {
        if (!File.Exists(archivePath))
            throw new FileNotFoundException($"Archive not found: {archivePath}");

        var extension = Path.GetExtension(archivePath).ToLowerInvariant();

        if (extension == ".zip")
        {
            ListZip(archivePath);
        }
        else
        {
            throw new NotSupportedException($"Unsupported archive format: {extension}");
        }
    }

    private void ListZip(string archivePath)
    {
        using var archive = ZipFile.OpenRead(archivePath);

        Console.WriteLine($"Archive: {Path.GetFileName(archivePath)}");
        Console.WriteLine(new string('-', 50));

        int count = 0;
        foreach (var entry in archive.Entries)
        {
            var size = FormatSize(entry.Length);
            Console.WriteLine($"  {entry.FullName,-40} {size,10}");
            count++;
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"Total: {count} file(s)");
    }

    private static string FormatSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB" };
        int order = 0;
        double size = bytes;
        while (size >= 1024 && order < sizes.Length - 1)
        {
            order++;
            size /= 1024;
        }
        return $"{size:0.##} {sizes[order]}";
    }
}