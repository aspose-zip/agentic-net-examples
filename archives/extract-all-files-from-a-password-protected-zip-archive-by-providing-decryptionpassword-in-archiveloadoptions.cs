// HOW-TO: Extract All Files From Password Protected ZIP Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\protected.zip";
            string outputPath = "C:\\Data\\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Set decryption password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "password123";

            // Open the password‑protected archive and extract all entries
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine("Extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically unpack confidential reports stored in a password‑protected ZIP file on a server using C#.
 * 2. When a desktop application must retrieve encrypted backup files from a ZIP archive without manual user interaction.
 * 3. When a scheduled service extracts daily data packages that are secured with a known password for further processing.
 * 4. When you integrate Aspose.Zip into a CI pipeline to unzip protected build artifacts before testing.
 * 5. When a file‑transfer utility downloads a secured ZIP from a partner and programmatically extracts its contents in a .NET environment.
 */
