// HOW-TO: Create AES‑256 Encrypted ZIP with Password in C# Using Aspose (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.txt";
            string outputPath = "encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the source file for reading
            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            // Open (or create) the destination ZIP file
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add the source file as an entry named "input.txt"
                archive.CreateEntry("input.txt", sourceStream);

                // Configure AES‑256 encryption with a strong password
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.EncryptionOptions = new AesEcryptionSettings(
                    "Str0ngP@ssw0rd!2026", // strong password
                    EncryptionMethod.AES256);

                // Save the encrypted ZIP archive
                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to securely transmit confidential text files over email, you can encrypt them into an AES‑256 ZIP archive with a strong password using Aspose.Zip in C#.
 * 2. When storing backup copies of sensitive documents on cloud storage, you can create password‑protected AES‑256 ZIP files to prevent unauthorized access.
 * 3. When complying with data‑protection regulations that require encryption at rest, you can generate encrypted ZIP archives programmatically in a .NET application.
 * 4. When building a file‑sharing feature that lets users download multiple files as a single encrypted package, you can use this code to bundle and encrypt the files on the fly.
 * 5. When automating the archiving of log files that contain private information, you can protect the archive with AES‑256 encryption and a strong password before archiving it.
 */
