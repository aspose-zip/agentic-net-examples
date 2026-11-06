// HOW-TO: Extract Encrypted Multi‑Volume ZIP Archive With Password In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing the split ZIP parts
            string inputDirectory = @"C:\Input\EncryptedMultiVolume";
            // Main segment of the multi‑volume archive
            string mainZipPath = Path.Combine(inputDirectory, "archive.zip");
            // Output folder for extraction
            string outputFolder = @"C:\Output\EncryptedZipFolder";

            // Verify the main ZIP file exists
            if (!File.Exists(mainZipPath))
            {
                Console.Error.WriteLine($"File not found: {mainZipPath}");
                return;
            }

            // Create output directory (parent directory is ensured)
            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder));

            // Collect split segment files (e.g., archive.zip.001, archive.zip.002, ...)
            string[] splitSegments = Directory.GetFiles(inputDirectory, "archive.zip.*");
            // Ensure the segments are ordered correctly
            Array.Sort(splitSegments);

            // Load options with the archive‑level password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "YourPassword";

            // Open the multi‑volume encrypted ZIP archive
            using (Archive archive = new Archive(mainZipPath, splitSegments, loadOptions))
            {
                // Extract all entries to the output folder
                archive.ExtractToDirectory(outputFolder);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a large password‑protected zip that was split into several parts and need to combine and extract its contents programmatically in a .NET application.
 * 2. When automating the deployment of confidential data packaged as an encrypted multi‑volume archive that must be unpacked on a server using C#.
 * 3. When building a backup restoration tool that must read split zip files secured with a password and restore the files to a specific directory.
 * 4. When integrating Aspose.Zip into a file‑processing pipeline to handle encrypted archives received from external partners that use split segments.
 * 5. When creating a desktop utility that extracts archived logs stored in a protected multi‑part zip without manual reassembly.
 */
