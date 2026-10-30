// HOW-TO: Create XAR Archive with Zlib and Stored Entries in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string textFilePath = "input.txt";
            string htmlFilePath = "input.html";
            string xarOutputPath = "output.xar";

            // Validate input files
            if (!File.Exists(textFilePath))
            {
                Console.Error.WriteLine($"File not found: {textFilePath}");
                return;
            }
            if (!File.Exists(htmlFilePath))
            {
                Console.Error.WriteLine($"File not found: {htmlFilePath}");
                return;
            }

            // Create compression settings
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            // MemoryStream to hold the XAR archive
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create XAR archive with default (Zlib) compression
                using (XarArchive archive = new XarArchive(defaultCompression))
                {
                    // Add Zlib-compressed entry
                    archive.CreateEntry("text.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);

                    // Add stored (no compression) entry
                    XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
                    archive.CreateEntry("page.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);

                    // Save archive to the memory stream
                    archive.Save(memoryStream);
                }

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(xarOutputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                // Write the XAR bytes to a file
                byte[] xarBytes = memoryStream.ToArray();
                File.WriteAllBytes(xarOutputPath, xarBytes);
            }

            Console.WriteLine("XAR archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a text file and an HTML file into a single XAR archive, applying Zlib compression to the text while storing the HTML without compression for efficient distribution.
 * 2. When you want to build the XAR archive in memory first, then write the resulting bytes to a file to avoid creating intermediate temporary files on disk.
 * 3. When your application must preserve the exact size and format of certain files (e.g., HTML) while still compressing other files to reduce overall archive size.
 * 4. When you are developing a C# solution that programmatically creates XAR archives using Aspose.Zip for .NET for cross‑platform deployment or backup purposes.
 * 5. When you need to validate the existence of source files and generate a custom XAR archive layout with mixed compression settings before persisting it locally.
 */
