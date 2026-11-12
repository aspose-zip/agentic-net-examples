// HOW-TO: Create Self‑Extracting Archive for Database Backup with AutoExtract in C# (Aspose.ZIP for .NET)
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
            string inputFilePath = @"C:\Data\backup.bak";
            string outputExePath = @"C:\Output\BackupExtractor.exe";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputExePath));

            SelfExtractorOptions sfxOptions = new SelfExtractorOptions();

            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = sfxOptions;

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("backup.bak", inputFilePath);
                archive.Save(outputExePath, saveOptions);
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
 * 1. When you need to distribute a SQL Server .bak file to clients who can run a single executable to automatically extract the backup without installing any extraction tools.
 * 2. When automating deployment scripts that package a database snapshot into a self‑extracting EXE for easy restoration on remote servers.
 * 3. When creating a portable backup solution that embeds the .bak file in a self‑extracting archive to simplify disaster‑recovery procedures.
 * 4. When delivering a database backup through email or download links and want the recipient to extract it with a double‑click on the generated .exe.
 * 5. When integrating backup extraction into a C# application and prefer a standalone executable that handles both compression and extraction in one step.
 */
