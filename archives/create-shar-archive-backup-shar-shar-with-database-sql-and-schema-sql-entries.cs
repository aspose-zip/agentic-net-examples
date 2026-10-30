// HOW-TO: Create SHAR Archive With Multiple SQL Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Data\database.sql";
            string inputPath2 = @"C:\Data\schema.sql";
            string outputPath = @"C:\Backup\backup_shar.shar";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create SHAR archive and add entries
            using (Archive archive = new Archive())
            {
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("database.sql", fs1);
                }

                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("schema.sql", fs2);
                }

                // Save the archive
                archive.Save(outputPath);
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
 * 1. When you need to bundle a database dump and its schema into a single SHAR archive for easy distribution or version control.
 * 2. When automating nightly backups of SQL scripts and want to store them in a portable SHAR file using C#.
 * 3. When deploying a database migration package and require a simple, non‑binary archive that can be unpacked on Unix systems.
 * 4. When creating a lightweight archive of SQL files without compression to preserve original file timestamps for auditing.
 * 5. When integrating Aspose.Zip into a .NET application to programmatically generate SHAR archives for archiving or transfer.
 */
