// HOW-TO: Extract ALZ Archive With Checksum Verification And Save Report In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ALZ archive path
            string inputPath = @"C:\Archives\sample.alz";
            // Hardcoded output directory for extraction
            string outputDir = @"C:\Archives\Extracted";
            // Hardcoded report file path
            string reportPath = @"C:\Archives\checksum_report.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Load options with checksum verification enabled
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.SkipChecksumVerification = false;

            // Perform extraction and capture verification outcome
            string verificationMessage;
            try
            {
                using (Archive archive = new Archive(inputPath, loadOptions))
                {
                    archive.ExtractToDirectory(outputDir);
                }
                verificationMessage = "Checksum verification passed.";
            }
            catch (Exception ex)
            {
                verificationMessage = $"Checksum verification failed: {ex.Message}";
            }

            // Write the verification outcome to a text report
            using (StreamWriter writer = new StreamWriter(reportPath, false))
            {
                writer.WriteLine(verificationMessage);
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
 * 1. When you need to ensure the integrity of an ALZ backup before extracting its files on a Windows server.
 * 2. When a deployment script must extract compressed data and log whether the archive passed checksum validation for audit purposes.
 * 3. When an automated data‑migration tool processes ALZ archives and must record any corruption detected during extraction.
 * 4. When a security‑focused application extracts user‑submitted ALZ files and needs a text report of the verification result.
 * 5. When a CI/CD pipeline extracts build artifacts packaged as ALZ and requires a verification log to fail the build if checksums mismatch.
 */
