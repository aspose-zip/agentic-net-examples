// HOW-TO: Extract Encrypted ZIP Archive With Password Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "EncryptedArchive.zip";
            string outputPath = "SecureZipOutput";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Set up load options with the archive password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "Secure!Zip";

            // Open the encrypted ZIP archive and extract its contents
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unzip a password‑protected archive received from a client.
 * 2. When automating deployment scripts that must extract secured backup files on a server.
 * 3. When building a desktop utility that reads encrypted user data bundles and stores them locally.
 * 4. When integrating with a third‑party system that supplies confidential reports in encrypted ZIP format.
 * 5. When creating a scheduled job that processes and extracts protected log archives for analysis.
 */
