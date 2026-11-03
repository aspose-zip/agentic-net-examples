// HOW-TO: Extract All Files From Password Protected ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (encrypted with traditional password)
            string inputZipPath = "C:\\Data\\encrypted.zip";

            // Hardcoded output folder where files will be extracted
            string outputFolder = "C:\\Data\\Extracted";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Set the password for decryption
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "myPassword";

            // Open the ZIP archive with the specified load options
            using (FileStream zipStream = File.Open(inputZipPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream, loadOptions))
                {
                    // Extract all entries to the output folder
                    archive.ExtractToDirectory(outputFolder);
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
 * 1. When you need to automatically unpack a secure ZIP file received from a client into a server folder using C#.
 * 2. When a scheduled job must decrypt and extract daily backup archives that are protected with a traditional password.
 * 3. When integrating a document management system that receives password‑protected ZIP uploads and must store the contained files on disk.
 * 4. When building a migration tool that reads encrypted ZIP packages and extracts their contents to a new location without manual intervention.
 * 5. When creating a desktop utility that lets users select an encrypted ZIP and extract all its items to a chosen directory in a .NET application.
 */
