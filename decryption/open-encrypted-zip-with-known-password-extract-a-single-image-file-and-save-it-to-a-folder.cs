// HOW-TO: Extract a Specific Image From an Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output directory
            string inputPath = @"C:\Data\encrypted.zip";
            string outputDirectory = @"C:\Output\Images";
            string outputFilePath = Path.Combine(outputDirectory, "photo.jpg");
            string entryName = "photo.jpg";
            string zipPassword = "password123";

            // Verify the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Set load options with the known password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = zipPassword;

            // Open the encrypted ZIP archive
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Locate the desired image entry
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => 
                    string.Equals(e.Name, entryName, StringComparison.OrdinalIgnoreCase));

                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the specified output file
                entry.Extract(outputFilePath);
                Console.WriteLine($"Extracted '{entryName}' to '{outputFilePath}'.");
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
 * 1. When you need to programmatically retrieve a protected photo from a password‑protected ZIP file and store it on a server using C#.
 * 2. When an application must automatically extract a single image from an encrypted archive received via email without manual decompression.
 * 3. When a backup system stores confidential images in encrypted ZIPs and you need to restore a specific file to a local directory.
 * 4. When a web service processes user‑uploaded encrypted ZIPs and must pull out a designated picture for further processing.
 * 5. When a desktop utility has to locate and extract a known image entry from a secured ZIP archive as part of a batch workflow.
 */
