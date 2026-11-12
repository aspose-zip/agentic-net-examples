// HOW-TO: Extract LZ4 Apple Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input Apple Archive path (LZ4 compressed)
            string inputPath = "apple_archive.lz4";

            // Hardcoded output directory for extracted files
            string outputFolder = "lz4_output";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the archive file stream
            using (FileStream fs = File.OpenRead(inputPath))
            {
                // Load the LZ4 Apple Archive
                using (Lz4Archive archive = new Lz4Archive(fs))
                {
                    // Extract all entries to the output folder
                    archive.ExtractToDirectory(outputFolder);
                }
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
 * 1. When you receive an LZ4‑compressed Apple archive from a macOS backup and need to programmatically unpack its contents into a .NET application’s output folder.
 * 2. When an automated build pipeline must extract resources stored in an Apple LZ4 archive before packaging them into a deployment bundle.
 * 3. When a cross‑platform tool needs to read and extract files from an LZ4 Apple archive on Windows using C# without relying on native macOS utilities.
 * 4. When you want to validate the integrity of an LZ4 Apple archive by extracting all entries to a temporary directory for further processing.
 * 5. When a data‑migration script must bulk‑extract files from multiple LZ4 Apple archives into a single destination folder for analysis.
 */
