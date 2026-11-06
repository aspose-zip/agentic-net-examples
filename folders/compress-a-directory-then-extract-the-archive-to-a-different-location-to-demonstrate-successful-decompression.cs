// HOW-TO: Compress a Folder to ZIP and Verify Extraction in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourceDirectory = @"C:\Data\SourceFolder";
            string zipFilePath = @"C:\Data\Archive\folder.zip";
            string extractionDirectory = @"C:\Data\ExtractedFolder";

            // Validate source directory
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipFilePath));
            Directory.CreateDirectory(extractionDirectory);

            // Create ZIP archive from the source directory
            using (FileStream zipStream = File.Open(zipFilePath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo sourceInfo = new DirectoryInfo(sourceDirectory);
                archive.CreateEntries(sourceInfo);
                archive.Save(zipStream);
            }

            // Verify the ZIP file was created
            if (!File.Exists(zipFilePath))
            {
                Console.Error.WriteLine($"File not found: {zipFilePath}");
                return;
            }

            // Extract the archive to the extraction directory
            using (FileStream zipReadStream = File.Open(zipFilePath, FileMode.Open))
            using (Archive archive = new Archive(zipReadStream))
            {
                archive.ExtractToDirectory(extractionDirectory);
            }

            Console.WriteLine("Compression and extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a backup of a local folder before performing risky operations, you can compress it into a ZIP file and later extract it to confirm the backup integrity.
 * 2. When deploying a web application, you can package the content folder into a ZIP archive and extract it on the target server to ensure the deployment package is correctly structured.
 * 3. When sending a large set of files via email or file‑share, you can zip the directory and then programmatically extract it on the recipient side to automate the unpacking process.
 * 4. When archiving log files for long‑term storage, you can compress the log directory into a ZIP file and later extract it to analyze specific entries without manual handling.
 * 5. When testing file‑system utilities, you can generate a ZIP from a sample directory and immediately extract it to validate that the compression and extraction APIs work as expected.
 */
