// HOW-TO: Extract Encrypted Uncompressed ZIP Files with Password in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "encrypted.zip";
        string outputDirectory = "ExtractedFiles";

        try
        {
            // Verify input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Set up load options with the archive password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "Password123";

            // Open the ZIP archive stream
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the encrypted archive using the password
                using (Archive archive = new Archive(zipStream, loadOptions))
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically unzip a password‑protected archive received from a client and save its contents to a server folder.
 * 2. When an automated backup system must retrieve files from an encrypted ZIP created without compression before processing them.
 * 3. When a desktop application has to open a secure, uncompressed ZIP package and extract all documents for user viewing.
 * 4. When a CI/CD pipeline extracts configuration files from a protected ZIP to deploy them to a test environment.
 * 5. When a data migration tool reads a password‑protected ZIP archive and writes the extracted files to a new directory for further analysis.
 */
