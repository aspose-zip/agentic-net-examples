// HOW-TO: Extract Specific Folder from 7z Stream and Save as Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sevenZPath = "input.7z";
            string outputZipPath = "output.zip";
            string folderToExtract = "FolderToExtract";

            // Validate input file
            if (!File.Exists(sevenZPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Temporary folder for extraction
            string tempExtractFolder = Path.Combine(Path.GetTempPath(), "SevenZipExtractTemp");
            Directory.CreateDirectory(tempExtractFolder);

            // Extract the entire 7z archive to the temporary folder
            using (FileStream sevenZStream = new FileStream(sevenZPath, FileMode.Open, FileAccess.Read))
            using (SevenZipArchive sevenZip = new SevenZipArchive(sevenZStream))
            {
                sevenZip.ExtractToDirectory(tempExtractFolder);
            }

            // Determine the specific folder to re-zip
            string sourceFolder = Path.Combine(tempExtractFolder, folderToExtract);
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Folder not found in archive: {folderToExtract}");
                return;
            }

            // Create ZIP archive from the extracted folder
            using (Archive zipArchive = new Archive())
            {
                zipArchive.CreateEntries(sourceFolder);
                zipArchive.Save(outputZipPath);
            }

            // Clean up temporary extraction folder
            Directory.Delete(tempExtractFolder, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to give a client a downloadable ZIP that contains only one project folder stored inside a large 7z backup.
 * 2. When a web service receives a 7z file via an API stream and must extract a particular subdirectory for further processing.
 * 3. When automating migration of legacy 7z archives to modern ZIP packages while preserving only the required folder.
 * 4. When creating a temporary extraction environment to isolate a specific folder from a 7z archive before re‑compressing it for email attachment.
 * 5. When integrating Aspose.Zip into a CI pipeline to pull a configuration folder out of a 7z artifact and package it as a ZIP for deployment.
 */
