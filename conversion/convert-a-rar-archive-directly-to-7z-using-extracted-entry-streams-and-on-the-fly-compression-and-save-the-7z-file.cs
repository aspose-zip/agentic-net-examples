// HOW-TO: Extract RAR Archive To Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.rar";
            string outputDirectory = "extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream fileStream = File.OpenRead(inputPath))
            using (RarArchive rarArchive = new RarArchive(fileStream))
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
 * 1. When you need to programmatically unpack a downloaded .rar file on a server to process its contents in a .NET application.
 * 2. When a desktop utility must read a user‑provided RAR archive and extract files to a temporary folder for further analysis.
 * 3. When an automated build pipeline extracts third‑party resources packaged as RAR archives before compiling the project.
 * 4. When a cloud service migrates legacy RAR backups to a file system by extracting them with C# code.
 * 5. When a data‑processing script converts archived logs in RAR format into individual files for indexing and search.
 */
