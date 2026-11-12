// HOW-TO: Encrypt Text With Password And Binary With AES256 In C# Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputTextFile = @"C:\Data\sample.txt";
            string inputBinaryFile = @"C:\Data\image.png";
            string outputZipPath = @"C:\Output\encrypted.zip";

            // Validate input files
            if (!File.Exists(inputTextFile))
            {
                Console.Error.WriteLine($"File not found: {inputTextFile}");
                return;
            }

            if (!File.Exists(inputBinaryFile))
            {
                Console.Error.WriteLine($"File not found: {inputBinaryFile}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create the ZIP archive with encrypted entries
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                FileInfo textInfo = new FileInfo(inputTextFile);
                FileInfo binaryInfo = new FileInfo(inputBinaryFile);

                using (Archive archive = new Archive())
                {
                    // Text file with traditional password protection
                    archive.CreateEntry(
                        "sample.txt",
                        textInfo,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new TraditionalEncryptionSettings("textpwd")));

                    // Binary file with AES256 encryption
                    archive.CreateEntry(
                        "image.png",
                        binaryInfo,
                        true,
                        new ArchiveEntrySettings(
                            new DeflateCompressionSettings(),
                            new AesEcryptionSettings("binarypwd", EncryptionMethod.AES256)));

                    // Save the archive
                    archive.Save(zipStream);
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
 * 1. When you need to securely distribute a confidential text report and an image together, you can create a ZIP file that protects the text with a simple password and the image with strong AES256 encryption using C# and Aspose.Zip.
 * 2. When compliance regulations require different encryption strengths for different file types, this code lets you apply traditional password protection to log files while encrypting binary executables with AES256 before archiving them.
 * 3. When building an automated backup system that stores both configuration files and binary assets, you can use this approach to compress the data and apply appropriate encryption levels to each entry in a single ZIP archive.
 * 4. When sending sensitive documents to clients who may use older ZIP tools, you can ensure the text files remain accessible with standard password protection while keeping high‑value binary files protected with AES256 for enhanced security.
 * 5. When developing a C# application that needs to package mixed content for secure email attachment, this snippet shows how to create a compressed ZIP with per‑entry encryption, simplifying the process of meeting security policies.
 */
