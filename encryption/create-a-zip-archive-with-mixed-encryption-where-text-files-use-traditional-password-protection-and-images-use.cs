// HOW-TO: Create ZIP With Mixed Encryption Using Traditional And AES256 In C# (Aspose.ZIP for .NET)
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
            // Input files
            string textFile1 = @"C:\Input\doc1.txt";
            string textFile2 = @"C:\Input\doc2.txt";
            string imageFile1 = @"C:\Input\image1.jpg";
            string imageFile2 = @"C:\Input\image2.png";

            // Verify input files exist
            if (!File.Exists(textFile1))
            {
                Console.Error.WriteLine($"File not found: {textFile1}");
                return;
            }
            if (!File.Exists(textFile2))
            {
                Console.Error.WriteLine($"File not found: {textFile2}");
                return;
            }
            if (!File.Exists(imageFile1))
            {
                Console.Error.WriteLine($"File not found: {imageFile1}");
                return;
            }
            if (!File.Exists(imageFile2))
            {
                Console.Error.WriteLine($"File not found: {imageFile2}");
                return;
            }

            // Output ZIP path
            string outputZip = @"C:\Output\mixed_encryption.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            // Create the ZIP archive with mixed encryption
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            using (Archive archive = new Archive())
            {
                // Text files with traditional password protection
                archive.CreateEntry(
                    "doc1.txt",
                    new FileInfo(textFile1),
                    true,
                    new ArchiveEntrySettings(
                        new DeflateCompressionSettings(),
                        new TraditionalEncryptionSettings("TextPass1")));

                archive.CreateEntry(
                    "doc2.txt",
                    new FileInfo(textFile2),
                    true,
                    new ArchiveEntrySettings(
                        new DeflateCompressionSettings(),
                        new TraditionalEncryptionSettings("TextPass2")));

                // Image files with AES256 encryption
                archive.CreateEntry(
                    "image1.jpg",
                    new FileInfo(imageFile1),
                    true,
                    new ArchiveEntrySettings(
                        new DeflateCompressionSettings(),
                        new AesEcryptionSettings("ImagePass1", EncryptionMethod.AES256)));

                archive.CreateEntry(
                    "image2.png",
                    new FileInfo(imageFile2),
                    true,
                    new ArchiveEntrySettings(
                        new DeflateCompressionSettings(),
                        new AesEcryptionSettings("ImagePass2", EncryptionMethod.AES256)));

                // Save the archive
                archive.Save(zipStream);
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
 * 1. When you need to distribute confidential text documents with a simple password while protecting high‑value images with stronger AES‑256 encryption in a single ZIP file using C#.
 * 2. When a backup utility must store logs and configuration files using legacy ZipCrypto for compatibility, but encrypt media assets with AES‑256 for compliance with security policies.
 * 3. When an application generates reports and embeds screenshots, requiring different encryption levels so that end‑users can open the text reports with a known password while the images remain protected with industry‑standard AES encryption.
 * 4. When a software installer packages license files and promotional images, applying traditional password protection to the license text and AES‑256 to the images to meet both legacy tool support and modern security requirements.
 * 5. When a document management system archives mixed content and needs to apply mixed encryption to satisfy regulatory rules that mandate stronger encryption for binary files while allowing older systems to read the text entries.
 */
