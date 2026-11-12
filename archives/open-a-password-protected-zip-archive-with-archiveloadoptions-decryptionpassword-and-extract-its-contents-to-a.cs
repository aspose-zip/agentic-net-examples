// HOW-TO: Extract Password Protected ZIP Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (password‑protected)
            string inputPath = "protected.zip";

            // Hardcoded output folder where files will be extracted
            string outputPath = "extracted";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory (and its parent) exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(outputPath);

            // Load the password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = "YourPasswordHere"
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output folder
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
 * 1. When you need to programmatically unzip password‑protected files received from a client, such as confidential reports, using C# and Aspose.Zip.
 * 2. When an automated deployment script must decrypt and extract a secured ZIP package containing configuration files before copying them to a server.
 * 3. When a desktop application processes encrypted backup archives and extracts their contents to a user‑specified directory for restoration.
 * 4. When a data‑processing pipeline receives daily password‑protected ZIP shipments and must decrypt and extract them for further analysis.
 * 5. When a scheduled task extracts daily encrypted log archives to a central folder for archiving or monitoring purposes.
 */
