// HOW-TO: Create Password Protected ZIP With Traditional Encryption And Nested Folders In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output zip file paths
            string inputDirectory = @"C:\Data\InputFolder";
            string outputZipPath = @"C:\Data\ProtectedArchive.zip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Open output file stream
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create archive with default entry settings that include traditional encryption
                using (Archive archive = new Archive(
                    new ArchiveEntrySettings(
                        null,
                        new TraditionalEncryptionSettings("MyPassword"))))
                {
                    // Add all files and subfolders from the input directory
                    DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                    archive.CreateEntries(dirInfo);

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
 * 1. When you need to securely distribute an entire project folder to clients, you can zip the directory with a password using traditional encryption in C#.
 * 2. When automating backup scripts that must protect confidential files, this code creates a password‑protected archive of all subfolders before storing it.
 * 3. When compliance requires archived data to be encrypted with legacy ZIP encryption, developers can generate such archives programmatically in .NET.
 * 4. When building a desktop utility that lets users select a folder and produce a single encrypted ZIP file for email attachment, this approach handles the nesting automatically.
 * 5. When integrating with third‑party tools that only understand standard ZIP encryption, you can create compatible archives with nested directory structures directly from C#.
 */
