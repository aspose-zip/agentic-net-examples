// HOW-TO: Extract Password Protected ZIP Archive In C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (password‑protected)
            string inputPath = "protected.zip";

            // Hardcoded output directory where files will be extracted
            string outputPath = "Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Set the password for the protected archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "myPassword";

            // Open the archive with the specified load options
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory
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
 * 1. When you need to automatically unpack confidential reports delivered as a password‑protected ZIP file in a C# backend service.
 * 2. When a desktop application must read encrypted log archives and extract their contents to a local folder using Aspose.Zip.
 * 3. When a scheduled job processes secure data bundles from partners, requiring the decryption password to extract files programmatically.
 * 4. When you want to integrate ZIP extraction into a CI/CD pipeline that handles protected build artifacts without manual intervention.
 * 5. When a file‑processing microservice receives encrypted ZIP uploads and must validate the password before extracting the payload.
 */
