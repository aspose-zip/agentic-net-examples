// HOW-TO: Extract ALZ Archive with CP949 Encoding to Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Archives\sample.alz";
            string outputPath = @"C:\Extracted\AlzOutput";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (Archive archive = new Archive(inputPath))
            {
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
 * 1. When you need to unpack Korean‑language ALZ files that use CP949 encoding into a specific folder in a .NET application.
 * 2. When a Windows service must automatically extract archived logs stored as ALZ archives with CP949 character set to a central repository.
 * 3. When a migration script has to read and extract legacy ALZ packages containing file names in Korean characters before processing them further.
 * 4. When a desktop utility needs to allow users to select an ALZ file and extract all its contents to a chosen output directory while preserving correct filenames.
 * 5. When an automated build pipeline must decompress ALZ resources encoded in CP949 to prepare assets for deployment.
 */
