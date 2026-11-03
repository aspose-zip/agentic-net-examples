// HOW-TO: Compress Multiple Files Into a ZIP With Mixed AES128 and Traditional Encryption in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath1 = "C:\\Data\\Document1.txt";
            string inputPath2 = "C:\\Data\\Document2.txt";
            string outputPath = "C:\\Output\\EncryptedArchive.zip";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the ZIP archive with encrypted entries
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                using (Archive archive = new Archive())
                {
                    // Traditional encryption for the first file
                    FileInfo source1 = new FileInfo(inputPath1);
                    archive.CreateEntry(
                        "Document1.txt",
                        source1,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new TraditionalEncryptionSettings("TradPwd123")));

                    // AES128 encryption for the second file
                    FileInfo source2 = new FileInfo(inputPath2);
                    archive.CreateEntry(
                        "Document2.txt",
                        source2,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new AesEcryptionSettings("AesPwd456", EncryptionMethod.AES128)));

                    // Save the archive to the output stream
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
 * 1. When a developer must send confidential documents to a client and wants to protect one file with strong AES128 encryption while using legacy traditional encryption for compatibility with older unzip tools.
 * 2. When an application needs to bundle several reports into a single ZIP archive and apply different encryption methods per file to meet varying security policies.
 * 3. When a backup utility creates compressed archives of logs and wants to encrypt sensitive logs with AES128 while keeping less critical logs encrypted with the simpler traditional method.
 * 4. When a software product generates downloadable resource packs and must ensure that premium assets are secured with AES128 while free assets use traditional encryption for broader accessibility.
 * 5. When integrating with third‑party systems that only support traditional ZIP encryption, a developer can still protect newer files with AES128 within the same archive using Aspose.Zip for .NET.
 */
