// HOW-TO: Add Files From Nested ZIP Into Main Archive Under New Folder C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string mainArchivePath = "input/main.zip";
            string nestedArchivePath = "input/nested.zip";
            string outputArchivePath = "output/updated_main.zip";

            // Temporary folder for extracting the nested archive
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "NestedExtract");

            // Validate input files
            if (!File.Exists(mainArchivePath))
            {
                Console.Error.WriteLine($"File not found: {mainArchivePath}");
                return;
            }
            if (!File.Exists(nestedArchivePath))
            {
                Console.Error.WriteLine($"File not found: {nestedArchivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));
            // Ensure temporary extraction directory exists
            Directory.CreateDirectory(tempExtractDir);

            // Open both archives
            using (Archive mainArchive = new Archive(mainArchivePath))
            using (Archive nestedArchive = new Archive(nestedArchivePath))
            {
                // Extract all files from the nested archive to the temporary folder
                nestedArchive.ExtractToDirectory(tempExtractDir);

                // Add each extracted file to the main archive under a new folder "NestedFiles"
                string[] extractedFiles = Directory.GetFiles(tempExtractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in extractedFiles)
                {
                    // Compute the path of the file relative to the temporary folder
                    string relativePath = Path.GetRelativePath(tempExtractDir, filePath);
                    // Build the entry name inside the ZIP (use forward slashes)
                    string entryName = ("NestedFiles/" + relativePath).Replace('\\', '/');
                    // Add the file as a new entry in the main archive
                    mainArchive.CreateEntry(entryName, filePath);
                }

                // Save the updated main archive to the output path
                mainArchive.Save(outputArchivePath);
            }

            // Clean up the temporary extraction folder
            Directory.Delete(tempExtractDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge the contents of a secondary ZIP file into an existing archive without overwriting the original files.
 * 2. When you want to package extracted resources from a nested archive into a specific subfolder of a master ZIP for distribution.
 * 3. When automating deployment, you may extract configuration files from a bundled archive and embed them into the main package under a dedicated folder.
 * 4. When consolidating multiple backup archives, you can pull files from a nested ZIP and store them in a new folder inside the primary backup archive.
 * 5. When creating a composite archive for a software installer, you can include assets from a nested ZIP into the main installer archive under a separate directory.
 */
