// HOW-TO: Stream Large CSV File into ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CSV file path
            string inputPath = @"C:\Data\large.csv";
            // Hardcoded output ZIP file path
            string outputPath = @"C:\Output\csvArchive.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the CSV file for reading
            using (FileStream sourceStream = File.OpenRead(inputPath))
            {
                // Create the ZIP archive and add the CSV entry
                using (Archive archive = new Archive())
                {
                    // The entry name inside the ZIP
                    string entryName = "large.csv";

                    // Add the CSV stream as a new entry
                    archive.CreateEntry(entryName, sourceStream);

                    // Save the archive to the output file
                    using (FileStream zipFileStream = File.Open(outputPath, FileMode.Create))
                    {
                        archive.Save(zipFileStream);
                    }
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
 * 1. When you need to compress a massive CSV log file without loading it entirely into memory, you can stream it directly into a ZIP entry.
 * 2. When generating downloadable data packages for users, you can create a ZIP containing the CSV on the fly to reduce bandwidth.
 * 3. When automating nightly backups of exported database tables, you can archive each CSV into a ZIP file using Aspose.Zip for reliable storage.
 * 4. When sending large CSV reports via email attachments, you can first zip the file to stay within attachment size limits.
 * 5. When integrating with a cloud storage pipeline that expects compressed files, you can stream the CSV into a ZIP before uploading.
 */
