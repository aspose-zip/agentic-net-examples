// HOW-TO: Create AES 128 192 256 Encrypted ZIP Files for Images in C# (Aspose.ZIP for .NET)
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
            // AES 128 encryption
            string inputPath128 = "data\\image1.png";
            string outputPath128 = "output\\image1_aes128.zip";

            if (!File.Exists(inputPath128))
            {
                Console.Error.WriteLine($"File not found: {inputPath128}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath128));

            using (FileStream zipFile128 = File.Open(outputPath128, FileMode.Create))
            using (FileStream source128 = File.Open(inputPath128, FileMode.Open, FileAccess.Read))
            using (var archive128 = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings("Password128", EncryptionMethod.AES128))))
            {
                archive128.CreateEntry("image1.png", source128);
                archive128.Save(zipFile128);
            }

            // AES 192 encryption
            string inputPath192 = "data\\image2.png";
            string outputPath192 = "output\\image2_aes192.zip";

            if (!File.Exists(inputPath192))
            {
                Console.Error.WriteLine($"File not found: {inputPath192}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath192));

            using (FileStream zipFile192 = File.Open(outputPath192, FileMode.Create))
            using (FileStream source192 = File.Open(inputPath192, FileMode.Open, FileAccess.Read))
            using (var archive192 = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings("Password192", EncryptionMethod.AES192))))
            {
                archive192.CreateEntry("image2.png", source192);
                archive192.Save(zipFile192);
            }

            // AES 256 encryption
            string inputPath256 = "data\\image3.png";
            string outputPath256 = "output\\image3_aes256.zip";

            if (!File.Exists(inputPath256))
            {
                Console.Error.WriteLine($"File not found: {inputPath256}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath256));

            using (FileStream zipFile256 = File.Open(outputPath256, FileMode.Create))
            using (FileStream source256 = File.Open(inputPath256, FileMode.Open, FileAccess.Read))
            using (var archive256 = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings("Password256", EncryptionMethod.AES256))))
            {
                archive256.CreateEntry("image3.png", source256);
                archive256.Save(zipFile256);
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
 * 1. When you need to securely distribute confidential images to clients by encrypting each PNG with different AES key strengths in a ZIP archive using C#.
 * 2. When your application must comply with regulatory standards that require AES‑256 encryption for sensitive media files before archiving them.
 * 3. When you want to generate separate password‑protected ZIP packages for multiple image assets, each using a specific AES encryption level for tiered access control.
 * 4. When automating a backup process that stores image files in encrypted ZIP files, allowing you to choose between AES‑128, AES‑192, or AES‑256 based on performance and security requirements.
 * 5. When building a cross‑platform tool that creates encrypted ZIP archives of pictures, enabling users to open them only with the correct password and encryption method in .NET.
 */
