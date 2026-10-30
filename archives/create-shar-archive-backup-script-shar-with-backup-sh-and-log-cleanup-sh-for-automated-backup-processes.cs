// HOW-TO: Create SHAR Archive with Multiple Shell Scripts Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string backupScriptPath = "backup.sh";
            string logCleanupPath = "log_cleanup.sh";

            // Verify input files exist
            if (!File.Exists(backupScriptPath))
            {
                Console.Error.WriteLine($"File not found: {backupScriptPath}");
                return;
            }
            if (!File.Exists(logCleanupPath))
            {
                Console.Error.WriteLine($"File not found: {logCleanupPath}");
                return;
            }

            // Hardcoded output archive path
            string outputPath = "backup_script.shar";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create the archive and add entries
            using (Archive archive = new Archive())
            {
                // Add backup.sh
                archive.CreateEntry("backup.sh", new FileInfo(backupScriptPath));

                // Add log_cleanup.sh
                archive.CreateEntry("log_cleanup.sh", new FileInfo(logCleanupPath));

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
 * 1. When you need to bundle several Linux backup scripts into a single SHAR file for easy distribution using C#.
 * 2. When automating deployment of shell scripts and want to create the archive programmatically without relying on external command‑line tools.
 * 3. When you must verify that required script files exist before packaging them into a portable archive in a .NET application.
 * 4. When you want to generate a SHAR archive on the fly and save it to a specific folder, ensuring the output directory is created automatically.
 * 5. When handling errors during archive creation and need to log missing files or exceptions while using Aspose.Zip in a C# backup utility.
 */
