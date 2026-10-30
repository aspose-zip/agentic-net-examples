// HOW-TO: Create Solid 7z Archive with Header Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define the source directory and the output archive path.
            string sourceFolder = @"C:\Data\SourceFolder";
            string archivePath = Path.Combine(@"C:\Data", "solid_archive.7z");

            // Verify that the source directory exists.
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Configure LZMA2 compression.
            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();

            // Enable solid mode and compress archive headers.
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings, null)
            {
                Solid = true,
                // Uncomment the following line if the API provides a header compression option.
                // CompressHeaders = true
            };

            // Create the 7z archive and add all files from the source folder.
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            Console.WriteLine($"Solid 7z archive created at: {archivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a large collection of log files into a single 7z archive while minimizing disk space by using solid compression.
 * 2. When you want to distribute software resources efficiently by creating a solid 7z package that compresses archive headers for faster extraction.
 * 3. When backing up a project's source code directory and you require the highest compression ratio achievable with Aspose.Zip’s solid mode.
 * 4. When archiving database export files and you need to reduce overhead by compressing both file data and archive metadata in C#.
 * 5. When automating nightly backups of a reports folder and you need a single 7z file that uses solid compression to improve storage utilization.
 */
