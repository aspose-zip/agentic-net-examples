// HOW-TO: Extract a Single AES Encrypted File from a Stored ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (AES‑encrypted, stored without compression)
            string inputPath = "encrypted.zip";

            // Hardcoded output file path for the extracted entry
            string outputPath = "extracted/file.txt";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Password for AES encryption (sample password)
            string password = "Password123";

            // Load options with the decryption password for the entire archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = password;

            // Open the encrypted ZIP archive for reading
            using (FileStream zipStream = File.OpenRead(inputPath))
            using (Archive archive = new Archive(zipStream, loadOptions))
            {
                // Retrieve the first entry (adjust index as needed)
                ArchiveEntry entry = archive.Entries[0];

                // Extract the entry to the specified output path
                entry.Extract(outputPath);
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
 * 1. When you need to programmatically retrieve a confidential document from an AES‑encrypted ZIP that was created with no compression, such as a secure report stored on a server.
 * 2. When an application must automatically extract a password‑protected log file from a stored ZIP archive during a nightly maintenance routine.
 * 3. When a client application receives an encrypted ZIP bundle and must decrypt and save a specific configuration file without decompressing the entire archive.
 * 4. When you want to validate that a given AES‑encrypted ZIP contains the expected file by extracting it to a temporary location for further processing.
 * 5. When integrating with a legacy system that supplies stored (uncompressed) encrypted ZIPs, and you need to pull out a single invoice PDF using a known password.
 */
