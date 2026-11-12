// HOW-TO: Create Self‑Extracting EXE Archive From Folder Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\Input";
            string outputPath = @"C:\Data\Output\MyArchive.exe";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Self‑extracting archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a set of files into a single executable that users can run to extract the contents without installing any unzip software.
 * 2. When you want to automate the creation of a self‑extracting installer for internal tools that must be delivered over a network share.
 * 3. When you have log files or diagnostic data that must be sent to support staff as a single .exe package that extracts itself on the recipient’s machine.
 * 4. When you are building a backup script that creates a portable, self‑extracting archive of a directory for quick restoration on Windows systems.
 * 5. When you need to generate a self‑extracting archive as part of a CI/CD pipeline to distribute compiled assets to end‑users who may not have compression utilities.
 */
