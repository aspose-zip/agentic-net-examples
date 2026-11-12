// HOW-TO: Create Apple XAR Archive With CRC32 And No Compression In C# (Aspose.ZIP for .NET)
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
            string inputFilePath = "sample.txt";
            string outputArchivePath = "appleArchive.xar";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create the XAR archive and add the entry
            using (XarArchive archive = new XarArchive())
            {
                archive.CreateEntry("sample.txt", inputFilePath);

                // Save the archive to the output file
                using (FileStream outStream = File.Open(outputArchivePath, FileMode.Create))
                {
                    archive.Save(outStream);
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
 * 1. When you need to package macOS installer files into an XAR archive while preserving a CRC32 checksum for integrity verification.
 * 2. When you want to generate an Apple XAR archive in C# without compressing the files to allow fast extraction on macOS.
 * 3. When a build pipeline must create uncompressed XAR bundles for software distribution and include checksum metadata for validation.
 * 4. When integrating Aspose.Zip for .NET to programmatically create XAR archives that conform to Apple’s archive specifications.
 * 5. When automating backup of plain text resources into an XAR file while ensuring the archive can be read by macOS tools.
 */
