// HOW-TO: Extract Password Protected ZIP Archive With UTF8 Encoding In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Archives\sample.zip";
            string outputDirectory = @"C:\Extracted\ZipOutput";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "MySecretPassword";
            loadOptions.Encoding = Encoding.UTF8;

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically unzip a password‑protected archive and ensure filenames are correctly decoded using UTF‑8.
 * 2. When your application must extract all files from a secured ZIP file to a specific directory without manual user interaction.
 * 3. When you are processing archives that contain non‑ASCII characters and require a custom encoding to preserve file names.
 * 4. When you want to automate deployment scripts that pull resources from encrypted ZIP packages on a Windows server.
 * 5. When you need to validate that a given password and encoding successfully open and extract an archive before further processing.
 */
