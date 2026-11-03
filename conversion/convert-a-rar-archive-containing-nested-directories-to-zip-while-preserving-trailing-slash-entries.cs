// HOW-TO: Extract Rar Archive With Nested Directories To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Data\sample.rar";
        string outputDirectory = @"C:\Data\Extracted";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        try
        {
            using (FileStream rarStream = File.OpenRead(inputPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(outputDirectory);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically unpack a downloaded RAR file that contains subfolders, preserving the original directory hierarchy.
 * 2. When an application must process legacy RAR backups on a Windows server and extract their contents to a known location for further analysis.
 * 3. When a file‑conversion tool requires extracting nested files from a RAR archive before re‑compressing them into another format such as ZIP.
 * 4. When an automated deployment script needs to unpack bundled resources packaged as RAR archives while keeping empty folder placeholders intact.
 * 5. When a data‑migration utility must read a RAR archive supplied by a third‑party vendor and extract all files and empty directories to a staging directory.
 */
