// HOW-TO: Compress Multiple JSON Files into AES192 Encrypted ZIP in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input files and output archive paths
            string inputDir = @"C:\Data";
            string[] jsonFiles = new string[]
            {
                Path.Combine(inputDir, "data1.json"),
                Path.Combine(inputDir, "data2.json"),
                Path.Combine(inputDir, "data3.json")
            };
            string outputPath = @"C:\Output\encrypted.zip";

            // Verify each input file exists
            foreach (string filePath in jsonFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output zip file stream
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add each JSON file with its own AES192 password
                    FileInfo source1 = new FileInfo(jsonFiles[0]);
                    archive.CreateEntry(
                        "data1.json",
                        source1,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new AesEcryptionSettings("PasswordOne", EncryptionMethod.AES192)));

                    FileInfo source2 = new FileInfo(jsonFiles[1]);
                    archive.CreateEntry(
                        "data2.json",
                        source2,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new AesEcryptionSettings("PasswordTwo", EncryptionMethod.AES192)));

                    FileInfo source3 = new FileInfo(jsonFiles[2]);
                    archive.CreateEntry(
                        "data3.json",
                        source3,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new AesEcryptionSettings("PasswordThree", EncryptionMethod.AES192)));

                    // Save the archive to the file stream
                    archive.Save(zipFile);
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
 * 1. When you need to securely back up several JSON configuration files before storing them in a shared drive.
 * 2. When you want to transmit sensitive JSON data over email or FTP while ensuring each file is individually protected with AES192.
 * 3. When your application generates multiple JSON reports that must be archived and encrypted for compliance with data‑privacy regulations.
 * 4. When you are building a deployment package that includes JSON resources and you require per‑file encryption to prevent unauthorized access.
 * 5. When you need to create a compressed archive of JSON logs for long‑term storage, with strong encryption to keep the log contents confidential.
 */
