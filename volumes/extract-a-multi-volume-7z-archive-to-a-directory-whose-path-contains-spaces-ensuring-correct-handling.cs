// HOW-TO: Extract Multi-Volume 7z Archive To Folder With Spaces In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Archives\multi.7z.001";
            string outputPath = @"C:\Extracted Files\Output";

            // Verify the first volume of the archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the multi‑volume 7z archive (Aspose.Zip handles the remaining volumes automatically)
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                // Extract all entries to the target directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a split 7z backup that spans several .001, .002 files onto a user‑specified directory that contains spaces in its path.
 * 2. When an application must automatically locate and extract all parts of a multi‑volume archive without manually listing each volume.
 * 3. When deploying software that stores resources in a compressed multi‑part 7z file and the installation directory includes spaces, such as “Program Files”.
 * 4. When processing large data sets delivered as multi‑volume 7z archives and you need to ensure the output folder hierarchy is created even if it contains spaces.
 * 5. When handling customer‑uploaded split archives in a web service and you must extract them to a temporary folder whose path may contain spaces.
 */
