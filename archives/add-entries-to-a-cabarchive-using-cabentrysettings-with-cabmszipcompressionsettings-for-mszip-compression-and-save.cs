// HOW-TO: Create CAB Archive With MSZip And Stored Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input files
            string singleFilePath = "sample.txt";
            string htmlFilePath = "index.html";

            // Output CAB archive
            string cabOutputPath = "output.cab";

            // Validate input files
            if (!File.Exists(singleFilePath))
            {
                Console.Error.WriteLine($"File not found: {singleFilePath}");
                return;
            }
            if (!File.Exists(htmlFilePath))
            {
                Console.Error.WriteLine($"File not found: {htmlFilePath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(cabOutputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create default settings for MSZip compression
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Create CAB archive with default settings
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add entry with default (MSZip) compression
                archive.CreateEntry("sample.txt", singleFilePath);

                // Create settings for stored (no) compression
                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());

                // Add entry with stored compression
                archive.CreateEntry("index.html", htmlFilePath, storedSettings);

                // Save the archive
                archive.Save(cabOutputPath);
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
 * 1. When you need to package installation files into a CAB archive with MSZip compression for one file and no compression for another using C#.
 * 2. When you want to generate a Windows installer cabinet that mixes compressed and uncompressed resources programmatically with Aspose.Zip for .NET.
 * 3. When you have to automate the creation of a CAB file that preserves specific compression settings per entry in a build pipeline.
 * 4. When you are building a deployment tool that must create CAB archives with custom entry settings without using external command‑line utilities.
 * 5. When you need to compress log or configuration files into a CAB archive while keeping HTML documentation uncompressed for easy viewing.
 */
