// HOW-TO: Create Zip Archive of Folder Recursively With Custom Compression In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output ZIP file paths
            string inputDirectory = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Archive\output.zip";

            // Verify the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create custom compression settings
            EnhancedDeflateCompressionSettings compressionSettings = new EnhancedDeflateCompressionSettings();

            // Configure entry settings to use the custom compression
            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(compressionSettings);

            // Create the ZIP archive with the specified entry settings
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive(entrySettings))
            {
                // Add the entire directory recursively
                DirectoryInfo directoryInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(directoryInfo);

                // Save the archive to the output file
                archive.Save(zipStream);
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
 * 1. When you need to back up an entire project folder, including all subfolders, into a single ZIP file while controlling the compression level using Aspose.Zip in C#.
 * 2. When you want to package log files generated daily into a compressed archive for long‑term storage without losing NTFS metadata.
 * 3. When a deployment script must create a distributable ZIP of a web application’s source tree with custom deflate settings to reduce download size.
 * 4. When an automated backup service has to archive user data directories on Windows, preserving attributes and applying enhanced compression for faster transfers.
 * 5. When a file‑migration tool needs to compress a large directory hierarchy into a ZIP archive before uploading it to cloud storage, using C# and Aspose.Zip’s entry settings.
 */
