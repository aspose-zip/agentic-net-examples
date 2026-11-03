// HOW-TO: Create Password Protected ZIP with Traditional Encryption in C# (Aspose.ZIP for .NET)
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
            // Input file paths (hard‑coded)
            string inputFile1 = "input/file1.txt";
            string inputFile2 = "input/file2.txt";
            string inputFile3 = "input/file3.txt";

            // Output ZIP path (hard‑coded)
            string outputPath = "output/protected.zip";

            // Password for traditional encryption
            string password = "Secret123";

            // Validate input files
            if (!File.Exists(inputFile1)) { Console.Error.WriteLine($"File not found: {inputFile1}"); return; }
            if (!File.Exists(inputFile2)) { Console.Error.WriteLine($"File not found: {inputFile2}"); return; }
            if (!File.Exists(inputFile3)) { Console.Error.WriteLine($"File not found: {inputFile3}"); return; }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Create output stream
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            {
                // Archive with traditional encryption settings
                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(null, new TraditionalEncryptionSettings(password));
                using (Archive archive = new Archive(entrySettings))
                {
                    // Add files
                    FileInfo source1 = new FileInfo(inputFile1);
                    FileInfo source2 = new FileInfo(inputFile2);
                    FileInfo source3 = new FileInfo(inputFile3);

                    archive.CreateEntry("file1.txt", source1);
                    archive.CreateEntry("file2.txt", source2);
                    archive.CreateEntry("file3.txt", source3);

                    // Save the archive
                    archive.Save(zipStream);
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
 * 1. When you need to securely distribute multiple files to clients by encrypting them with a password using C#.
 * 2. When you must generate a ZIP archive that is compatible with older ZIP utilities that only support traditional encryption.
 * 3. When an automated build or deployment pipeline has to bundle configuration or log files into a protected archive before uploading to a server.
 * 4. When a desktop or web application needs to create a downloadable package that hides its contents from unauthorized users without requiring external tools.
 * 5. When a backup script requires creating a simple password‑protected ZIP to store sensitive documents while keeping the process lightweight.
 */
