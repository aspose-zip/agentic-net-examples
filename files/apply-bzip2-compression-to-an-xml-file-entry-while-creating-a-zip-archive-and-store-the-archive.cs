// HOW-TO: Create a ZIP Archive with BZip2 Compressed XML File in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input XML file and output ZIP archive paths
            string inputPath = @"C:\Data\sample.xml";
            string outputPath = @"C:\Output\archive.zip";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output ZIP file stream
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Open the source XML file stream
                using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                {
                    // Configure BZip2 compression for the archive entries
                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(new Bzip2CompressionSettings());

                    // Create the archive with the specified entry settings
                    using (Archive archive = new Archive(entrySettings))
                    {
                        // Add the XML file as an entry using its file name
                        archive.CreateEntry(Path.GetFileName(inputPath), source);

                        // Save the archive to the ZIP file stream
                        archive.Save(zipFile);
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
 * 1. When you need to package an XML configuration file into a ZIP while reducing its size using BZip2 compression for efficient storage or transfer.
 * 2. When you want to generate a compressed backup of XML data on a server and store it as a ZIP file using .NET.
 * 3. When you are building a C# application that must send XML reports over a network and you need to compress them with BZip2 inside a ZIP container.
 * 4. When you need to archive multiple XML logs into a single ZIP archive with BZip2 compression to meet bandwidth or disk‑space constraints.
 * 5. When you are automating the creation of deployment packages that include XML manifests and require BZip2 compression for compatibility with legacy extraction tools.
 */
