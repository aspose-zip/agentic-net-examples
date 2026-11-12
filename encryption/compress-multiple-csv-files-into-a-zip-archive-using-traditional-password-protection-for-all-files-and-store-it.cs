// HOW-TO: Compress Multiple CSV Files into Password Protected ZIP in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input CSV file paths
            string inputPath1 = @"C:\Data\file1.csv";
            string inputPath2 = @"C:\Data\file2.csv";
            string inputPath3 = @"C:\Data\file3.csv";

            // Hardcoded output ZIP file path
            string outputPath = @"C:\Data\output\encrypted.zip";

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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare FileInfo objects for source files
            FileInfo source1 = new FileInfo(inputPath1);
            FileInfo source2 = new FileInfo(inputPath2);
            FileInfo source3 = new FileInfo(inputPath3);

            // Open the output ZIP file stream
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            {
                // Create a ZIP archive with traditional encryption for all entries
                using (Archive archive = new Archive(new ArchiveEntrySettings(null, new TraditionalEncryptionSettings("MyPassword"))))
                {
                    // Add each CSV file as an entry in the archive
                    archive.CreateEntry(source1.Name, source1);
                    archive.CreateEntry(source2.Name, source2);
                    archive.CreateEntry(source3.Name, source3);

                    // Save the archive to the output stream
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
 * 1. When you need to securely bundle several CSV reports for email attachment, you can compress them into an encrypted ZIP file using Aspose.Zip in C#.
 * 2. When a data‑export service must deliver daily CSV logs to a client while preventing unauthorized access, you can create a password‑protected archive on the fly.
 * 3. When an automated backup job has to store multiple CSV data files in a single compressed file with traditional encryption for compliance, this code provides a simple solution.
 * 4. When a desktop application exports user‑generated CSV spreadsheets and wants to protect them with a single password before saving to disk, the example shows how to do it.
 * 5. When integrating with a legacy system that only accepts ZIP files with traditional password protection, you can package the required CSV files in C# using Aspose.Zip.
 */
