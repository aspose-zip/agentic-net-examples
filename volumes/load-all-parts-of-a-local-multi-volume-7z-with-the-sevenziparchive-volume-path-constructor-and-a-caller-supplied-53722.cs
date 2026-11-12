// HOW-TO: Extract Password‑Protected Multi‑Volume 7z Archive to Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path to the first volume of the multi‑volume 7z archive
            string inputPath = @"C:\Archives\myarchive.7z.001";

            // Hardcoded output directory where files will be extracted
            string outputDir = @"C:\Archives\extracted_7z";

            // Verify that the first volume exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));
            Directory.CreateDirectory(outputDir);

            // Password for encrypted archive parts
            string password = "myPassword";

            // Load the multi‑volume 7z archive using the volume‑path constructor.
            // The constructor automatically orders the volumes numerically.
            using (SevenZipArchive archive = new SevenZipArchive(inputPath, password))
            {
                // Extract all entries to the specified directory
                archive.ExtractToDirectory(outputDir);
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
 * 1. When you receive a large encrypted 7z split across several .001, .002 files and need to programmatically combine and extract them in a .NET application.
 * 2. When an automated backup system creates password‑protected multi‑volume archives and you must restore their contents to a specific folder using C#.
 * 3. When a client provides confidential data packaged as a split 7z archive and your software must verify the first volume exists, supply the password, and extract all files.
 * 4. When you are building a file‑processing pipeline that must handle encrypted archives with an unknown number of parts and extract them without manual ordering.
 * 5. When a deployment script needs to unpack a secured multi‑part 7z package on a server, ensuring the output directory is created and the archive is opened with the correct password.
 */
