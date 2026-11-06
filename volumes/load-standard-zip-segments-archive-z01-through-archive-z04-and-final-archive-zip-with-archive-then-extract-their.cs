// HOW-TO: Extract Split ZIP Archive Segments With Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input segment files (split ZIP) and final archive file
            string segmentPath1 = "archive.z01";
            string segmentPath2 = "archive.z02";
            string segmentPath3 = "archive.z03";
            string segmentPath4 = "archive.z04";
            string finalArchivePath = "archive.zip";

            // Verify each segment exists
            if (!File.Exists(segmentPath1))
            {
                Console.Error.WriteLine($"File not found: {segmentPath1}");
                return;
            }
            if (!File.Exists(segmentPath2))
            {
                Console.Error.WriteLine($"File not found: {segmentPath2}");
                return;
            }
            if (!File.Exists(segmentPath3))
            {
                Console.Error.WriteLine($"File not found: {segmentPath3}");
                return;
            }
            if (!File.Exists(segmentPath4))
            {
                Console.Error.WriteLine($"File not found: {segmentPath4}");
                return;
            }
            if (!File.Exists(finalArchivePath))
            {
                Console.Error.WriteLine($"File not found: {finalArchivePath}");
                return;
            }

            // Output directory for extracted files
            string outputDirectory = "Extracted";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Load the split ZIP archive (Aspose.Zip automatically handles the preceding segments)
            using (Archive archive = new Archive(finalArchivePath))
            {
                // Iterate through all entries in the combined archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories; only extract files
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Build the full path for the extracted file
                    string destinationPath = Path.Combine(outputDirectory, entry.Name);

                    // Ensure the target subdirectory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                    // Extract the entry to the destination file
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = File.Create(destinationPath))
                    {
                        entryStream.CopyTo(fileStream);
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
 * 1. When you receive a large ZIP file that was split into .z01‑.z04 parts and need to combine and extract its contents programmatically in a C# application.
 * 2. When automating deployment scripts that must unpack multi‑segment backup archives on a Windows server using Aspose.Zip.
 * 3. When building a file‑recovery tool that validates the presence of all split archive pieces before extracting the original files.
 * 4. When integrating a .NET service that processes archived data received via email attachments split into multiple ZIP segments.
 * 5. When creating a desktop utility that extracts split ZIP archives into a specific output folder without manual reassembly.
 */
