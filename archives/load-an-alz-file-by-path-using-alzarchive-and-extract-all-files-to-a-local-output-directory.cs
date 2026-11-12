// HOW-TO: Extract All Files from an ALZ Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Input\sample.alz";
            string outputPath = @"C:\Output\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            using (IArchive archive = ArchiveFactory.GetArchive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a compressed ALZ backup from a third‑party system and need to programmatically unpack its contents to a local directory using C#.
 * 2. When an automated deployment pipeline must extract configuration files stored in an ALZ package before copying them to target servers.
 * 3. When a desktop application allows users to open ALZ archives and view or edit the extracted files without manual extraction tools.
 * 4. When you need to validate the integrity of an ALZ archive by extracting all entries and checking their presence in a specified output folder.
 * 5. When a scheduled service processes incoming ALZ reports, extracts the data files, and stores them in a structured directory for further analysis.
 */
