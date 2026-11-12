// HOW-TO: Extract All Files from ALZ Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ALZ archive and output folder paths
            string inputPath = "C:\\Archives\\sample.alz";
            string outputPath = "C:\\Extracted\\AlzOutput";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory and its parent exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Load the ALZ archive with default options and extract all entries
            using (Archive archive = new Archive(inputPath))
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
 * 1. When you need to programmatically unpack a downloaded ALZ backup into a local directory for further processing in a .NET application.
 * 2. When an automated deployment script must extract configuration files stored in an ALZ package before copying them to a server.
 * 3. When a desktop utility needs to read user‑provided ALZ archives and save their contents to a chosen folder without custom load settings.
 * 4. When a data migration tool has to bulk‑extract all entries from an ALZ archive to feed them into a database pipeline.
 * 5. When a scheduled service monitors a folder for new ALZ files and extracts each archive to a target directory for archival or analysis.
 */
