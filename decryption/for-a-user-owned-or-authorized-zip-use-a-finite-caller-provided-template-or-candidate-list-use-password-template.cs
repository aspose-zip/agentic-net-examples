// HOW-TO: Extract Encrypted ZIP and Save File List to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (must exist)
            string inputPath = "sample_encrypted.zip";

            // Directory where entries will be extracted
            string extractDir = "extracted";

            // Output text file that will contain the list of extracted file names
            string outputPath = "output/extracted_files.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractDir);
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the encrypted archive with the password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "Password123";

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the specified directory
                archive.ExtractToDirectory(extractDir);
            }

            // Gather all extracted file names (non‑secret information)
            string[] extractedFiles = Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories);

            // Write the list of file names to the output text file
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                foreach (string filePath in extractedFiles)
                {
                    writer.WriteLine(Path.GetFileName(filePath));
                }
            }

            Console.WriteLine($"Extraction list saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unlock a password‑protected ZIP file and extract its contents without exposing the password in logs.
 * 2. When you must generate an inventory of files extracted from an encrypted archive for audit or reporting purposes.
 * 3. When a compliance workflow requires storing only non‑secret metadata such as file names locally while keeping the original archive secure.
 * 4. When automating deployment scripts that need to unpack encrypted resource bundles and record which files were deployed.
 * 5. When building a desktop utility that extracts user‑provided encrypted archives and creates a simple text manifest for further processing.
 */
